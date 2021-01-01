using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Vouchers
{
    public class GetVoucherPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public int VoucherId { get; set; }
    }
}
