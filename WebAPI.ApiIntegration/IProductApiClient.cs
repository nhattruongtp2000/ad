using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.ProductImages;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ProductVm> GetById(string id);

        Task<bool> UpdateProduct(ProductUpdateRequest request);

        Task<bool> DeleteProduct(string id);

        Task<bool> AddImage(string idProduct, ProductImageCreateRequest request);

        //Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        //Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
    }
}
