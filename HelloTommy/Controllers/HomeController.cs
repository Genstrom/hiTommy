using HelloTommy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;

namespace HelloTommy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ShoeServices _shoesService;
        public HomeController(ILogger<HomeController> logger, ShoeServices shoeService)
        {
            _logger = logger;
            _shoesService = shoeService;
        }


        public IActionResult Index()
        {

            var allShoesVm = new ShoeListViewModel()
            {
                Shoes = _shoesService.GetAllShoes()
            };
           

            return View(allShoesVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
