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
    public class CinemaController : Controller
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

        //GET/Cinema   tous les cinemas
        public async Task<IActionResult> Index()
        {

            accessToken = await managementAccessToken();

            List<Cinema> LesCinemas = new List<Cinema>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync("https://localhost:44343/api/Cinema");

                string response = await request.Content.ReadAsStringAsync();

                LesCinemas = JsonConvert.DeserializeObject<List<Cinema>>(response);
            }

            return View(LesCinemas);
        }

        //GET/Cinema/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            accessToken = await managementAccessToken();

            Cinema cinema = new Cinema();
            List<Cinema> LesCinemas = new List<Cinema>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.GetAsync($"https://localhost:44343/api/Cinema/{id}");

                string response = await request.Content.ReadAsStringAsync();

                LesCinemas = JsonConvert.DeserializeObject<List<Cinema>>(response);

                cinema = LesCinemas[0];
            }

            return View(cinema);
        }

        //POST/Cinema/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Cinema cinema)
        {
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(cinema), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using var request = await httpClient.PutAsync($"https://localhost:44343/api/Cinema/{cinema.CIN_Id}", content);

            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        // GET/Cinema/create

        public IActionResult Create() => View();


     



        //POST /Film/create
        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            cinema.CIN_Photo = cinema.ImageUpload.FileName;

            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using (var multipartFormDataContent = new MultipartFormDataContent())
                {
                    var values = new[]
                    {
                          new KeyValuePair<string, string>("CIN_Name",cinema.CIN_Name),
                          new KeyValuePair<string, string>("CIN_Photo",cinema.CIN_Photo),
                          new KeyValuePair<string, string>("CIN_Ville", cinema.CIN_Ville),
                          new KeyValuePair<string, string>("CIN_Rue",cinema.CIN_Rue),
                          new KeyValuePair<string, string>("CIN_CodePostal",cinema.CIN_CodePostal.ToString()),
                          new KeyValuePair<string, string>("CIN_Ville", cinema.CIN_Ville),
                    };

                    foreach (var keyValuePair in values)
                    {
                        multipartFormDataContent.Add(new StringContent(keyValuePair.Value),
                            String.Format("\"{0}\"", keyValuePair.Key));
                    }
                    using (var ms = new MemoryStream())
                    {
                        cinema.ImageUpload.CopyTo(ms);

                        var fileBytes = ms.ToArray();


                        multipartFormDataContent.Add(new ByteArrayContent(fileBytes), cinema.ImageUpload.Name, cinema.ImageUpload.FileName);

                    }

                    var requestUri = "https://localhost:44343/api/Cinema";

                    var result = httpClient.PostAsync(requestUri, multipartFormDataContent).Result;
                }

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

                using var request = await httpClient.DeleteAsync($"https://localhost:44343/api/Cinema/{id}");

            }

            return RedirectToAction("Index");
        }
    }
}
