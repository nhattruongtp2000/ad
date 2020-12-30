using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Sizes;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public class SizeApiClient : BaseApiClient, ISizeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SizeApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

        }

        //create
        public async Task<bool> CreateSize(SizeCreateRequest request)
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

            requestContent.Add(new StringContent(request.IdSize.ToString()), "IdSize");
            requestContent.Add(new StringContent(request.Name.ToString()), "Name");
            

            var response = await client.PostAsync($"/api/sizes/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSize(string id)
        {
            return await Delete($"/api/sizes/" + id);
        }

        public async Task<List<SizeVm>> GetAll()
        {
            return await GetListAsync<SizeVm>("/api/sizes");
        }

        public async  Task<SizeVm> GetById(string id)
        {
            var data = await GetAsync<SizeVm>($"/api/sizes/{id}");

            return data;
        }

        public async Task<PagedResult<SizeVm>> GetSizesPagings(GetSizePagingRequest request)
        {
            var data = await GetAsync<PagedResult<SizeVm>>(
                $"/api/sizes/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&categoryId={request.SizeId}");

            return data;
        }
    }
}
