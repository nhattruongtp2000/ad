using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Types;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public interface ITypeApiClient
    {
        Task<List<TypeVm>> GetAll();

        Task<PagedResult<TypeVm>> GetTypesPagings(GetTypePagingRequest request);

        Task<bool> CreateType(TypeCreateRequest request);

        Task<TypeVm> GetById(string id);

        Task<bool> DeleteType(string id);
    }
}
