using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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

namespace MyCineBel.Client.Controllers
{
    public class FilmController : Controller
    {
        string accessToken;
      
        public FilmController(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public IConfiguration _Configuration { get; }

        

        public async Task<string> managementAccessToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return accessToken;

        }

  

        // GET: FilmController
        public async Task<IActionResult> Index()
        {
            accessToken = await managementAccessToken();

            List<Film> mesFilms = new List<Film>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync("https://localhost:44343/api/Film");
                //using var request = await httpClient.GetAsync("http://mycinebelapi:8082/api/Film");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Film");

                string response = await request.Content.ReadAsStringAsync();

                mesFilms = JsonConvert.DeserializeObject<List<Film>>(response);
            }

           
            return View(mesFilms);
           
        }

      
     
        // GET: Film/Details/5
        public async Task <ActionResult> Details(int id)
        {
            accessToken = await managementAccessToken();

            Film film = new Film();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Film/{id}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Film/{id}");

                string response = await request.Content.ReadAsStringAsync();

                film = JsonConvert.DeserializeObject<Film>(response);
            }

            ViewBag.NameRealisateur = await GetRealisateurName(film.Film_Rea_Id);

            return View(film);
        }

      


        
 


        //GET/Realisateur/5   
        private async Task<string> GetRealisateurName(int id)
        {

            accessToken = await managementAccessToken();

            Realisateur realisateur = new Realisateur();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Realisateur/{id}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Realisateur/{id}");

                string response = await request.Content.ReadAsStringAsync();

                realisateur = JsonConvert.DeserializeObject<Realisateur>(response);
            }

            string name = realisateur.REA_Nom;

            return name;
        }
    }
}
