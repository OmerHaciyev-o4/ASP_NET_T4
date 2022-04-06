using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Task4.Helpers
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _webHost;

        public ImageHelper(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public string GetURL(IFormFile file, int id)
        {
            string imgExtension = Path.GetExtension(file.FileName);
            var location = Path.Combine(_webHost.WebRootPath, "images", (id + imgExtension));
            using (var imgWork = new FileStream(location, FileMode.Create))
            {
                file.CopyTo(imgWork);
            }

            return (id + imgExtension).ToString();
        }
    }
}
