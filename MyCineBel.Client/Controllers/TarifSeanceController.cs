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
    public class TarifSeanceController : Controller
    {
        string accessToken;
        public IConfiguration _Configuration;
        public TarifSeanceController(IConfiguration Configuration)
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
        //pas encore implémenté
        // GET: TarifSeance/idSeance
        public async Task<IActionResult> GetTarifBySeance(int idSeance)
        {
            accessToken = await managementAccessToken();

            List<TarifSeance> listeTarif = new List<TarifSeance>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync("https://localhost:44343/api/TarifSeance/{idSeance}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/TarifSeance/{idSeance}");

                string response = await request.Content.ReadAsStringAsync();

                listeTarif = JsonConvert.DeserializeObject<List<TarifSeance>>(response);
            }


            return View(listeTarif);

        }
    }
}
