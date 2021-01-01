using WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class odersList
    {
        public string idOrderList { get; set; }
        public string idUser { get; set; }
        public int status { set; get; }
        public DateTime date { get; set; }
        public string idVoucher { get; set; }

        public users users { get; set; }

        public List<odersDetails> odersDetails { get; set; }
    }
}
