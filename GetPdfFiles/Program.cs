
using Doc2PdfApi.DatabaseSpecific;
using Doc2PdfApi.EntityClasses;
using Doc2PdfApi.Linq;
using Dtos.DtoClasses;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.IO.Compression;
using System.Net.Http;
using System.Timers;
using Timer = System.Timers.Timer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GetPdfFiles
{
    internal class Program
    {
        private static Timer _timer;
        private static IConfiguration Configuration { get; set; }
        private static readonly HttpClient _httpClient = new HttpClient();
        private static ILogger logger;

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogging(configure => configure.AddConsole())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);
            logger = services.BuildServiceProvider().GetService<ILogger<Program>>();
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(
                c => c.SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012)
                      .AddDbProviderFactory(typeof(SqlClientFactory))
                      .SetTraceLevel(System.Diagnostics.TraceLevel.Verbose));
            RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", Configuration.GetConnectionString("DefaultConnection"));
            Thread excutePerMinutes = new Thread(() => StartTimer());
            excutePerMinutes.Start();
            Thread manualExcute = new Thread(() => WaitForKeyPress());
            manualExcute.Start();
            excutePerMinutes.Join();
            manualExcute.Join();
        }

        private static void WaitForKeyPress()
        {
            while (true)
            {
                Console.WriteLine("Press 'x' to execute the keypress task.");
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.X)
                {
                    Console.WriteLine($"Keypress Task executed at {DateTime.Now}");
                    OnTimedEvent(null, null);
                }
            }
        }

        private static void StartTimer()    
        {
            _timer = new Timer(10000); // 60000 milliseconds = 1 minute
            _timer.Elapsed += OnTimedEvent;
            _timer.Elapsed += CallOcrService;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }
        private static async void OnTimedEvent(Object? source, ElapsedEventArgs e)
        {
            using (var adapter = new DataAccessAdapter())
            {
                DateTime dateTime = new DateTime(2024, 8, 13, 20, 48, 27, 420);
                string zipFileName = $"{dateTime.ToString("yyyy-MM-dd_HH-mm-ss")}.zip";
                string zipFilePath = Path.Combine("D:\\PdfExtract", zipFileName);
                string extractPath = Path.Combine("D:\\PdfExtract", dateTime.ToString("yyyy-MM-dd_HH-mm-ss"));
                string apiUrl = $"{Configuration["DocxToPdf:ApiUrl"]}{Uri.EscapeDataString(dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))}";
                await Console.Out.WriteLineAsync(apiUrl);
                SyncTime sync_time = new SyncTime();
                sync_time.Destination = apiUrl;
                sync_time.RequestTime = DateTime.Now;
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Make the GET request to download the ZIP file
                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        response.EnsureSuccessStatusCode();
                        string directoryPath = Path.GetDirectoryName(zipFilePath);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        // Save the ZIP file to the local disk
                        using (var fileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write))
                        {
                            await response.Content.CopyToAsync(fileStream);
                        }
                        logger.LogInformation("ZIP file downloaded successfully.");
                        
                        // Optional: Extract the ZIP file

                        if (!Directory.Exists(extractPath))
                        {
                            Directory.CreateDirectory(extractPath);
                        }

                        ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                        logger.LogInformation($"ZIP file extracted to: {extractPath}");

                        // Delete the ZIP file
                        File.Delete(zipFilePath);
                        sync_time.Status = true;
                    }
                    catch (HttpRequestException ex)
                    {
                        sync_time.Status = false;
                        sync_time.ErrorMessage = ex.Message;
                    }
                    catch (IOException ex)
                    {
                        sync_time.Status = false;
                        sync_time.ErrorMessage = ex.Message;
                    }
                    catch (InvalidDataException ex)
                    {
                        sync_time.Status = false;
                        sync_time.ErrorMessage = ex.Message;
                    }
                    if (sync_time.Status.Equals(true))
                    {
                        var extractedFiles = Directory.GetFiles(extractPath, "*", SearchOption.AllDirectories);

                        foreach (var file in extractedFiles)
                        {
                            PdfSync pdf_temp = new PdfSync();
                            pdf_temp.Name = Path.GetFileName(file);
                            pdf_temp.Id = Guid.NewGuid().ToString();
                            pdf_temp.FilePath = file;
                            pdf_temp.Status = "nothandle";
                            pdf_temp.DateCreate = DateTime.Now;
                            pdf_temp.DateModify = DateTime.Now;
                            var pdfEntity = ConvertDtoToEntity(pdf_temp);
                            await adapter.SaveEntityAsync(pdfEntity);
                        }
                    }
                    var syncTimeEntity = ConvertDtoToEntity(sync_time);
                    await adapter.SaveEntityAsync(syncTimeEntity);
                }
            }
        }

        private static async void CallOcrService(Object? source, ElapsedEventArgs e)
        {
            try
            {
                using (var adapter = new DataAccessAdapter())
                {
                    string apiUrl = $"{Configuration["Ocr:ApiUrl"]}";
                    var metaData = new LinqMetaData(adapter);
                    var oldestPdfFile = metaData.PdfSync.Where(x => x.Status.Equals("nothandle")).OrderByDescending(x => x.DateModify).FirstOrDefault();
                    using (var content = new MultipartFormDataContent())
                    {
                        byte[] fileBytes = File.ReadAllBytes(oldestPdfFile.FilePath);
                        content.Add(new ByteArrayContent(fileBytes), "file", Path.GetFileName(oldestPdfFile.FilePath));

                        // Add metadata like timestamp
                        content.Add(new StringContent(DateTime.UtcNow.ToString("o")), "timestamp");

                        HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
                        var responseBody = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            oldestPdfFile.JsonData = responseBody;
                            oldestPdfFile.Status = "handle";
                        }
                        else
                        {
                            oldestPdfFile.Status = "handlefail";
                            oldestPdfFile.ErrorMessage = responseBody;
                        }
                        adapter.SaveEntity(oldestPdfFile);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message}");
            }
        }

        private static SyncTimeEntity ConvertDtoToEntity(Dtos.DtoClasses.SyncTime dto)
        {
            var entity = new SyncTimeEntity();
            // Map properties from DTO to entity
            entity.Id = dto.Id;
            entity.Destination = dto.Destination;
            entity.Status = dto.Status;
            entity.RequestTime = dto.RequestTime;
            entity.ErrorMessage = dto.ErrorMessage;
            return entity;
        }

        private static PdfSyncEntity ConvertDtoToEntity(Dtos.DtoClasses.PdfSync dto)
        {
            var entity = new PdfSyncEntity();
            // Map properties from DTO to entity
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.FilePath = dto.FilePath;
            entity.JsonData = dto.JsonData;
            entity.Status = dto.Status;
            entity.ErrorMessage = dto.ErrorMessage;
            entity.DateCreate = dto.DateCreate;
            entity.UserCreate = dto.UserCreate;
            entity.UserModify = dto.UserModify;
            entity.DateModify = dto.DateModify;
            return entity;
        }
    }
}
