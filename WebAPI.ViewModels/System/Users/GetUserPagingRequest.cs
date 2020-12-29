using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
