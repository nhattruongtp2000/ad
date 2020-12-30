using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Types;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public class TypeApiClient : BaseApiClient, ITypeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TypeApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

        }
        public async Task<bool> CreateType(TypeCreateRequest request)
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

            requestContent.Add(new StringContent(request.IdType.ToString()), "IdType");
            requestContent.Add(new StringContent(request.Name.ToString()), "Name");

            var response = await client.PostAsync($"/api/types/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async  Task<bool> DeleteType(string id)
        {
            return await Delete($"/api/types/" + id);
        }

        public async Task<List<TypeVm>> GetAll()
        {
            return await GetListAsync<TypeVm>("/api/types");
        }

        public async Task<TypeVm> GetById(string id)
        {
            var data = await GetAsync<TypeVm>($"/api/types/{id}");
            
            return data;
        }

        public async Task<PagedResult<TypeVm>> GetTypesPagings(GetTypePagingRequest request)
        {
            var data = await GetAsync<PagedResult<TypeVm>>(
               $"/api/types/paging?pageIndex={request.PageIndex}" +
               $"&pageSize={request.PageSize}" +
               $"&keyword={request.Keyword}&categoryId={request.TypeId}");

            return data;
        }
    }
}
