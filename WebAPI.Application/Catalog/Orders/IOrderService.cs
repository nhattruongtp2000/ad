using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Models;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;
using WebAPI.ViewModels.Sales;

namespace WebAPI.Application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<PagedResult<OrderDetailsVm>> GetAllDetails(GetOrderDetailsPagingRequest request);

        Task<List<OrderVm>> GetAllByUser(string User);

        Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request);

        //Task<int> Create(CheckoutRequest request);

        Task<List<OrderDetailsVm>> GetById(string id);

        Task<int> Delete(string id);

      
    }
}
