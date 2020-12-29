using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Brands;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Brands
{
    public interface IBrandService
    {
        Task<List<BrandVm>> GetAll();

        Task<PagedResult<BrandVm>> GetSizesPagings(GetBrandPagingRequest request);

        Task<string> CreateBrand(BrandCreateRequest request);

        Task<BrandVm> GetById(string id);

        Task<int> DeleteBrand(string id);
    }
}
