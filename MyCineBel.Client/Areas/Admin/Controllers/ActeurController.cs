using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyCineBel.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCineBel.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ActeurController : Controller
    {
        string accessToken;

        public IConfiguration _Configuration { get; }

        public ActeurController(IConfiguration Configuration)
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

        //GET/Acteur   tous les acteurs
        public async Task<IActionResult> Index()
        {

            accessToken = await managementAccessToken();

            List<Acteur> LesActeurs = new List<Acteur>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync("https://localhost:44343/api/Acteur");
                var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Acteur");

                string response = await request.Content.ReadAsStringAsync();

                LesActeurs = JsonConvert.DeserializeObject<List<Acteur>>(response);
            }

            return View(LesActeurs);
        }

        //GET/Acteur/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            accessToken = await managementAccessToken();

            Acteur acteur = new Acteur();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Acteur/{id}");
                var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Acteur/{id}");


                string response = await request.Content.ReadAsStringAsync();

                acteur = JsonConvert.DeserializeObject<Acteur>(response);
            }

            return View(acteur);
        }

        //POST/Acteur/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Acteur acteur)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(acteur), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.PutAsync($"https://localhost:44343/api/Acteur/{acteur.ACT_Id}", content);
                var request = await httpClient.PostAsync($"{_Configuration["MyCineBelApi"]}/api/Acteur/{acteur.ACT_Id}", content);

              

            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

       // GET/Acteur/create

        public IActionResult Create() => View();


        //POST /Film/create
        [HttpPost]
        public async Task<IActionResult> Create(Acteur acteur)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(acteur), Encoding.UTF8, "application/json");

                //using var request = await httpClient.PostAsync($"https://localhost:44343/api/Acteur", content);

                var request = await httpClient.PostAsync($"{_Configuration["MyCineBelApi"]}/api/Acteur", content);

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

                //using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/Acteur/{id}");
                var request = await httpClient.DeleteAsync($"{_Configuration["MyCineBelApi"]}/api/Acteur/{id}");

            }

            return RedirectToAction("Index");
        }
    }
}
