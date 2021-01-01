using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.Data.Entities;
using WebAPI.Utilities.Exceptions;
using WebAPI.ViewModels.Catalog.Vouchers;
using WebAPI.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Application.Catalog.Vouchers
{
    public class VoucherService : IVoucherService
    {
        private readonly WebApiDbContext _context;

        public VoucherService(WebApiDbContext context)
        {
            _context = context;
        }


        public async Task<string> CreateVoucher(VoucherCreateRequest request)
        {
            var vouchers = new vouchers()
            {
                idVoucher=request.idVoucher,
                price=request.price,
                expiredDate=request.expiredDate,
                isUse=0

            };

            _context.vouchers.Add(vouchers);
            await _context.SaveChangesAsync();
            return vouchers.idVoucher;
        }

        public async Task<int> DeleteVoucher(string id)
        {
            var vouchers = await _context.vouchers.FindAsync(id);
            if (vouchers == null) throw new WebAPIException($"Cannot find a size: {id}");

            _context.vouchers.Remove(vouchers);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<VoucherVm>> GetAll()
        {
            var query = from c in _context.vouchers
                        select new { c };
            return await query.Select(x => new VoucherVm()
            {
                idVoucher = x.c.idVoucher,
                expiredDate=x.c.expiredDate,
                isUse=x.c.isUse,
                price=x.c.price
                

            }).ToListAsync();
        }

        public async Task<VoucherVm> GetById(string id)
        {
            var vouchers = await _context.vouchers.FindAsync(id);
            var vouchersViewModel = new VoucherVm()
            {
                idVoucher = vouchers.idVoucher,
                expiredDate = vouchers.expiredDate,
                isUse = vouchers.isUse,
                price = vouchers.price


            };
            return vouchersViewModel;
        }

        public async Task<PagedResult<VoucherVm>> GetVouchersPagings(GetVoucherPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.vouchers
                        select new { p };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.idVoucher.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new VoucherVm()
                {
                    idVoucher = x.p.idVoucher,
                    expiredDate = x.p.expiredDate,
                    isUse = x.p.isUse,
                    price = x.p.price

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<VoucherVm>()
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
