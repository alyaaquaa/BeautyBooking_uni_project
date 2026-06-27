using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Application.Services
{
    public interface IFileService
    {
        byte[] DownloadFile(string fileName);

        void UploadFile(IFormFile file);
    }
}
