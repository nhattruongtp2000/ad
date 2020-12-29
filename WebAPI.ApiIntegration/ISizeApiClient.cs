using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Sizes;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public interface ISizeApiClient
    {
        Task<List<SizeVm>> GetAll();

        Task<PagedResult<SizeVm>> GetSizesPagings(GetSizePagingRequest request);

        Task<bool> CreateSize(SizeCreateRequest request);

        Task<SizeVm> GetById(string id);

        Task<bool> DeleteSize(string id);
    }
}
