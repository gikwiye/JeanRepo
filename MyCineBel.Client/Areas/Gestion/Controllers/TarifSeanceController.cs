using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCineBel.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCineBel.Client.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize(Roles = "Gestion")]
    public class TarifSeanceController : Controller
    {
        string accessToken;
        IEnumerable<SelectListItem> malisteTarif;

        public async Task<string> managementAccessToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return accessToken;

        }

        // GET: TarifSeance/idSeance
        public async Task<IActionResult> GetTarifBySeance(int id)
        {
            accessToken = await managementAccessToken();

            List<TarifSeance> listeTarif = new List<TarifSeance>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/TarifSeance/{id}");

                string response = await request.Content.ReadAsStringAsync();

                listeTarif = JsonConvert.DeserializeObject<List<TarifSeance>>(response);
            }

            ViewBag.seance = id;

            return View(listeTarif);
        }

        //Get TarifSeance/create
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.seance = id;
            ViewBag.tarif = await PopulateTarifDropDownList();

            return View();
        }

        //POST /TarifSeance/create
        [HttpPost]
        public async Task<IActionResult> Create(TarifSeance tarifSeance)
        {
            accessToken = await managementAccessToken();
            int id = tarifSeance.TarSea_Sea_Id;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(tarifSeance), Encoding.UTF8, "application/json");

                using var request = await httpClient.PostAsync($"https://localhost:44343/api/TarifSeance", content);

                string response = await request.Content.ReadAsStringAsync();
            }

            return RedirectToAction("GetTarifBySeance",new {id = id});

        }

        //Populer la liste déroulante des tarifs
        private async Task<SelectList> PopulateTarifDropDownList( object selectedSalle = null)
        {
            accessToken = await managementAccessToken();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            using var request = await httpClient.GetAsync($"https://localhost:44343/api/Tarif");

            string response = await request.Content.ReadAsStringAsync();

            var tarifquery = JsonConvert.DeserializeObject<List<Tarif>>(response);

            malisteTarif = new SelectList(tarifquery, "TAR_Id", "TAR_Libelle", selectedSalle);

            return (SelectList)malisteTarif;

        }


    }
}
