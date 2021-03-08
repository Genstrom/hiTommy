using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using hiTommy.Data.ViewModels;

namespace HelloTommy.Controllers
{
    public class ContactController : Controller
    {
       [Route("{contact}")]
       [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
       /* public IActionResult Index(string firstName)
        {
            return Content($"Hello {firstName}");
        }*/
        [HttpPost]  
        public ActionResult Index( string name, string email, string message, string subject){  
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
                    return View();  
                }  
            } catch (Exception) {  
                ViewBag.Error = "Some Error";  
            }  
            return View();  
        }  
    }
}
