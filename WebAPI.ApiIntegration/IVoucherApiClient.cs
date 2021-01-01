using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Vouchers;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public interface  IVoucherApiClient
    {
        Task<List<VoucherVm>> GetAll();

        Task<PagedResult<VoucherVm>> GetVouchersPagings(GetVoucherPagingRequest request);

        Task<bool> CreateVoucher(VoucherCreateRequest request);

        Task<VoucherVm> GetById(string id);

        Task<bool> DeleteVoucher(string id);
    }
}
