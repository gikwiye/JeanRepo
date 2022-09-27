using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyCineBel.Client.Helpers;
using MyCineBel.Client.Models;
using MyCineBel.Client.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCineBel.Client.Controllers
{
    public class TicketController : Controller
    {
      

        string accessToken;
        string name;
        public IConfiguration _Configuration { get; }

     

        public TicketController(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public async Task<string> managementAccessToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return accessToken;

        }


        //GET /Ticket/email
        //Pour retirer mes reservations

        public async Task <IActionResult> GetReservation()
        {
            string idToken = await HttpContext.GetTokenAsync("id_token");

            var stream = idToken;
            var handler = new JwtSecurityTokenHandler();
            var jsontoken = handler.ReadToken(stream);
            var token = jsontoken as JwtSecurityToken;
            name = token.Claims.First(claim => claim.Type == "name").Value;

            string email = name;

            List<ProcSelectMyReservation> mesReservations = new List<ProcSelectMyReservation>();

            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Ticket/{email}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Ticket/{email}");

                string response = await request.Content.ReadAsStringAsync();

                mesReservations = JsonConvert.DeserializeObject<List<ProcSelectMyReservation>>(response);
            }

            return View(mesReservations);
        }

      




        //GET/Ticket/create


        public async Task<IActionResult> PrintMaReservation(int Id)
        {
            
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                //var request = await httpClient.GetAsync($"https://localhost:44343/api/Ticket/CreatePDF/{Id}");
                var valeur = _Configuration["MyCineBelApi"];
                var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Ticket/CreatePDF/{Id}");
                var fstream = request.Content.ReadAsStream();
                return File(fstream, "application/pdf", $"ticket_{Id}.pdf");
            }
   
        }

        
        public IActionResult Acheter()
        {
            var cart = SessionHelper.GetObjectFromJson<ReservationModel>(HttpContext.Session, "cart");
            ViewBag.cart = cart;

            ViewBag.cinema = cart.Cin_Name;
            ViewBag.film = cart.Film_titre;
            ViewBag.numero = cart.idSeance;
            ViewBag.total = cart.nbrDeplaDemande * cart.TarSea_Prix;

            ReservationModel reservation = new ReservationModel();

            reservation = cart;

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", reservation);

            return View();
        }

             public IActionResult Buy (ReservationModel _reservation)
        {
            ReservationModel reservation = new ReservationModel();
                     
            reservation = _reservation;

            
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", reservation);

            return RedirectToAction("Acheter");
        }



        public  async Task<IActionResult> Create(int idSeance, string cineName, string filmTitre, string filmImage, int placeMax)
        {

            //Pour avoir le Com_Id de la personne connectée
            Compte compte = new Compte();
            compte = await GetCompte();

            TempData["Com_Id"] = compte.COM_Id;
            TempData["idSeance"] = idSeance;
            TempData["cineName"] = cineName;
            TempData["filmTitre"] = filmTitre;
            TempData["filmImage"] = filmImage;
            TempData["placeMax"] = placeMax;



            ViewBag.tarif = await PopulateTarifSeanceDropDownList(idSeance);

            return View();
        }
      


        //POST /Ticket/create
        [HttpPost]
        public async Task<IActionResult> Create(ReservationModel reservationModel)
        {
            reservationModel.Com_Id = (int)TempData["Com_Id"];

            reservationModel.nbrDeplaceMax = (int)TempData["placeMax"];

            reservationModel.idSeance = (int)TempData["idSeance"];

           

            return RedirectToAction("Buy" ,reservationModel);

        }

        // populer la liste des tarifSeances

        private async Task<Dictionary<Decimal, string>> PopulateTarifSeanceDropDownList(int idSeance)
        {
            
            accessToken = await managementAccessToken();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            //using var request = await httpClient.GetAsync($"https://localhost:44343/api/TarifSeance/GetAllTypeTarifbySeance/{idSeance}");
            using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/TarifSeance/GetAllTypeTarifbySeance/{idSeance}");

            string response = await request.Content.ReadAsStringAsync();

            var tarifSeanceQuery = JsonConvert.DeserializeObject<List<ReservationModel>>(response);
            
            var itemDictionnary = new Dictionary<Decimal, string>();
            foreach (var item in tarifSeanceQuery)
            {
                itemDictionnary.Add(item.Tarif.ElementAt(0).Key, item.Tarif.ElementAt(0).Value);
            }

     
            return itemDictionnary;

        }



        //GET /Ticket/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/Ticket/{id}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Ticket/{id}");

            }

            return Redirect(Request.Headers["Referer"].ToString());
        }


        // Pour retirer un compte
        private async Task<Compte> GetCompte()
        {
            string name = "";

            Compte compte = new Compte();

            if (User.Identity.IsAuthenticated)
            {
                string idToken = await HttpContext.GetTokenAsync("id_token");

                var stream = idToken;
                var handler = new JwtSecurityTokenHandler();
                var jsontoken = handler.ReadToken(stream);
                var token = jsontoken as JwtSecurityToken;
                name = token.Claims.First(claim => claim.Type == "name").Value;

            }
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Compte/{name}");
            using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Compte/{name}");

            string response = await request.Content.ReadAsStringAsync();

            compte = JsonConvert.DeserializeObject<Compte>(response);

            return compte;
        }

        //private async Task<string> GetEmail()
        //{
        //    accessToken = await managementAccessToken();
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var bearer = Request.Headers["Authorization"].ToString();
        //        client.DefaultRequestHeaders.Add("authorization", "Bearer " + accessToken);
        //        HttpResponseMessage response = await client.GetAsync($"https://{Configuration["Auth0:Domain"]}/userinfo"); if (response.IsSuccessStatusCode)
        //        {
        //            var sResp = await response.Content.ReadAsStringAsync();
        //            var values = JsonConvert.DeserializeObject<Dictionary<string,string>>(sResp);
        //            name = values["email"];
        //        }
        //    }

        //    return name;

        //}
    }

}

