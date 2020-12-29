using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Categories;
using WebAPI.ViewModels.Catalog.Categories;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _categoryService.GetAll();
            return Ok(products);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCategoryPagingRequest request)
        {
            var categories = await _categoryService.GetCategoriesPagings(request);
            return Ok(categories);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idCategory = await _categoryService.Create(request);
            if (idCategory == null)
                return BadRequest();

            var product = await _categoryService.GetById(  idCategory);

            return CreatedAtAction(nameof(GetById), new { id = idCategory }, product);
        }

        //http://localhost:port/category/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return BadRequest("Cannot find product");
            return Ok(category);
        }

        //edit
        [HttpPut("{CategoryId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] string CategoryId, [FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = CategoryId;
            var affectedResult = await _categoryService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        //delete
        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> Delete(string CategoryId)
        {
            var affectedResult = await _categoryService.Delete(CategoryId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

    }
}
