using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.AdminApp.Controllers.Components
{
    public class ColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
