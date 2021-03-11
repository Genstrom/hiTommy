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
    [Route("_myMenuLayout")]
    public class MyMenuLayoutController : Controller
    {
        private readonly BrandServices _brandServices;
        private readonly ShoeServices _shoesService;

        public MyMenuLayoutController(BrandServices brandServices, ShoeServices shoeServices)
        {
            _brandServices = brandServices;
            _shoesService = shoeServices;

        }
        public IActionResult _MyMenuLayout()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVm = _brandServices.GetAllBrands();

            dynamic mymodel = new ExpandoObject();
            mymodel.AllShoes = allShoesVm.Shoes;
            mymodel.Brand = allBrandsVm;

            return View("_MyMenuLayout",mymodel);
        }
    }
}
