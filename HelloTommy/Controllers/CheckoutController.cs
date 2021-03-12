using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using hiTommy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HelloTommy.Controllers
{
    [Route("Checkout")]
    public class CheckoutController : Controller
    {
        public BrandServices _brandServices;

        public ShoeServices _shoesService;

        public CheckoutController(BrandServices brandServices, ShoeServices shoesService)
        {
            _brandServices = brandServices;
            _shoesService = shoesService;
        }


        public IActionResult Checkout()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.Shoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;


            return View(myModel);
        }

        [HttpPost]
        public ActionResult Checkout(int size, int shoeId)
        {


            var allBrandsVM = _brandServices.GetAllBrands();

            var _shoe = _shoesService.GetShoeById(shoeId);




            dynamic myModel = new ExpandoObject();

            myModel.Shoe = _shoe;
            myModel.Brand = allBrandsVM;
            myModel.Size = size;


            return View(myModel);
        }
    }
}

