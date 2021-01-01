using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Vouchers;
using WebAPI.ViewModels.Catalog.Vouchers;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherService _VoucherService;

        public VouchersController(IVoucherService VoucherService)
        {
            _VoucherService = VoucherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _VoucherService.GetAll();
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetVoucherPagingRequest request)
        {
            var Vouchers = await _VoucherService.GetVouchersPagings(request);
            return Ok(Vouchers);
        }

        ////Create
        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var idCategory = await _categoryService.Create(request);
        //    if (idCategory == 0)
        //        return BadRequest();

        //    var product = await _categoryService.GetById(idCategory, request.LanguageId);

        //    return CreatedAtAction(nameof(GetById), new { id = idCategory }, product);
        //}

        //http://localhost:port/category/1
        [HttpGet("{idVoucher}/{languageId}")]
        public async Task<IActionResult> GetById(string idVoucher)
        {
            var Voucher = await _VoucherService.GetById(idVoucher);
            if (Voucher == null)
                return BadRequest("Cannot find Voucher");
            return Ok(Voucher);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] VoucherCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idVoucher = await _VoucherService.CreateVoucher(request);


            var product = await _VoucherService.GetById(idVoucher);

            return CreatedAtAction(nameof(GetById), new { id = idVoucher }, product);
        }

        //delete
        [HttpDelete("{IdVoucher}")]
        public async Task<IActionResult> Delete(string IdVoucher)
        {
            var affectedResult = await _VoucherService.DeleteVoucher(IdVoucher);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
