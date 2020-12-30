using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Colors;
using WebAPI.ViewModels.Catalog.Colors;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _colorService.GetAll();
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetColorPagingRequest request)
        {
            var Colors = await _colorService.GetColorsPagings(request);
            return Ok(Colors);
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
        [HttpGet("{idSize}")]
        public async Task<IActionResult> GetById(string idColor)
        {
            var Color = await _colorService.GetById(idColor);
            if (Color == null)
                return BadRequest("Cannot find Color");
            return Ok(Color);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ColorCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idColor = await _colorService.Create(request);


            var product = await _colorService.GetById(idColor);

            return CreatedAtAction(nameof(GetById), new { id = idColor }, product);
        }

        //delete
        [HttpDelete("{idColor}")]
        public async Task<IActionResult> Delete(string idColor)
        {
            var affectedResult = await _colorService.Delete(idColor);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}

