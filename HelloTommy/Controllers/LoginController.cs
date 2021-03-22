using Microsoft.AspNetCore.Mvc;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using System.Dynamic;

namespace HelloTommy.Controllers
{
    [Route("Login")]

    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
