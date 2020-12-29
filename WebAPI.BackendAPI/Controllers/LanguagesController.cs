//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebAPI.Application.System.Languages;

//namespace WebAPI.BackendAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LanguagesController : ControllerBase
//    {
//        private readonly ILanguageService _languageService;

//        public LanguagesController(
//            ILanguageService languageService)
//        {
//            _languageService = languageService;
//        }

//        [HttpGet()]
//        public async Task<IActionResult> GetAll()
//        {
//            var products = await _languageService.GetAll();
//            return Ok(products);
//        }
//    }
//}
