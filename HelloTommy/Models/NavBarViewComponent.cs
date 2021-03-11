using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTommy.Data;
using hiTommy.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloTommy.Models
{
    [Route("Shared")]
    public class NavBarViewComponent : ViewComponent
    {
        public BrandServices _brandServices;

        public ShoeServices _shoesService;
        private readonly ApplicationDbContext _context;

        public NavBarViewComponent(BrandServices brandServices, ShoeServices shoeServices, ApplicationDbContext context)
        {
            _brandServices = brandServices;
            _shoesService = shoeServices;
            _context = context;

        }
        [Route("NavBar")]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("NavBar");
        }
    }
}
