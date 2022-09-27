using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyCineBel.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCineBel.Client.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize(Roles = "Gestion")]
    public class SalleController : Controller
    {
        string accessToken;
        string name;
        public IConfiguration _Configuration { get; }

        public SalleController(IConfiguration Configuration)
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

        //GET/Salle   toutes mes salles
        public async Task<IActionResult> Index(int cineId)
        {
         
            accessToken = await managementAccessToken();

            Compte compte = new Compte();

            compte = await GetCompte();

            cineId = (int)compte.COM_Cin_Id;

            List<Salle> ListSalles = new List<Salle>();

         
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Salle/MesSalles/{cineId}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Salle/MesSalles/{cineId}");

                string response = await request.Content.ReadAsStringAsync();

                ListSalles = JsonConvert.DeserializeObject<List<Salle>>(response);

            }

            return View(ListSalles);
        }

        //GET/Salle/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            accessToken = await managementAccessToken();

            Salle salle = new Salle();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Salle/{id}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Salle/{id}");
                string response = await request.Content.ReadAsStringAsync();

                salle = JsonConvert.DeserializeObject<Salle>(response);
            }

            Cinema cinema = new Cinema();
            Compte compte = new Compte();


            compte = await GetCompte();
            int cineId = (int)compte.COM_Cin_Id;
            cinema = await PopulateCinema(cineId);
            ViewBag.cinema = cinema.CIN_Name;
            ViewBag.SAL_CIN_Id = cinema.CIN_Id;


           

            return View(salle);
        }

        //POST/Salle/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Salle salle)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(salle), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.PutAsync($"https://localhost:44343/api/Salle/{salle.SAL_Id}", content);
                using var request = await httpClient.PutAsync($"{_Configuration["MyCineBelApi"]}/api/Salle/{salle.SAL_Id}", content);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        // GET/Salle/create

        public async Task<IActionResult> Create() {

            Cinema cinema = new Cinema();
            Compte compte = new Compte();

            compte = await GetCompte();

           int  cineId = (int)compte.COM_Cin_Id;
           cinema   = await PopulateCinema(cineId);
            ViewBag.cinema = cinema.CIN_Name;
            ViewBag.SAL_CIN_Id = cinema.CIN_Id;

            return View();
        }


        //POST /Salle/create
        [HttpPost]
        public async Task<IActionResult> Create(Salle salle)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(salle), Encoding.UTF8, "application/json");

                //using var request = await httpClient.PostAsync($"https://localhost:44343/api/Salle", content);
                using var request = await httpClient.PostAsync($"{_Configuration["MyCineBelApi"]}/api/Salle", content);
                string response = await request.Content.ReadAsStringAsync();
            }

            return RedirectToAction("Index");
        }


        //GET /Film/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/Salle/{id}");
                using var request = await httpClient.DeleteAsync($"{_Configuration["MyCineBelApi"]}/api/Salle/{id}");
            }

            return RedirectToAction("Index");
        }

        


        // Trouver le cinema géré

        private async Task<Cinema> PopulateCinema(int compteId)
        {
            accessToken = await managementAccessToken();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Cinema/GetCinemaAvecCompteAsync/{compteId}");
            using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Cinema/GetCinemaAvecCompteAsync/{compteId}");

            string response = await request.Content.ReadAsStringAsync();

            var cinema = JsonConvert.DeserializeObject<Cinema>(response);

            return cinema;

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
    }
}

