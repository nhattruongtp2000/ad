using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;
using WebAPI.ViewModels.Sales;
using WebAPI.Models;
using Microsoft.AspNetCore.Http;
using WebAPI.Utilities.Constants;
using Newtonsoft.Json;
using WebAPI.Utilities.Exceptions;

namespace WebAPI.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {

        private readonly WebApiDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(WebApiDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //public async Task<int> Create(CheckoutRequest request)
        //{

        //    List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
        //    if (request.OrderDetails != null)
        //        currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(request.OrderDetails);
        //    var orderdetail = new List<OrderDetail>();
            
        //    var user = _context.users.FirstOrDefault(x => x.UserName == request.UserName);
        //    var userid = user.Id;
            
        //    foreach (var item in currentCart)
        //    {
        //        orderdetail.Add(new OrderDetail()
        //        {
        //            ProductId = item.ProductId,
        //            Quantity = item.Quantity,
        //            Price = item.Price,
        //        });
        //    }

        //    var order = new Order()
        //    {
        //        UserName = request.UserName,
        //        ShipAddress = request.Address,
        //        ShipEmail = request.Email,
        //        ShipName = request.Name,
        //        ShipPhoneNumber = request.PhoneNumber,
        //        OrderDate = DateTime.Now,
        //        OrderDetails = orderdetail,
        //        LanguageId=request.LanguageId,
        //        UserId=userid               
        //    };            
        //    //Save image

        //    _context.Orders.Add(order);
        //    await _context.SaveChangesAsync();
        //    return order.Id; 
        //}

        public async Task<int> Delete(string id)
        {
            var or = await _context.odersList.FindAsync(id);
            if (or == null) throw new WebAPIException($"Cannot find a color: {id}");

            _context.odersList.Remove(or);
            return await _context.SaveChangesAsync(); ;
        }

        public async Task<PagedResult<OrderDetailsVm>> GetAllDetails(GetOrderDetailsPagingRequest request)
        {

            var query = from p in _context.odersDetails

                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.idOder.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();


            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new OrderDetailsVm()
                {
                    idOrderList = x.p.idOrderList,
                    idOder = x.p.idOder,
                    idProduct = x.p.idProduct,
                    quatity = x.p.quality,
                    totalPrice = x.p.totalPrice

                }).ToListAsync();

            var pagedResult = new PagedResult<OrderDetailsVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<List<OrderVm>> GetAllByUser(string User)
        {
            var query = from p in _context.odersList
                        join pt in _context.users on p.idUser equals pt.Id
                        where p.idUser == User
                        select new { p, pt };
            return await query.Select(x => new OrderVm()
            {
                idOrderList = x.p.idOrderList,
                idVoucher = x.p.idVoucher,
                date = x.p.date,
                status = x.p.status,
                idUser = x.p.idUser
            }).ToListAsync();
        }

        public async Task<List<OrderDetailsVm>> GetById(string id)
        {
            var query = from p in _context.odersDetails                       
                        where  p.idOrderList==id
                        select new { p};
            return await query.Select(x => new OrderDetailsVm()
            {
                idOrderList = x.p.idOrderList,
                idOder = x.p.idOder,
                idProduct = x.p.idProduct,
                quatity = x.p.quality,
                totalPrice = x.p.totalPrice
            }).ToListAsync();
        }

        

        public async Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.odersList                                       
                        select new { p };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.idUser.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    idOrderList = x.p.idOrderList,
                    idVoucher = x.p.idVoucher,
                    idUser = x.p.idUser,
                    date = x.p.date,
                    status = x.p.status

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<OrderVm>()
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
