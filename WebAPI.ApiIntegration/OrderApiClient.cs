using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;

namespace WebAPI.ApiIntegration
{
    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

        }

        //create
        //public async Task<bool> CreateOrder(OrderCreateRequest request)
        //{
        //    var sessions = _httpContextAccessor
        //         .HttpContext
        //         .Session
        //         .GetString(SystemConstants.AppSettings.Token);

        //    var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

        //    var requestContent = new MultipartFormDataContent();

        //    requestContent.Add(new StringContent(request.IdOrder.ToString()), "IdOrder");
        //    requestContent.Add(new StringContent(request.Name.ToString()), "Name");


        //    var response = await client.PostAsync($"/api/Orders/", requestContent);
        //    return response.IsSuccessStatusCode;
        //}

        public async Task<bool> DeleteOrder(string id)
        {
            return await Delete($"/api/orders/" + id);
        }

        public async Task<List<OrderVm>> GetAll()
        {
            return await GetListAsync<OrderVm>("/api/orders");
        }

        public async Task<List<OrderVm>> GetAllByUser(string User)
        {
            return await GetListAsync<OrderVm>($"/api/orders/{User}");
        }

        public async Task<OrderVm> GetById(string id)
        {
            var data = await GetAsync<OrderVm>($"/api/orders/{id}");

            return data;
        }

        public async Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request)
        {
            var data = await GetAsync<PagedResult<OrderVm>>(
                $"/api/orders/paging?pageIndex={request.PageIndex}" +
                $"&pageOrder={request.PageSize}" +
                $"&keyword={request.Keyword}&categoryId={request.OrderId}");

            return data;
        }
    }
}
