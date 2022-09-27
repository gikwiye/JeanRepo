using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class RealisateurController : Controller
    {
        string accessToken;

        public async Task<string> managementAccessToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return accessToken;

        }

        //GET/Realisateur   tous les realisateurs
        public async Task<IActionResult> Index()
        {

            accessToken = await managementAccessToken();

            List<Realisateur> LesRealisateurs = new List<Realisateur>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync("https://localhost:44343/api/Realisateur");

                string response = await request.Content.ReadAsStringAsync();

                LesRealisateurs = JsonConvert.DeserializeObject<List<Realisateur>>(response);
            }

            return View(LesRealisateurs);
        }

        //GET/Realisateur/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            accessToken = await managementAccessToken();

            Realisateur realisateur = new Realisateur();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/Realisateur/{id}");

                string response = await request.Content.ReadAsStringAsync();

                realisateur = JsonConvert.DeserializeObject<Realisateur>(response);
            }

            return View(realisateur);
        }

        //POST/Realisateur/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Realisateur realisateur)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(realisateur), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.PutAsync($"https://localhost:44343/api/Realisateur/{realisateur.REA_Id}", content);

            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        // GET/Realisateur/create

        public IActionResult Create() => View();


        //POST /Realisateur/create
        [HttpPost]
        public async Task<IActionResult> Create(Realisateur realisateur)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(realisateur), Encoding.UTF8, "application/json");

                using var request = await httpClient.PostAsync($"https://localhost:44343/api/Realisateur", content);

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

                using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/Realisateur/{id}");

            }

            return RedirectToAction("Index");
        }
    }
}
