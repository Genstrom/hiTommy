using System.Dynamic;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloTommy.Controllers
{
    [Route("faq")]
    public class FAQController : Controller
    {
        public BrandServices _brandServices;
        public ShoeServices _shoesService;

        public FAQController(ShoeServices shoeServices, BrandServices brandServices)
        {
            _brandServices = brandServices;
            _shoesService = shoeServices;
        }

        public IActionResult Index()
        {
            var allShoesVm = new ShoeListViewModel
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