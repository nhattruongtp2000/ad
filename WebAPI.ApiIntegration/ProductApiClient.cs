using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.ProductImages;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public ProductApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/products/{id}/categories", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public async Task<bool> CreateProduct(ProductCreateRequest request)
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

            string a = RandomString(3);

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }
            requestContent.Add(new StringContent(a), "idProduct");
            requestContent.Add(new StringContent(request.productName.ToString()), "productName");
            requestContent.Add(new StringContent(request.price.ToString()), "price");
            requestContent.Add(new StringContent(request.salePrice.ToString()), "salePrice");
            requestContent.Add(new StringContent(request.detail.ToString()), "detail");
            requestContent.Add(new StringContent(request.idBrand.ToString()), "idBrand");
            requestContent.Add(new StringContent(request.idSize.ToString()), "idSize");
            requestContent.Add(new StringContent(request.idColor.ToString()), "idColor");
            requestContent.Add(new StringContent(request.idType.ToString()), "idType");
            requestContent.Add(new StringContent(request.idCategory.ToString()), "idCategory");
            requestContent.Add(new StringContent(request.isSaling.ToString()), "isSaling");
            requestContent.Add(new StringContent(request.expiredSalingDate.ToString()), "expiredSalingDate");
            var response = await client.PostAsync($"/api/products/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            return await Delete($"/api/products/" + id);
        }

        public async Task<ProductVm> GetById(string id)
        {
            var data = await GetAsync<ProductVm>($"/api/products/{id}");

            return data;
        }

        //public async Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take)
        //{
        //    var data = await GetListAsync<ProductVm>($"/api/products/featured/{languageId}/{take}");
        //    return data;
        //}

        //public async Task<List<ProductVm>> GetLatestProducts( int take)
        //{
        //    var data = await GetListAsync<ProductVm>($"/api/products/latest/{take}");
        //    return data;
        //}

        public async Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVm>>(
                $"/api/products/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&categoryId={request.CategoryId}");

            return data;
        }

        public async Task<bool> UpdateProduct(ProductUpdateRequest request)
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

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }

            //requestContent.Add(new StringContent(request.Id.ToString()), "id");
            requestContent.Add(new StringContent("123"), "photoReview");
            requestContent.Add(new StringContent(request.idCategory.ToString()), "idCategory");
            requestContent.Add(new StringContent(request.price.ToString()), "price");
            requestContent.Add(new StringContent(request.salePrice.ToString()), "salePrice");
            requestContent.Add(new StringContent(request.productName.ToString()), "productName");
            requestContent.Add(new StringContent(request.detail.ToString()), "detail");
            requestContent.Add(new StringContent(request.idBrand.ToString()), "idBrand");
            requestContent.Add(new StringContent(request.idSize.ToString()), "idSize");
            requestContent.Add(new StringContent(request.idColor.ToString()), "idColor");
            requestContent.Add(new StringContent(request.idType.ToString()), "idType");



            var response = await client.PutAsync($"/api/products/" + request.idProduct, requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddImage(string idProduct, ProductImageCreateRequest request)
        {
            var sessions = _httpContextAccessor
              .HttpContext
              .Session
              .GetString(SystemConstants.AppSettings.Token);

            var a = RandomString(3);
            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            byte[] data;
            using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
            {
                data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
            }
            ByteArrayContent bytes = new ByteArrayContent(data);
            requestContent.Add(new StringContent(a), "idImage");
            requestContent.Add(new StringContent(idProduct), "idProduct");
            requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);


            var response = await client.PostAsync($"/api/products/" + idProduct +"/2", requestContent);
            return response.IsSuccessStatusCode;


        }
    }
}
