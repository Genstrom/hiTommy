using hiTommy.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloTommy.Controllers
{
    //[Authorize]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ShoeServices _shoesService;

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