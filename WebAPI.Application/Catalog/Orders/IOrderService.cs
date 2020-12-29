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
        Task<List<OrderVm>> GetAll();

        Task<List<OrderVm>> GetAllByUser(string User);

        Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request);

        //Task<int> Create(CheckoutRequest request);

        Task<OrderVm> GetById(string id);

        Task<int> Delete(string id);

      
    }
}
