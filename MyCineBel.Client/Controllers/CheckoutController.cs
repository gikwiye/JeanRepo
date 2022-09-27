using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCineBel.Client.Helpers;
using MyCineBel.Client.Models;
using MyCineBel.Client.ViewModel;
using Stripe;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MyCineBel.Client.Controllers
{
    public class CheckoutController : Controller
    {
        string accessToken;
        public IConfiguration Configuration { get; }
        public CheckoutController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        public async Task<string> managementAccessToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return accessToken;

        }

        [TempData]
        public string TotalAmount { get; set; }

       
        public ReservationModel reservation { get; set; }

        //ReservationModel reservation = new ReservationModel();
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<ReservationModel>(HttpContext.Session, "cart");
            ViewBag.cart = cart;

            ViewBag.cinema = cart.Cin_Name;
            ViewBag.film = cart.Film_titre;
            ViewBag.numero = cart.idSeance;
            ViewBag.EuroAmount = cart.nbrDeplaDemande * cart.TarSea_Prix;
            ViewBag.total = Math.Round(ViewBag.EuroAmount, 2) * 100;
            ViewBag.total = Convert.ToInt64(ViewBag.total);
            long total = ViewBag.total;
            TotalAmount = total.ToString();

          
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Processing(string stripeToken, string stripeEmail)
        {
            var cart = SessionHelper.GetObjectFromJson<ReservationModel>(HttpContext.Session, "cart");
            reservation = (ReservationModel)cart;
            var optionsCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Robert",
                Phone = "04-234567"
            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionsCust);
            var optionsCharge = new ChargeCreateOptions
            {
                Amount = Convert.ToInt64(TempData["TotalAmount"]),
                Currency = "NZD",
                Description = "Ticket de cinéma",
                Source = stripeToken,
                ReceiptEmail = stripeEmail
            };
            var serviceCharge = new ChargeService();
            Charge charge = serviceCharge.Create(optionsCharge);

            string reponse = "false";

            if (charge.Status== "succeeded")
            {
                accessToken = await managementAccessToken();

                //ReservationModel laReservation = new ReservationModel();
                //laReservation = (ReservationModel)TempData["reservation"];


                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                    var content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

                    //using var request = await httpClient.PostAsync($"https://localhost:44343/api/Ticket/AddReservation", content);
                    using var request = await httpClient.PostAsync($"{Configuration["MyCineBelApi"]}/api/Ticket/AddReservation", content);

                    reponse = await request.Content.ReadAsStringAsync();
                }
                
                //ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                //ViewBag.Customer = customer.Name;
            }


            if (reponse == "false")
            {
                return View("Reservation");

            }
            else
            {
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.Customer = customer.Name;

                return View();
                //return RedirectToAction("Index", "Cinema");
            }

        }
    }
}
