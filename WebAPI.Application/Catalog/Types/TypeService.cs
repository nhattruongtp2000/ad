using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.Data.Entities;
using WebAPI.Utilities.Exceptions;
using WebAPI.ViewModels.Catalog.Types;
using WebAPI.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Application.Catalog.Types
{
    public class TypeService : ITypeService
    {
        private readonly WebApiDbContext _context;

        public TypeService(WebApiDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateType(TypeCreateRequest request)
        {
            var type = new productTypes()
            {
                idType = request.IdType,
                typeName = request.Name,


            };

            _context.productTypes.Add(type);
            await _context.SaveChangesAsync();
            return type.idType;
        }

        public async Task<int> DeleteType(string id)
        {
            var type = await _context.productTypes.FindAsync(id);
            if (type == null) throw new WebAPIException($"Cannot find a Type: {id}");

            _context.productTypes.Remove(type);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TypeVm>> GetAll()
        {
            var query = from c in _context.productTypes
                        select new { c };
            return await query.Select(x => new TypeVm()
            {
                IdType = x.c.idType,
                Name = x.c.typeName
            }).ToListAsync();
        }

        public async Task<TypeVm> GetById(string id)
        {
            var Type = await _context.productTypes.FindAsync(id);
            var TypeViewModel = new TypeVm()
            {
                IdType = Type.idType,
                Name = Type.typeName,

            };
            return TypeViewModel;
        }

        public async Task<PagedResult<TypeVm>> GetTypesPagings(GetTypePagingRequest request)
        {
            //1. Select join
            var query = from p in _context.productTypes
                        select new { p };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.typeName.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TypeVm()
                {
                    IdType = x.p.idType,
                    Name = x.p.typeName,

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<TypeVm>()
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
