using WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class odersDetails
    {
        public string idOder { set; get; }
        public string idOrderList { get; set; }
        public string idProduct { get; set; }
        public int quality { get; set; }


        public odersList odersLists { get; set; }

        public products Products { get; set; }
    }
}
