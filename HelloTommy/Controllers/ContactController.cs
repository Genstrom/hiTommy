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



        
     
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string email, string message, string subject)
        {
          
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

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return View();
        }
    }
}
