using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productCategories
    {
        public string idCategory { get; set; }
        public string categoryName { get; set; }

        public List<products> products { get; set; }
    }
}
