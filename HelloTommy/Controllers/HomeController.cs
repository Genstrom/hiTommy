using HelloTommy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
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
        public BrandServices _brandServices;
        public HomeController(ILogger<HomeController> logger, ShoeServices shoeService, BrandServices brandServices)
        {
            _logger = logger;
            _shoesService = shoeService;
            _brandServices = brandServices;
        }


        public IActionResult Index()
        {

            var allShoesVm = new ShoeListViewModel()
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic mymodel = new ExpandoObject();
            mymodel.AllShoes = allShoesVm.Shoes;
            mymodel.Brand = allBrandsVM;

            return View(mymodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}