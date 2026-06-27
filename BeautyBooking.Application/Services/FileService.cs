using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Application.Services
{
    public class FileService : IFileService
    {
        public byte[] DownloadFile(string fileName)
        {
            var dir = Directory.GetCurrentDirectory();
            var filesDirectory = Path.Combine(dir, "Files");

            var filePath = Path.Combine(filesDirectory, fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Nie znaleziono pliku: {filePath}");
            }

            return File.ReadAllBytes(filePath);
        }

        public void UploadFile(IFormFile file)
        {
            var dir = Directory.GetCurrentDirectory();
            var filesDirectory = Path.Combine(dir, "Files");

            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

            var filePath = Path.Combine(filesDirectory, file.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
        }
    }
}

