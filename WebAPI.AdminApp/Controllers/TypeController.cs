using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.ApiIntegration;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Colors;
using WebAPI.ViewModels.Catalog.Types;

namespace WebAPI.AdminApp.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeApiClient _typeApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public TypeController(ITypeApiClient typeApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _typeApiClient = typeApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetTypePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,

            };
            var data = await _typeApiClient.GetTypesPagings(request);
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
        public async Task<IActionResult> Create([FromForm] TypeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _typeApiClient.CreateType(request);
            if (result)
            {
                TempData["result"] = "Thêm mới Type thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm Type thất bại");
            return View(request);
        }

        //delete
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(new TypeDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TypeDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _typeApiClient.DeleteType(request.Id);
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

