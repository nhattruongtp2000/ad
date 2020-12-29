using WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class odersList
    {
        public string idOrderList { get; set; }
        public string idOrder { get; set; }
        public string idUser { get; set; }
        public string idProduct { get; set; }

        public int quality { get; set; }

        public products Products { get; set; }

        public users users { get; set; }

        public odersDetails odersDetails { get; set; }
    }
}
