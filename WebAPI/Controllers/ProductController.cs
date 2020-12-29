//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using WebAPI.ApiIntegration;
//using WebAPI.Models;
//using WebAPI.ViewModels.Catalog.Products;

//namespace WebAPI.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly IProductApiClient _productApiClient;
//        private readonly ICategoryApiClient _categoryApiClient;

//        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
//        {
//            _productApiClient = productApiClient;
//            _categoryApiClient = categoryApiClient;
//        }
//        public async Task<IActionResult> Detail(int id,string culture)
//        {
//            var product = await _productApiClient.GetById(id, culture);

//            return View(new ProductDetailViewModel()
//            {
//                Product = product,
                
//            });
//        }

//        public async Task<IActionResult> Category(int id, string culture, int page = 1)
//        {
//            var products = await _productApiClient.GetPagings(new GetManageProductPagingRequest()
//            {
//                CategoryId = id,
//                PageIndex = page,
//                LanguageId = culture,
//                PageSize = 9
//            });
//            return View(new ProductCategoryViewModel()
//            {
//                Category = await _categoryApiClient.GetById(culture, id),
//                Products = products
//            }); ;
//        }
//    }
//}
