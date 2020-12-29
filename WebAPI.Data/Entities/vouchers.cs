using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class vouchers
    {
        public string idVoucher { get; set; }
        public int price { get; set; }

        public string expiredDate { get; set; }

        public byte isUse { get; set; }

    }
}
