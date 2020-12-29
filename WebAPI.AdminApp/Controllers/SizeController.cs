using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.ApiIntegration;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Sizes;

namespace WebAPI.AdminApp.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeApiClient _sizeApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public SizeController(ISizeApiClient sizeApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _sizeApiClient = sizeApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetSizePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _sizeApiClient.GetSizesPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(data);
        }

        //create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] SizeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _sizeApiClient.CreateSize(request);
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
            return View(new SizeDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SizeDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _sizeApiClient.DeleteSize(request.Id);
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
