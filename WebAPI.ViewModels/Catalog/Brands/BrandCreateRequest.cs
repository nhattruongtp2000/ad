using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Brands
{
    public class BrandCreateRequest 
    {
        public string IdBrand { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

    }
}
