using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Orders
{
    public class GetOrderPagingRequest : PagingRequestBase
    {
        public string  Keyword { get; set; }

        public int OrderId { get; set; }

        public string  UserName { get; set; }
    }
}
