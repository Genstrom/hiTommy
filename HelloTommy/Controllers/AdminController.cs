using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;

namespace HelloTommy.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        public BrandServices _brandServices;

        public ShoeServices _shoesService;

        public AdminController(BrandServices brandServices, ShoeServices shoesService)
        {
            _brandServices = brandServices;
            _shoesService = shoesService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;


            return View(myModel);
        }

        [Route("add-shoe")]
        [HttpGet]
        public IActionResult AddShoeView()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;


            return View(myModel);
        }
        [Route("add-shoe")]
        [HttpPost]
        public ActionResult Index(string name, int price, int brandId, string picture, string description)
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();


            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            try
            {
                if (ModelState.IsValid)
                {
                    var shoe = new ShoeViewModel()
                    {
                        Name = name,
                        Price = price,
                        BrandId = brandId,
                        PictureUrl = picture,
                        Description = description
                    };

                    if (!string.IsNullOrWhiteSpace(shoe.Description))
                    {
                        _shoesService.AddShoe(shoe);
                    }
                    

                    return View(myModel);
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return View(myModel);
        }
    }
}

