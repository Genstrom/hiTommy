using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloTommy.Controllers
{
    //[Authorize]
    [Route("product")]
    public class ProductController : Controller
    {
        public ShoeServices _shoesService;

        public ProductController(ShoeServices shoeServices)
        {
            _shoesService = shoeServices;
        }
        [Route("{productId:int}")]
        public IActionResult Index(int productId)
        {
           var shoe = _shoesService.GetShoeById(productId);

            return View(shoe);
        }
    }
}
