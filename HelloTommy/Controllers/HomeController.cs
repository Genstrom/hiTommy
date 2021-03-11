using System.Diagnostics;
using System.Dynamic;
using HelloTommy.Models;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloTommy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BrandServices _brandServices;
        private readonly ShoeServices _shoesService;

        public HomeController(ILogger<HomeController> logger, ShoeServices shoeService, BrandServices brandServices)
        {
            _logger = logger;
            _shoesService = shoeService;
            _brandServices = brandServices;
        }


        public IActionResult Index()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVm = _brandServices.GetAllBrands();

            dynamic mymodel = new ExpandoObject();
            mymodel.AllShoes = allShoesVm.Shoes;
            mymodel.Brand = allBrandsVm;
          

            return View(mymodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}