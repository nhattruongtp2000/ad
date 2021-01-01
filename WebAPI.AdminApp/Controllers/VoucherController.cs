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
using WebAPI.ViewModels.Catalog.Vouchers;

namespace WebAPI.AdminApp.Controllers
{
    public class VoucherController : Controller
    {
        private readonly IVoucherApiClient _voucherApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public VoucherController(IVoucherApiClient voucherApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _voucherApiClient = voucherApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetVoucherPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _voucherApiClient.GetVouchersPagings(request);
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
        public async Task<IActionResult> Create([FromForm] VoucherCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _voucherApiClient.CreateVoucher(request);
            if (result)
            {
                TempData["result"] = "Thêm mới Voucher thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm Voucher thất bại");
            return View(request);
        }

        //delete
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(new VoucherDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VoucherDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _voucherApiClient.DeleteVoucher(request.Id);
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
