using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;
using WebAPI.ViewModels.Sales;

namespace WebAPI.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<PagedResult<OrderDetailsVm>> Details(GetOrderDetailsPagingRequest request);

        Task<List<OrderVm>> GetAllByUser(string User);

        Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request);

        Task<List<OrderDetailsVm>> GetById( string id);

        Task<bool> Delete(string id);



    }
}
