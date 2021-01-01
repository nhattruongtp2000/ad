using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Catalog.Vouchers
{
    public class VoucherCreateRequest
    {
        public string idVoucher { get; set; }
        public int price { get; set; }

        public DateTime expiredDate { get; set; }

        public byte isUse { get; set; }
    }
}
