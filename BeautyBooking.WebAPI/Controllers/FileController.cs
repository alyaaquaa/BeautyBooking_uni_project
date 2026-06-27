using BeautyBooking.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BeautyBooking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public ActionResult DownloadFile([FromQuery] string fileName)
        {
            var dir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(dir, "Files", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Nie znaleziono pliku.");
            }

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out string? mimeType))
            {
                mimeType = "application/octet-stream";
            }

            var bytes = _fileService.DownloadFile(fileName);

            return File(bytes, mimeType, fileName);
        }
    }
}
