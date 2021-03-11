using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;

namespace HelloTommy.Controllers
{
    
    [Route("AllProducts")]
    public class AllProductsController : Controller
    {
        private readonly BrandServices _brandServices;
        private readonly ShoeServices _shoesService;

        public AllProductsController(ShoeServices shoeService, BrandServices brandServices)
        {
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
    }
}
