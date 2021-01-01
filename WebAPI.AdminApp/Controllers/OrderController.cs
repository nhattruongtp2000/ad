using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.ApiIntegration;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Orders;

namespace WebAPI.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient  _orderApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public OrderController(IOrderApiClient orderApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _orderApiClient = orderApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            
            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
   
            };
            var data = await _orderApiClient.GetOrdersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var result = await _orderApiClient.GetById(id);
            return View(result);
        }

        //delete
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(new OrderDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrderDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _orderApiClient.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> Create([FromForm] OrderCreateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View(request);

        //    var result = await _orderApiClient.Create(request);
        //    if (result)
        //    {
        //        TempData["result"] = "Thêm mới sản phẩm thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
        //    return View(request);
        //}
    }
}
