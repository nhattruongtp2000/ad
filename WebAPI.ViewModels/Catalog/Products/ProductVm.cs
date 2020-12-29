using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Catalog.Categories;

namespace WebAPI.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public string idProduct { get; set; }

        public string idSize { get; set; }
        public string idBrand { get; set; }

        public string idColor { get; set; }
        public string idCategory { get; set; }
        public string idType { get; set; }

        public string productName { get; set; }
        public string price { get; set; }
        public string salePrice { get; set; }
        public string photoReview { get; set; }
        public string detail { get; set; }

        public byte isSaling { get; set; }
        public DateTime expiredSalingDate { get; set; }
        public DateTime dateAdded { get; set; }

        public string ThumbnailImage { get; set; }

        public List<string> Categories { get; set; } = new List<string>();


    }
}
