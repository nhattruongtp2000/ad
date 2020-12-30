using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Types;
using WebAPI.ViewModels.Catalog.Types;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _typeService.GetAll();
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetTypePagingRequest request)
        {
            var types = await _typeService.GetTypesPagings(request);
            return Ok(types);
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
        public async Task<IActionResult> GetById(string idtype)
        {
            var type = await _typeService.GetById(idtype);
            if (type == null)
                return BadRequest("Cannot find type");
            return Ok(type);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] TypeCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idtype = await _typeService.CreateType(request);


            var product = await _typeService.GetById(idtype);

            return CreatedAtAction(nameof(GetById), new { id = idtype }, product);
        }

        //delete
        [HttpDelete("{idtype}")]
        public async Task<IActionResult> Delete(string idtype)
        {
            var affectedResult = await _typeService.DeleteType(idtype);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
