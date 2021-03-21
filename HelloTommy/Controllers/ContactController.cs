using System;
using System.Dynamic;
using System.Net;
using System.Net.Mail;
using HelloTommy.Models;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloTommy.Controllers
{
    [Route("{contact}")]
    public class ContactController : Controller
    {
        public BrandServices _brandServices;

        public ShoeServices _shoesService;

        public ContactController(BrandServices brandServices, ShoeServices shoesService)
        {
            _brandServices = brandServices;
            _shoesService = shoesService;
        }


        
     
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

        [HttpPost]
        public ActionResult Index(string name, string email, string message, string subject)
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
                    var senderEmail = new MailAddress("hellotommyshoe@gmail.com", "HelloTommyShoes");
                    var receiverEmail = new MailAddress("hellotommyshoe@gmail.com", "Receiver");
                    var password = "";
                    var sub = subject;
                    var body = $"From Name: {name} Email:{email} \n{message}";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
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
