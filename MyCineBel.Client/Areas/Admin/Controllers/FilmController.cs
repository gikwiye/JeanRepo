using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCineBel.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCineBel.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FilmController : Controller
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


        public async Task<IActionResult> Index()
        {
            
            accessToken = await managementAccessToken();

            List<Film> LesFilms = new List<Film>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync("https://localhost:44343/api/Film");

                string response = await request.Content.ReadAsStringAsync();

                LesFilms = JsonConvert.DeserializeObject<List<Film>>(response);
            }

            return View(LesFilms);
        }

        //GET/Film/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            accessToken = await managementAccessToken();

            Film film = new Film();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/Film/{id}");

                string response = await request.Content.ReadAsStringAsync();

                film = JsonConvert.DeserializeObject<Film>(response);
            }

            return View(film);
        }

        //POST/Film/5
        [HttpPost]
        public async Task<IActionResult> Edit(Film film)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.PutAsync($"https://localhost:44343/api/Film/{film.Film_Id}", content);

            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        //GET/Film/create

        public IActionResult Create() => View();


        //POST /Film/create
        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            film.Film_BandeAnnonce = film.BandeAnnonceUpload.FileName;
            film.Film_Image = film.ImageUpload.FileName;

            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using(var multipartFormDataContent = new MultipartFormDataContent())
                {
                    var values = new[]
                    {
                          new KeyValuePair<string, string>("Film_Titre",film.Film_Titre),
                          new KeyValuePair<string, string>("Film_Genre",film.Film_Genre),
                          new KeyValuePair<string, string>("Film_duree", film.Film_duree.ToString()),
                          new KeyValuePair<string, string>("Film_BandeAnnonce", film.Film_BandeAnnonce),
                          new KeyValuePair<string, string>("Film_DateSortie",film.Film_DateSortie.ToString()),
                          new KeyValuePair<string, string>("Film_Synopsis", film.Film_Synopsis),
                          new KeyValuePair<string, string>("Film_Image", film.Film_Image),
                          new KeyValuePair<string, string>("Film_Rea_Id", film.Film_Rea_Id.ToString())
                    };

                    foreach (var keyValuePair in values)
                    {
                        multipartFormDataContent.Add(new StringContent(keyValuePair.Value),
                            String.Format("\"{0}\"", keyValuePair.Key));
                    }

                    using (var ms = new MemoryStream())
                    {
                        film.BandeAnnonceUpload.CopyTo(ms);
                        
                        var fileBytes = ms.ToArray();

                        multipartFormDataContent.Add(new ByteArrayContent(fileBytes), film.BandeAnnonceUpload.Name, film.BandeAnnonceUpload.FileName);

                        film.ImageUpload.CopyTo(ms);

                        var fileBytesbis = ms.ToArray();

                        multipartFormDataContent.Add(new ByteArrayContent(fileBytesbis), film.ImageUpload.Name, film.ImageUpload.FileName);
                    }

                    using var request = await httpClient.PostAsync($"https://localhost:44343/api/Film",multipartFormDataContent);
                    string response = await request.Content.ReadAsStringAsync();
                    //var requestUri = "https://localhost:44343/api/Film/PostFilm";

                    //var result = httpClient.PostAsync(requestUri, multipartFormDataContent).Result;

                }

                //var content = new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json");

                //using var request = await httpClient.PostAsync($"https://localhost:44343/api/Film", content);

                //string response = await request.Content.ReadAsStringAsync();
            }

            //return RedirectToAction("Index");
            return Redirect(Request.Headers["Referer"].ToString());
        }


        //GET /Film/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/Film/DeleteFilm/{id}");

            }

            return RedirectToAction("Index");
        }


    }
}
