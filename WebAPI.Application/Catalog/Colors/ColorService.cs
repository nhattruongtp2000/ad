using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.Data.Entities;
using WebAPI.Utilities.Exceptions;
using WebAPI.ViewModels.Catalog.Colors;
using WebAPI.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Application.Catalog.Colors
{
    public class ColorService : IColorService
    {
        private readonly WebApiDbContext _context;

        public ColorService(WebApiDbContext context)
        {
            _context = context;
        }
        public async Task<string> Create(ColorCreateRequest request)
        {
            var color = new productColor()
            {
                idColor = request.IdColor,
                colorName = request.Name,


            };

            _context.productColor.Add(color);
            await _context.SaveChangesAsync();
            return color.idColor;
        }

        public async  Task<int> Delete(string id)
        {
            var color = await _context.productColor.FindAsync(id);
            if (color == null) throw new WebAPIException($"Cannot find a color: {id}");

            _context.productColor.Remove(color);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ColorVm>> GetAll()
        {
            var query = from c in _context.productColor
                        select new { c };
            return await query.Select(x => new ColorVm()
            {
                IdColor = x.c.idColor,
                Name = x.c.colorName
            }).ToListAsync();
        }

        public async Task<ColorVm> GetById(string id)
        {
            var color = await _context.productColor.FindAsync(id);
            var colorViewModel = new ColorVm()
            {
                IdColor = color.idColor,
                Name = color.colorName,

            };
            return colorViewModel;
        }

        public async Task<PagedResult<ColorVm>> GetColorsPagings(GetColorPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.productColor
                        select new { p };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.colorName.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ColorVm()
                {
                    IdColor = x.p.idColor,
                    Name = x.p.colorName,

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ColorVm>()
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
