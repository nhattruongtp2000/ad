using WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class odersDetails
    {
        public string idOder { set; get; }
        public DateTime date { set; get; }
        public string status { set; get; }
        public int totalPrice { set; get; }
        public string idVoucher { get; set; }

        public List<odersList> odersLists { get; set; }
    }
}
