using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productBrand
    {
        public string idBrand { get; set; }

        public string brandName { get; set; }

        public string brandDetail { get; set; }

        public  List<products> products { get; set; }
    }
}
