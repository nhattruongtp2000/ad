using WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class products
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
        public DateTime dateAdded  { get; set; }

        public List<odersDetails> odersDetails { get; set; }

        public List<productPhotos> productPhotos { get; set; }

        public List<rating> ratings { get; set; }

        public productBrand productBrand { get; set; }

        public productColor productColor { get; set; }
        public productCategories productCategories { get; set; }
        public productTypes productTypes { get; set; }

        public productSize productSize { get; set; }


    }
}
