using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.Data.Entities;
using WebAPI.ViewModels.Catalog.Categories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.ViewModels.Common;
using WebAPI.Utilities.Exceptions;

namespace WebAPI.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly WebApiDbContext _context;

        public CategoryService(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(CategoryCreateRequest request)
        {
            var category = new productCategories()
            {
                idCategory = request.idCategory,
                categoryName = request.categoryName
                
            };

            //Save image
           
            _context.productCategories.Add(category);
            await _context.SaveChangesAsync();
            return category.idCategory;
        }

        public async Task<int> Delete(string idCategory)
        {
            var category = await _context.productCategories.FindAsync(idCategory);
            if (category == null) throw new WebAPIException($"Cannot find a category: {idCategory}");

            _context.productCategories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryVm>> GetAll()
        {
            var query = from c in _context.productCategories
                        select new { c};
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.idCategory,
                Name = x.c.categoryName
                
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById( string categoryId)
        {
            var query = from c in _context.productCategories
                        where  c.idCategory==categoryId
                        select new { c };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.idCategory,
                Name = x.c.categoryName

            }).FirstOrDefaultAsync();
        }

        public async Task<PagedResult<CategoryVm>> GetCategoriesPagings(GetCategoryPagingRequest request)
        {

            ////1. Select join
            //var query = from p in _context.Categories
            //            join pt in _context.CategoryTranslations on p.idCategory equals pt.CategoryId
            //            join pic in _context.ProductInCategories on p.idCategory equals pic.idCategory into ppic
            //            from pic in ppic.DefaultIfEmpty()
            //            join c in _context.products on pic.ProductId equals c.ProductId into picc
            //            from c in picc.DefaultIfEmpty()

            //            select new { p, pt, pic };
            ////2. filter
            //if (!string.IsNullOrEmpty(request.Keyword))
            //    query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            //if (request.CategoryId != null && request.CategoryId != 0)
            //{
            //    query = query.Where(p => p.pic.idCategory == request.CategoryId);
            //}

            ////3. Paging
            //int totalRow = await query.CountAsync();

            //var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            //    .Take(request.PageSize)
            //    .Select(x => new CategoryVm()
            //    {
            //        Id = x.p.idCategory,
            //        ProductId = x.pic.ProductId,
            //        Name = x.pt.Name,
            //        SeoDescription = x.pt.SeoDescription,
            //        SeoAlias = x.pt.SeoAlias,
            //        SeoTitle = x.pt.SeoTitle,

            //    }).ToListAsync();

            ////4. Select and projection
            //var pagedResult = new PagedResult<CategoryVm>()
            //{
            //    TotalRecords = totalRow,
            //    PageSize = request.PageSize,
            //    PageIndex = request.PageIndex,
            //    Items = data
            //};
            //return pagedResult;

            //1. Select join
            var query = from p in _context.productCategories
                
                        select new { p};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.categoryName.Contains(request.Keyword));

          
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryVm()
                {
                    Id = x.p.idCategory,
                    Name = x.p.categoryName
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<CategoryVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(CategoryUpdateRequest request)
        {
            var category = await _context.productCategories.FindAsync(request.Id);
          

            if (category == null ) throw new WebAPIException($"Cannot find a category with id: {request.Id}");

            category.idCategory = request.Id;
            category.categoryName = request.Name;

            //Save image          
            return await _context.SaveChangesAsync();
        }
    }
}