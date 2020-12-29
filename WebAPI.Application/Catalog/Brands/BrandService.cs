using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.Data.Entities;
using WebAPI.Utilities.Exceptions;
using WebAPI.ViewModels.Catalog.Brands;
using WebAPI.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Application.Catalog.Brands
{
    public class BrandService : IBrandService
    {

        private readonly WebApiDbContext _context;

        public BrandService(WebApiDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateBrand(BrandCreateRequest request)
        {
            var brand = new productBrand()
            {
                idBrand = request.IdBrand,
                brandName = request.Name,
                brandDetail=request.Details,
                

            };


            _context.productBrand.Add(brand);
            await _context.SaveChangesAsync();
            return brand.idBrand;
        }

        public async Task<int> DeleteBrand(string id)
        {
            var brand = await _context.productBrand.FindAsync(id);
            if (brand == null) throw new WebAPIException($"Cannot find a brand: {id}");

            _context.productBrand.Remove(brand);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<BrandVm>> GetAll()
        {
            var query = from c in _context.productBrand
                        select new { c };
            return await query.Select(x => new BrandVm()
            {
                IdBrand = x.c.idBrand,
                Name = x.c.brandName,
                Details=x.c.brandDetail
                
            }).ToListAsync();
        }

        public async Task<BrandVm> GetById(string id)
        {
            var brand = await _context.productBrand.FindAsync(id);
            var brandViewModel = new BrandVm()
            {
                IdBrand = brand.idBrand,
                Name = brand.idBrand,
                Details=brand.brandDetail,
                
            };
            return brandViewModel;
        }

        public async Task<PagedResult<BrandVm>> GetSizesPagings(GetBrandPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.productBrand
                   
                        select new { p };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.brandName.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new BrandVm()
                {
                    IdBrand = x.p.idBrand,
                    Name = x.p.brandName,
                    Details=x.p.brandDetail,
                
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<BrandVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
