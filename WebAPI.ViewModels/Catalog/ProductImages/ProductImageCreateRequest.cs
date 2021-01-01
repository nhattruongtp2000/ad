using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {
        public string idImage { get; set; }

        public string idProduct { get; set; }

        public string link { get; set; }

        public DateTime uploadedTime { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
