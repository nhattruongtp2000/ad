using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Brands;
using WebAPI.ViewModels.Catalog.Brands;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brand = await _brandService.GetAll();
            return Ok(brand);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetBrandPagingRequest request)
        {
            var brands = await _brandService.GetSizesPagings(request);
            return Ok(brands);
        }

        [HttpGet("{IdBrand}")]
        public async Task<IActionResult> GetById(string IdBrand)
        {
            var brand = await _brandService.GetById(IdBrand);
            if (brand == null)
                return BadRequest("Cannot find brand");
            return Ok(brand);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] BrandCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idBrand = await _brandService.CreateBrand(request);


            var brand = await _brandService.GetById(idBrand);

            return CreatedAtAction(nameof(GetById), new { id = idBrand }, brand);
        }

        //delete
        [HttpDelete("{IdBrand}")]
        public async Task<IActionResult> Delete(string IdBrand)
        {
            var affectedResult = await _brandService.DeleteBrand(IdBrand);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }

    

}
