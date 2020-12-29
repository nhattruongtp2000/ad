using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Sizes;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public class ColorApiClient
    {
        Task<List<ColorVm>> GetAll();

        Task<PagedResult<ColorVm>> GetSizesPagings(GetSizePagingRequest request);

        Task<bool> CreateSize(ColorCreateRequest request);

        Task<SizeVm> GetById(string id);

        Task<bool> DeleteColor(string id);
    }
}
