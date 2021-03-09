using System.Dynamic;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using hiTommy.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloTommy.Controllers
{
    //[Authorize]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly BrandServices _brandServices;
        private readonly ShoeServices _shoesService;

        public ProductController(ShoeServices shoeServices, BrandServices brandServices)
        {
            _shoesService = shoeServices;
            _brandServices = brandServices;
        }

        [Route("{productId:int}")]
        public IActionResult Index(int productId)
        {
            

               var shoe = _shoesService.GetShoeById(productId);
      
            var allBrandsVm = _brandServices.GetAllBrands();

            dynamic mymodel = new ExpandoObject();
            mymodel.Shoe = shoe;
            mymodel.Brand = allBrandsVm;

            return View(mymodel);
        }
    }
}