using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;
using WebAPI.ViewModels.Sales;

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

        public async Task<bool> Create(CheckoutRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var languageId = "vi";
            var UserName = _httpContextAccessor.HttpContext.User.Identity.Name;
            
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
           
            var requestContent = new MultipartFormDataContent();
            var cate = new List<string>();
           
            requestContent.Add(new StringContent(request.Address.ToString()), "Address");
            requestContent.Add(new StringContent(request.Name.ToString()), "Name");
            requestContent.Add(new StringContent(UserName), "UserName");
            requestContent.Add(new StringContent(request.Email.ToString()), "Email");
            requestContent.Add(new StringContent(languageId), "languageId");
            requestContent.Add(new StringContent(request.PhoneNumber.ToString()), "PhoneNumber");
            requestContent.Add(new StringContent(request.OrderDetails.ToString()), "OrderDetails");
           
            var response = await client.PostAsync($"/api/orders/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<OrderVm>> GetAll()
        {
            return await GetListAsync<OrderVm>("/api/orders");
        }

        public async Task<List<OrderVm>> GetAllByUser(string User )
        {
            return await GetListAsync<OrderVm>($"/api/orders/{User}");
        }

        public async Task<OrderVm> GetById( string id)
        {
            return await GetAsync<OrderVm>($"/api/orders/{id}");
        }

        public async Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request)
        {
            var data = await GetAsync<PagedResult<OrderVm>>(
                $"/api/orders/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&UserName={request.UserName}");

            return data;
        }
    }
}
