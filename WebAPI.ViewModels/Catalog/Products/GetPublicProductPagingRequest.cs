using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest :PagingRequestBase
    {
        public string idCategory { get; set; }
    }
}
