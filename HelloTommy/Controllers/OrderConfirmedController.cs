using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using hiTommy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HelloTommy.Controllers
{
    [Route("orderconfirmed")]
    public class OrderConfirmedController : Controller
    {
        public BrandServices _brandServices;

        public ShoeServices _shoesService;
        public OrderConfirmedController(BrandServices brandServices, ShoeServices shoesService)
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
        public IActionResult Index(int ShoeId, string firstName, string lastName, string billing, string city, string postal)
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();
            var shoe = _shoesService.GetShoeById(ShoeId);

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("hitommyorder@gmail.com", "HiTommy Order");
                    var receiverEmail = new MailAddress("hellotommyshoe@gmail.com", "Receiver");
                    var password = "ITHS2020!";
                    var sub = "HiTommy Purchase";
                    var body = $"Hello {firstName} \n" +
                                $"\n" +
                                $"Thank you for your recent transaction on HiTommy. \n" +
                                $"- - - - - - \n" +
                                $"Your purchased items: \n {shoe.Name} - {shoe.Price.ToString("C2")} \n" +
                                $"\n" +
                                $"Billing information: \n" +
                                $"Full name - {firstName} {lastName} \n" +
                                $"Billing address - {billing} \n" +
                                $"City - {city} \n" +
                                $"Postal code - {postal} \n";
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

