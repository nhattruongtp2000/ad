using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.ProductImages;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<string> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(string idProduct);

        Task<int> UpdateImage(string imageId, ProductImageUpdateRequest request);
        Task<ProductVm> GetById(string productId);

        Task AddViewcount(int idProduct);

        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        //image
        Task<string> AddImage(string idProduct, ProductImageCreateRequest request);

        Task<int> RemoveImage(string imageId);


        Task<ProductImageViewModel> GetImageById(string imageId);

        //Task<List<ProductImageViewModel>> GetListImages(int idProduct);

        Task<PagedResult<ProductVm>> GetAllByCategoryId(GetPublicProductPagingRequest request);

        /*ask<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);*/
      
        
    }
}
