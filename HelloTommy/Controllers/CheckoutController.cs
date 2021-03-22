using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using hiTommy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HelloTommy.Controllers
{
    [Route("Checkout")]
    public class CheckoutController : Controller
    {
        private string baseURL = "https://api.playground.klarna.com/";

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(int size, int shoeId)
        {
            return View();
        }
      
    }
}

