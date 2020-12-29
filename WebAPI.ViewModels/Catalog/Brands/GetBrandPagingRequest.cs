using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Brands
{
    public class GetBrandPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public int BrandId { get; set; }

        public string LanguageId { get; set; }
    }
}
