using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace hiTommy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Home()
        {
            return base.Content("<div>Home</div>", "text/html");
        }
        
       /* [Authorize]
        public IActionResult Secret()
        {
            return base.Content("<div>Secret</div>", "text/html");
        }
        
        [HttpGet]
        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim("Grandma.Says", "Very Nice boy"),
                new Claim(ClaimTypes.Email, "Bob@fmail.com")
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim("DrivingLicense", "A+"),
                new Claim(ClaimTypes.Name, "Bob Banana")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government Identity");
            var userPrincipal = new ClaimsPrincipal(new[] {grandmaIdentity, licenseIdentity});
            HttpContext.SignInAsync(userPrincipal);
            return Ok();
        }*/

      
    }
}
