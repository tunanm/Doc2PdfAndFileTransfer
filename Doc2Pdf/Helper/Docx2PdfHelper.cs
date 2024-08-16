using Aspose.Words;
using Aspose.Words.Replacing;
using Doc2PdfApi.EntityClasses;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace Doc2Pdf.Helper
{
    public class Docx2PdfHelper
    {
        public async Task<MemoryStream> Convert2Pdf(List<JsonDataSampleEntity> jsonData)
        {
            var zipStream = new MemoryStream();

            using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                for (int i = 0; i < jsonData.Count; i++)
                {
                    var line = jsonData[i];
                    var filePath = line.FilePath;


                    if (System.IO.File.Exists(filePath))
                    {
                        using (var docxStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            var doc = new Document(docxStream);

                            JObject json = JObject.Parse(line.JsonData);
                            int index = 1;
                            foreach (var item in json)
                            {
                                string patternString = @"\{Variable" + Regex.Escape(index.ToString()) + @"\}";
                                index++;
                                doc.Range.Replace(new Regex(patternString), item.Value.ToString(), new FindReplaceOptions());
                            }
                            docxStream.Position = 0; 
                            using (var pdfStream = new MemoryStream())
                            {
                                doc.Save(pdfStream, SaveFormat.Pdf);
                                pdfStream.Position = 0;

                                var entryName = Path.GetFileNameWithoutExtension(filePath) + "_" + i.ToString() + ".pdf";
                                var zipEntry = zipArchive.CreateEntry(entryName, CompressionLevel.Optimal);

                                using (var zipEntryStream = zipEntry.Open())
                                {
                                    await pdfStream.CopyToAsync(zipEntryStream);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("The file is not exists");
                    }
                }
            }
            zipStream.Position = 0;
            return zipStream;
        }
    }
}
