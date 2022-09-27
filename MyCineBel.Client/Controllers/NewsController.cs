using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyCineBel.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCineBel.Client.Controllers
{
    public class NewsController : Controller
    {
        string accessToken;
        public IConfiguration _Configuration;
        public NewsController(IConfiguration Configuration)
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
    }
}
