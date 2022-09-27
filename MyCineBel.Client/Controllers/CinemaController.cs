using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyCineBel.Client.Models;
using MyCineBel.Client.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCineBel.Client.Controllers
{
    public class CinemaController : Controller
    {
        string accessToken;

        public IConfiguration _Configuration;
        public CinemaController(IConfiguration Configuration)
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



        // GET: Cinema tous les cinemas
        public async Task<IActionResult> Index()
        {
            accessToken = await managementAccessToken();

            List<Cinema> listeCinema = new List<Cinema>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync("https://localhost:44343/api/Cinema");
                //using var request = await httpClient.GetAsync("http://mycinebelapi:8082/api/Cinema");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Cinema");

                string response = await request.Content.ReadAsStringAsync();

                listeCinema = JsonConvert.DeserializeObject<List<Cinema>>(response);
            }


            return View(listeCinema);

        }


      
        //GET : seance by cinema

        [HttpGet]
        public async Task<IActionResult> getSeanceByCinemaAndDate(int idDuCine, int filmId)
        {
            int idCine = idDuCine;
            string date = DateTime.Now.ToString("yyyy/MM/dd");

            var cinema = await GetCinema(idCine);
            ViewBag.Cinephoto = cinema.Value.CIN_Photo;
            ViewBag.Cinename = cinema.Value.CIN_Name;

            //ViewBag.url = HttpContext.Request.GetEncodedUrl();
           

            accessToken = await managementAccessToken();

            List<ProcFilmSeance> listeSeance = new List<ProcFilmSeance>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Seance/{idCine}/{filmId}/{date}");
                var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Seance/{idCine}/{filmId}/{date}");

                string response = await request.Content.ReadAsStringAsync();

                listeSeance = JsonConvert.DeserializeObject<List<ProcFilmSeance>>(response);


            }
            return View(listeSeance);

        }

        //GET film by cinema and date
        public async Task<IActionResult> getFilmByCinemaAndDate(int idDuCine)
        {
            int idCine = idDuCine;
            string date = DateTime.Now.ToString("yyyy/MM/dd");

            var cinema = await GetCinema(idCine);
            ViewBag.Cinephoto = cinema.Value.CIN_Photo;
            ViewBag.Cinename = cinema.Value.CIN_Name;


            accessToken = await managementAccessToken();

            List<ProcFilmCinema> listeFilm = new List<ProcFilmCinema>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Seance/Film/{idCine}/{date}");

          
               //using var request = await httpClient.GetAsync($"https://mycinebelapi.azurewebsites.net/api/Seance/Film/{idCine}/{date}");
               using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Seance/Film/{idCine}/{date}");

               string response = await request.Content.ReadAsStringAsync();

                listeFilm = JsonConvert.DeserializeObject<List<ProcFilmCinema>>(response);                              

            }


            return View(listeFilm);

        }


        // GET: Cinema/5

        public async Task<ActionResult<Cinema>> GetCinema(int idCine)
        {
            accessToken = await managementAccessToken();

            List<Cinema> lesCinema = new List<Cinema>();

            Cinema cinema = new Cinema();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Cinema/{idCine}");
                using var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Cinema/{idCine}");

                string response = await request.Content.ReadAsStringAsync();

                lesCinema= JsonConvert.DeserializeObject<List<Cinema>>(response);

                cinema = lesCinema[0];
            }

        

            return cinema;
        }



    }
}
