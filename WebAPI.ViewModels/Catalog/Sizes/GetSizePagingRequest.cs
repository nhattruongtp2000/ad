using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Sizes
{
    public class GetSizePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public int SizeId { get; set; }

        public string LanguageId { get; set; }
    }
}
