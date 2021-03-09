using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using HelloTommy.Data;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using hiTommy.Models;

namespace HelloTommy.Controllers
{
    [Route("brand")]
    public class BrandController : Controller
    {
        public BrandServices _brandServices;
        public ApplicationDbContext _context;

        public BrandController(BrandServices brandServices, ApplicationDbContext context)
        {
            _brandServices = brandServices;
            _context = context;
        }

        [Route("{brandid:int}")]
        public IActionResult Index(int Brandid)
        {
            var brandsById = new BrandWithShoesListViewModel()
            {
                Shoes = _brandServices.GetShoesByBrandId(Brandid).Shoes,
                Id = Brandid,
                Brand = _brandServices.GetAllBrands().Find(n =>n.Id == Brandid)

            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic mymodel = new ExpandoObject();
            mymodel.Shoes = brandsById.Shoes;
            mymodel.Brand = allBrandsVM;

            return View(mymodel);
        }
    }
}
