using System.Dynamic;
using HelloTommy.Data;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloTommy.Controllers
{
    [Route("brand")]
    public class BrandController : Controller
    {
        private readonly BrandServices BrandServices;
        private ApplicationDbContext Context;

        public BrandController(BrandServices brandServices, ApplicationDbContext context)
        {
            BrandServices = brandServices;
            Context = context;
        }

        [Route("{brandId:int}")]
        public IActionResult Index(int brandId)
        {
            var brandsById = new BrandWithShoesListViewModel
            {
                Shoes = BrandServices.GetShoesByBrandId(brandId).Shoes,
                Id = brandId,
                Brand = BrandServices.GetAllBrands().Find(n => n.Id == brandId)
            };
            var allBrandsVm = BrandServices.GetAllBrands();

            dynamic mymodel = new ExpandoObject();
            mymodel.Shoes = brandsById.Shoes;
            mymodel.Brand = allBrandsVm;

            return View(mymodel);
        }
    }
}