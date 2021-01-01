using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Vouchers;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public class VoucherApiClient : BaseApiClient, IVoucherApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VoucherApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

        }



        public async Task<bool> CreateVoucher(VoucherCreateRequest request)
        {
            var sessions = _httpContextAccessor
                  .HttpContext
                  .Session
                  .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.idVoucher.ToString()), "idVoucher");
            requestContent.Add(new StringContent(request.price.ToString()), "price");
            requestContent.Add(new StringContent(request.idVoucher.ToString()), "idVoucher");
            requestContent.Add(new StringContent(request.expiredDate.ToString()), "expiredDate");


            var response = await client.PostAsync($"/api/vouchers/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVoucher(string id)
        {
            return await Delete($"/api/vouchers/" + id);
        }

        public async Task<List<VoucherVm>> GetAll()
        {
            return await GetListAsync<VoucherVm>("/api/vouchers");
        }

        public async Task<VoucherVm> GetById(string id)
        {
            var data = await GetAsync<VoucherVm>($"/api/vouchers/{id}");

            return data;
        }

        public async Task<PagedResult<VoucherVm>> GetVouchersPagings(GetVoucherPagingRequest request)
        {
            var data = await GetAsync<PagedResult<VoucherVm>>(
                $"/api/vouchers/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&categoryId={request.VoucherId}");

            return data;
        }
    }
}
