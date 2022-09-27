using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

namespace MyCineBel.Client.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize(Roles = "Gestion")]
    public class SeanceController : Controller
    {
        string accessToken;
        IEnumerable<SelectListItem> malisteDeSalle;
        IEnumerable<SelectListItem> malisteDeFilms;

        public async Task<string> managementAccessToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return accessToken;

        }

        //Afficher les films d'un cinema donné 
        public async Task<IActionResult> Index(int idDuCine)
        {
            // Pour retirer le cinema géré par le gestionnaire
            Compte compte = new Compte();

            compte = await GetCompte();

            int idCine = (int)compte.COM_Cin_Id;

            
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            accessToken = await managementAccessToken();

            List<ProcFilmCinema> listeFilm = new List<ProcFilmCinema>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/Seance/Film/{idCine}/{date}");

                string response = await request.Content.ReadAsStringAsync();

                listeFilm = JsonConvert.DeserializeObject<List<ProcFilmCinema>>(response);
            }


            return View(listeFilm);

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


            accessToken = await managementAccessToken();

            List<ProcFilmSeance> listeSeance = new List<ProcFilmSeance>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/Seance/{idCine}/{filmId}/{date}");

                string response = await request.Content.ReadAsStringAsync();

                listeSeance = JsonConvert.DeserializeObject<List<ProcFilmSeance>>(response);
            }


            return View(listeSeance);

        }


        //GET/Seance/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            accessToken = await managementAccessToken();

            Seance seance = new Seance();

            //obtenir le compte en vue d'avoir les salles et les films par gestionnaire
            Compte compte = new Compte();

            compte = await GetCompte();

            int cineId = (int)compte.COM_Cin_Id;

            ViewBag.MesSalles = await PopulateMesSallesDropDownList(cineId);

            ViewBag.MesFilms = await PopulateFilmsDropDownList();



            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/Seance/{id}");

                string response = await request.Content.ReadAsStringAsync();

                seance = JsonConvert.DeserializeObject<Seance>(response);
            }

            return View(seance);
        }

        //POST/Seance/5 création d'une séance
        [HttpPost]
        public async Task<IActionResult> Edit(Seance seance)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(seance), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.PutAsync($"https://localhost:44343/api/seance/{seance.SEA_Id}", content);

            }

            return Redirect(Request.Headers["Referer"].ToString());
        }


        //GET/Seance/create

        public async Task<IActionResult> Create()
        {
            Compte compte = new Compte();

            compte = await GetCompte();

            int cineId = (int)compte.COM_Cin_Id;

            ViewBag.MesSalles = await PopulateMesSallesDropDownList(cineId);

            ViewBag.MesFilms = await PopulateFilmsDropDownList();

            return View();
        }
       


        //POST /Seance/create
        [HttpPost]
        public async Task<IActionResult> Create(Seance seance)
        {
            accessToken = await managementAccessToken();



            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(seance), Encoding.UTF8, "application/json");

                using var request = await httpClient.PostAsync($"https://localhost:44343/api/Seance", content);

                string response = await request.Content.ReadAsStringAsync();
                }

            return RedirectToAction("Index");
        }


        //GET /Seance/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/Seance/{id}");

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


        // populer la liste de mes salles

        private async Task<SelectList> PopulateMesSallesDropDownList(int cineId,object selectedSalle = null)
        {
            accessToken = await managementAccessToken();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            using var request = await httpClient.GetAsync($"https://localhost:44343/api/Salle/MesSalles/{cineId}");

            string response = await request.Content.ReadAsStringAsync();

            var sallequery = JsonConvert.DeserializeObject<List<Salle>>(response);

            malisteDeSalle = new SelectList(sallequery, "SAL_Id", "SAL_Name", selectedSalle);

            return (SelectList)malisteDeSalle;

        }

        //Pour populer ma liste de film
        private async Task<SelectList> PopulateFilmsDropDownList( object selectedFilm = null)
        {
            accessToken = await managementAccessToken();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            using var request = await httpClient.GetAsync("https://localhost:44343/api/Film"); ;

            string response = await request.Content.ReadAsStringAsync();

            var filmquery = JsonConvert.DeserializeObject<List<Film>>(response);

            malisteDeFilms = new SelectList(filmquery, "Film_Id", "Film_Titre", selectedFilm);

            return (SelectList)malisteDeFilms;

        }


        // GET: Cinema/5

        public async Task<ActionResult<Cinema>> GetCinema(int idCine)
        {
            accessToken = await managementAccessToken();

            Cinema cinema = new Cinema();

            List<Cinema> lesCinema = new List<Cinema>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/Cinema/{idCine}");

                string response = await request.Content.ReadAsStringAsync();

                lesCinema = JsonConvert.DeserializeObject<List<Cinema>>(response);

                cinema = lesCinema[0];

            }



            return cinema;
        }
    }
}
