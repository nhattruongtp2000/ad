using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Types;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Types
{
    public interface ITypeService
    {
        Task<List<TypeVm>> GetAll();

        Task<PagedResult<TypeVm>> GetTypesPagings(GetTypePagingRequest request);

        Task<string> CreateType(TypeCreateRequest request);

        Task<TypeVm> GetById(string id);

        Task<int> DeleteType(string id);
    }
}
