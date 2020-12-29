using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.ApiIntegration;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Brands;

namespace WebAPI.AdminApp.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandApiClient _brandApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public BrandController(IBrandApiClient brandApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _brandApiClient = brandApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetBrandPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };
            var data = await _brandApiClient.GetBrandsPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] BrandCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _brandApiClient.CreateBrand(request);
            if (result)
            {
                TempData["result"] = "Thêm mới Size thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm Size thất bại");
            return View(request);
        }

        //delete
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(new BrandDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BrandDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _brandApiClient.DeleteBrand(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}
