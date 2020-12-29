using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        public string idCategory { get; set; }
        public string categoryName { get; set; }
    }
}
