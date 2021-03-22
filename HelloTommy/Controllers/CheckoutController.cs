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
        private readonly ShoeServices _shoeService;
        private string baseURL = "https://api.playground.klarna.com/";

        public CheckoutController(ShoeServices shoeService)
        {
            _shoeService = shoeService;
        }

        public IActionResult Checkout()
        {

            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Checkout(int size, int shoeId)
        {
            var _shoe = _shoeService.GetShoeById(shoeId);

            dynamic myModel = new ExpandoObject();

            myModel.Shoe = _shoe;
            myModel.Size = size;

            return View(myModel);
        }
      
    }
}

