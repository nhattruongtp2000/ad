using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Vouchers;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Vouchers
{
    public interface IVoucherService
    {
        Task<List<VoucherVm>> GetAll();

        Task<PagedResult<VoucherVm>> GetVouchersPagings(GetVoucherPagingRequest request);

        Task<string> CreateVoucher(VoucherCreateRequest request);

        Task<VoucherVm> GetById(string id);

        Task<int> DeleteVoucher(string id);
    }
}
