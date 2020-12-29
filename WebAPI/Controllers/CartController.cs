//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using WebAPI.ApiIntegration;
//using WebAPI.Models;
//using WebAPI.Utilities.Constants;
//using WebAPI.ViewModels.Orders;
//using WebAPI.ViewModels.Sales;


//namespace WebAPI.Controllers
//{
//    [Authorize]
//    public class CartController : Controller
//    {
//        private readonly IProductApiClient _productApiClient;
//        private readonly IOrderApiClient _orderApiClient;

//        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient)
//        {
//            _orderApiClient = orderApiClient;
//            _productApiClient = productApiClient;
//        }

               

//        [HttpGet]
//        public IActionResult GetListItems()
//        {
//            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
//            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
//            if (session != null)
//                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
//            return Ok(currentCart);
//        }

        
//        public IActionResult Checkout()
//        {
//            return View(GetCheckoutViewModel());
//        }

//        [HttpPost]
//        public async Task<IActionResult> Checkout(CheckoutViewModel request)
//        {
//            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
//            var model = GetCheckoutViewModel();
//            var orderDetails = new List<OrderDetailVm>();
//            foreach (var item in model.CartItems)
//            {
//                orderDetails.Add(new OrderDetailVm()
//                {
//                    ProductId = item.ProductId,
//                    Quantity = item.Quantity,
//                    Price=item.Price,                    
//                });
//            }
//            var checkoutRequest = new CheckoutRequest()
//            {
//                UserName = User.Identity.Name,
//                Address = request.CheckoutModel.Address,
//                Name = request.CheckoutModel.Name,
//                Email = request.CheckoutModel.Email,
//                PhoneNumber = request.CheckoutModel.PhoneNumber,
//                OrderDetails = session,
//                LanguageId=request.CheckoutModel.LanguageId
//            };
//            await  _orderApiClient.Create(checkoutRequest);
//            TempData["SuccessMsg"] = "Order puschased successful";
//            //TODO: Add to API
//            ClearCart();
//            return View(model);
//        }

//        [Authorize]
//        private CheckoutViewModel GetCheckoutViewModel()
//        {
//            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
//            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
//            if (session != null)
//                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
//            var checkoutVm = new CheckoutViewModel()
//            {
//                CartItems = currentCart,
//                CheckoutModel = new CheckoutRequest()
//            };
//            return checkoutVm;
//        }

//        [Authorize]
//        public async Task<IActionResult> Details(string culture,string keyword, int pageIndex = 1, int pageSize = 10)
//            {
//            //if (TempData["result"] != null)
//            //{
//            //    ViewBag.SuccessMsg = TempData["result"];
//            //}
//            //user = User.Identity.Name;

//            //var result = await _orderApiClient.GetAllByUser(culture, user);
//            //return View(result);
//            var languageId = culture;
//            var sessions = HttpContext.Session.GetString("Token");
//            var request = new GetOrderPagingRequest()
//            {
//                UserName=User.Identity.Name,
//                Keyword = keyword,
//                PageIndex = pageIndex,
//                PageSize = pageSize,
                
//            };
//            var data = await _orderApiClient.GetOrdersPagings(request);
//            ViewBag.Keyword = keyword;
//            if (TempData["result"] != null)
//            {
//                ViewBag.SuccessMsg = TempData["result"];
//            }

//            return View(data);
//        }

//        [Authorize]
//        [HttpGet]
//        public async Task<IActionResult> DetailProduct(int id, string culture)
//        {
//            var product = await _productApiClient.GetById(id, culture);

//            return View(new ProductDetailViewModel()
//            {
//                Product = product,

//            });
//        }
//        public async Task<IActionResult> AddToCart(int id, string languageId)
//        {
//            var product = await _productApiClient.GetById(id, languageId);

//            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
//            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
//            if (session != null)
//                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

//            int quantity = 1;
//            if (currentCart.Any(x => x.ProductId == id))
//            {
//                quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;
//            }

//            var cartItem = new CartItemViewModel()
//            {
//                ProductId = id,
//                Description = product.detail,
//                Image = product.ThumbnailImage,
//                Name = product.ProductName,
//                Price=product.price,
//                Quantity = quantity
//            };

//            currentCart.Add(cartItem);

//            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
//            return Ok(currentCart);
//        }

//        public IActionResult UpdateCart(int id, int quantity)
//        {
//            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
//            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
//            if (session != null)
//                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

//            foreach (var item in currentCart)
//            {
//                if (item.ProductId == id)
//                {
//                    if (quantity == 0)
//                    {
//                        currentCart.Remove(item);
//                        break;
//                    }
//                    item.Quantity = quantity;
//                }
//            }

//            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
//            return Ok(currentCart);
//        }

//        public IActionResult ClearCart()
//        {
//            HttpContext.Session.Remove(SystemConstants.CartSession);
//            return new OkObjectResult("OK");
//        }

//        [HttpPost]
//        [Consumes("multipart/form-data")]
//        public async Task<IActionResult> Create([FromForm] CheckoutRequest request)
//        {
//            if (!ModelState.IsValid)
//                return View(request);


//            var result = await _orderApiClient.Create(new CheckoutRequest()
//            { 

//            });
//            if (result)
//            {
//                TempData["result"] = "Thêm mới sản phẩm thành công";
//                return RedirectToAction("Index");
//            }

//            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
//            return View(request);
//        }

//    }
//}
