using hiTommy.Data.Services;
using hiTommy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloTommy.Views.Shared.Components
{
    public class NavBarViewComponent : ViewComponent
    {
        public BrandServices _brandServices;

        public ShoeServices _shoesService;
        
        public NavBarViewComponent(BrandServices brandServices)
        {
            _brandServices = brandServices;
        }

        public IViewComponentResult Invoke()
        {
            var brand = _brandServices.GetAllBrands();
            return View(brand);
        }



    }
}
