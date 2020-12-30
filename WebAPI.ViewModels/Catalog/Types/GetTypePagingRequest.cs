using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Types
{
    public class GetTypePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public int TypeId { get; set; }
    }
}
