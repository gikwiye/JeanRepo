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
    public class NewsController : Controller
    {
        string accessToken;

        IEnumerable<SelectListItem> maliste;

        public NewsController(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public IConfiguration _Configuration;

        public async Task<string> managementAccessToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return accessToken;

        }

        //GET/News   toutes les news
        public async Task<IActionResult> Index()
        {
            accessToken = await managementAccessToken();

            List<News> ListNews = new List<News>();

       
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync("https://localhost:44343/api/News");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/News");

                string response = await request.Content.ReadAsStringAsync();

                ListNews = JsonConvert.DeserializeObject<List<News>>(response);

            }

            return View(ListNews);
        }

        //GET/News/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            accessToken = await managementAccessToken();

            News news = new News();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/News/{id}");

                string response = await request.Content.ReadAsStringAsync();

                news = JsonConvert.DeserializeObject<News>(response);
            }

            //ViewBag.COM_Id = await PopulateCompteDropDownList(news.NEWS_COM_Id);

            return View(news);
        }

        //POST/News/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(News news)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(news), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);


            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        //GET News/create
        public async Task<IActionResult> Create()
        {
            Compte compte = new Compte();

            compte = await GetCompte();

            ViewBag.COM_Id = compte.COM_Id;


            return View();
        }

        //POST /News/create
        [HttpPost]
        public async Task<IActionResult> Create(News news)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(news), Encoding.UTF8, "application/json");

                using var request = await httpClient.PostAsync($"https://localhost:44343/api/News", content);

                string response = await request.Content.ReadAsStringAsync();
            }

            return RedirectToAction("Index");
        }


        //GET /News/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/News/{id}");

            }

            return RedirectToAction("Index");
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

            using var request = await httpClient.GetAsync($"https://localhost:44343/api/Compte/{name}");

            string response = await request.Content.ReadAsStringAsync();

            compte = JsonConvert.DeserializeObject<Compte>(response);

            return compte;
        }

       

    }
}
