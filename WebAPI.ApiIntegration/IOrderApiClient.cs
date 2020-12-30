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
        Task<List<OrderVm>> GetAll();

        Task<List<OrderVm>> GetAllByUser(string User);

        Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request);

        Task<OrderVm> GetById( string id);

        Task<bool> Delete(string id);



    }
}
