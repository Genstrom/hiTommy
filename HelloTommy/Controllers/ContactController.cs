using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HelloTommy.Models;
using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;

namespace HelloTommy.Controllers
{
    public class ContactController : Controller
    {
       
        public ShoeServices _shoesService;
        public BrandServices _brandServices;

        public ContactController(BrandServices brandServices, ShoeServices shoesService)
        {
            _brandServices = brandServices;
            _shoesService = shoesService;
        }


        [Route("{contact}")]
       [HttpGet()]
        public IActionResult Index()
        {
            var allShoesVm = new ShoeListViewModel()
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();
            var formModel = new ContaFormModel();

            dynamic myModel = new ExpandoObject();
             
            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;
            myModel.Contact = formModel;


            return View(myModel);
        }
        
        [HttpPost]
       /* public IActionResult Index(string firstName)
        {
            return Content($"Hello {firstName}");
        }*/
        [HttpPost]  
        public ActionResult Index( string name, string email, string message, string subject){  
           var allShoesVm = new ShoeListViewModel()
           {
               Shoes = _shoesService.GetAllShoes()
           };
           var allBrandsVM = _brandServices.GetAllBrands();
           var formModel = new ContaFormModel();

           dynamic myModel = new ExpandoObject();
             
           myModel.AllShoes = allShoesVm.Shoes;
           myModel.Brand = allBrandsVM;
           myModel.Contact = formModel;
           
           try {  
                if (ModelState.IsValid) {  
                    var senderEmail = new MailAddress("hellotommyshoe@gmail.com","HelloTommyShoes");  
                    var receiverEmail = new MailAddress("hellotommyshoe@gmail.com","Receiver");  
                    var password = "ITHS2020!";
                    var sub = subject;
                    var body = $"From Name: {name} Email:{email} \n{message}";  
                    var smtp = new SmtpClient {  
                        Host = "smtp.gmail.com",  
                        Port = 587,  
                        EnableSsl = true,  
                        DeliveryMethod = SmtpDeliveryMethod.Network,  
                        UseDefaultCredentials = false,  
                        Credentials = new NetworkCredential(senderEmail.Address, password)  
                    };  
                    using(var mess = new MailMessage(senderEmail, receiverEmail) {  
                        Subject = sub,  
                        Body = body,
                    }) {  
                        smtp.Send(mess);  
                    }  
                    return View(myModel);  
                }  
            } catch (Exception) {  
                ViewBag.Error = "Some Error";  
            }  
            return View(myModel);  
        }  
    }
}
