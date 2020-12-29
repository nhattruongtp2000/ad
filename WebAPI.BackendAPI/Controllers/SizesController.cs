using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Sizes;
using WebAPI.ViewModels.Catalog.Sizes;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll( )
        {
            var products = await _sizeService.GetAll();
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetSizePagingRequest request)
        {
            var sizes = await _sizeService.GetSizesPagings(request);
            return Ok(sizes);
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
        [HttpGet("{idSize}/{languageId}")]
        public async Task<IActionResult> GetById(string idSize)
        {
            var size = await _sizeService.GetById(idSize);
            if (size == null)
                return BadRequest("Cannot find size");
            return Ok(size);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] SizeCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idSize = await _sizeService.CreateSize(request);
           

            var product = await _sizeService.GetById(idSize);

            return CreatedAtAction(nameof(GetById), new { id = idSize }, product);
        }

        //delete
        [HttpDelete("{IdSize}")]
        public async Task<IActionResult> Delete(string IdSize)
        {
            var affectedResult = await _sizeService.DeleteSize(IdSize);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
