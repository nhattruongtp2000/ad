using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Categories;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;

namespace WebAPI.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVm> Products { get; set; }
    }
}
