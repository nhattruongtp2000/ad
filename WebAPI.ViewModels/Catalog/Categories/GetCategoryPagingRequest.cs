using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Categories
{
    public class GetCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public string LanguageId { get; set; }
    }
}
