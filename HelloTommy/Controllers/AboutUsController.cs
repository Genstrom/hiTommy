using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloTommy.Controllers
{
    public class AboutUsController : Controller
    {

        [Route("About")]
        [HttpGet]
        public IActionResult Index()
        {        
            return View();
        }
    }
}
