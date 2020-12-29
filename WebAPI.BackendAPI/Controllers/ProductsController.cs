using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Products;
using WebAPI.ViewModels.Catalog.ProductImages;
using WebAPI.ViewModels.Catalog.Products;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }

        //http://localhost:port/product/1
        [HttpGet("{idProduct}")]
        public async Task<IActionResult> GetById(string idProduct)
        {
            var product = await _productService.GetById(idProduct);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idProduct = await _productService.Create(request);
            if (idProduct == null)
                return BadRequest();

            var product = await _productService.GetById(idProduct);

            return CreatedAtAction(nameof(GetById), new { id = idProduct }, product);
        }

        //edit
        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] string productId, [FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.idProduct = productId;
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


        //delete
        [HttpDelete("{idProduct}")]
        public async Task<IActionResult> Delete(string idProduct)
        {
            var affectedResult = await _productService.Delete(idProduct);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


    

        //Images
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(string productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId, request);
            if (imageId == null)
                return BadRequest();

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }


        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(string imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }


        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(string imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(string productId, string imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }

      

        //[HttpGet("featured/{languageId}/{take}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetFeaturedProducts(int take, string languageId)
        //{
        //    var products = await _productService.GetFeaturedProducts(languageId, take);
        //    return Ok(products);
        //}

        //[HttpGet("latest/{languageId}/{take}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetLatestProducts(int take, string languageId)
        //{
        //    var products = await _productService.GetLatestProducts(languageId, take);
        //    return Ok(products);
        //}

    }
}
