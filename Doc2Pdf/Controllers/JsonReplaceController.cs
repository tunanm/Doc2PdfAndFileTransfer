using Doc2Pdf.Helper;
using Doc2PdfApi.DatabaseSpecific;
using Doc2PdfApi.EntityClasses;
using Doc2PdfApi.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doc2Pdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonReplaceController : Controller
    {
        private readonly Docx2PdfHelper _docx2PdfHelper;

        // Constructor to initialize the helper
        public JsonReplaceController()
        {
            _docx2PdfHelper = new Docx2PdfHelper();
        }

        [HttpGet("{dateModify}")]
        public async Task<ActionResult> Get(DateTime dateModify)
        {
            try
            {
                using (var adapter = new DataAccessAdapter())
                {
                    var metaData = new LinqMetaData(adapter);
                    List<JsonDataSampleEntity> jsonData = metaData.JsonDataSample
                        .Where(x => x.UpdateDate >= dateModify)
                        .ToList();

                    if (jsonData.Any())
                    {
                        MemoryStream zipStream = await _docx2PdfHelper.Convert2Pdf(jsonData);
                        return File(zipStream, "application/zip", "documents.zip");
                    }

                    return NotFound("No documents found for the specified date.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error response
                // Example: return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] string timestamp)
        {
            if (file == null || file.Length == 0)
            {
                
            }
            return BadRequest(new { message = "No file uploaded." });
            //// Process the file (e.g., save it to disk or perform other actions)
            //var filePath = Path.Combine("uploads", file.FileName);
            //Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    await file.CopyToAsync(fileStream);
            //}

            // Optionally, log the timestamp or other metadata
            // For demonstration, we're just returning it in the response

            var fakeResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"result\":\"success\"}")
            };

            return Ok(fakeResponse);
        }
    }
}
