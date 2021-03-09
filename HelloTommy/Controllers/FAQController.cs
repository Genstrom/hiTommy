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
    [Route("faq")]
    public class FAQController : Controller
    {
        public ShoeServices _shoesService;
        public BrandServices _brandServices;

        public FAQController(ShoeServices shoeServices, BrandServices brandServices)
        {
            _brandServices = brandServices;
            _shoesService = shoeServices;
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
    }
}
