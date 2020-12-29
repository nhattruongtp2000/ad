using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Categories;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll();

        Task<PagedResult<CategoryVm>> GetCategoriesPagings(GetCategoryPagingRequest request);

        Task<string> Create(CategoryCreateRequest request);

        Task<CategoryVm> GetById( string categoryId);

        Task<int> Update(CategoryUpdateRequest request);

        Task<int> Delete(string idCategory);


    }
}
