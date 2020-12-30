using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Colors;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Colors
{
    public interface IColorService
    {
        Task<List<ColorVm>> GetAll();

        Task<PagedResult<ColorVm>> GetColorsPagings(GetColorPagingRequest request);

        Task<string> Create(ColorCreateRequest request);

        Task<ColorVm> GetById(string id);

        Task<int> Delete(string id);
    }
}
