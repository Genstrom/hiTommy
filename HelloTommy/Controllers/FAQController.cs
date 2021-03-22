using System.Dynamic;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloTommy.Controllers
{
    [Route("faq")]
    public class FAQController : Controller
    {

        public IActionResult Index()
        {         
            return View();
        }
    }
}