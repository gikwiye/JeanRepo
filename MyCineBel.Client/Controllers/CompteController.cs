using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyCineBel.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;

namespace MyCineBel.Client.Controllers
{
    public class CompteController : Controller
    {
        string accessToken;

        string name;

        public IConfiguration _Configuration;

        public CompteController(IConfiguration Configuration)
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




        // GET: Compte
        // Retirer son propre compte
        public async Task<IActionResult> MonCompte()
        {
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");

                string idToken = await HttpContext.GetTokenAsync("id_token");

                var stream = idToken;
                var handler = new JwtSecurityTokenHandler();
                var jsontoken = handler.ReadToken(stream);
                var token = jsontoken as JwtSecurityToken;
                name = token.Claims.First(claim => claim.Type == "name").Value;
            }

            Compte compte = new Compte();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                //using var request = await httpClient.GetAsync($"https://localhost:44343/api/Compte/{name}");
                var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Compte/{name}");

                string response = await request.Content.ReadAsStringAsync();

                compte = JsonConvert.DeserializeObject<Compte>(response);
            }


            return View(compte);
        }

        //GET Compte/create
        public async Task<IActionResult> Create()
        {
            
            // Voir si la personne se trouve dans la DB via son adresse email
            ViewResult viewCompte = new ViewResult();
            viewCompte = (ViewResult)await this.MonCompte();
            Compte compte = new Compte();
            compte = (Compte)viewCompte.Model;

            if (compte.COM_Email == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    accessToken = await HttpContext.GetTokenAsync("access_token");


                    string idToken = await HttpContext.GetTokenAsync("id_token");

                    var stream = idToken;
                    var handler = new JwtSecurityTokenHandler();
                    var jsontoken = handler.ReadToken(stream);
                    var token = jsontoken as JwtSecurityToken;
                    name = token.Claims.First(claim => claim.Type == "name").Value;

                    ViewBag.email = name;

                    TempData["email"] = name;
                }

                return View();
            }

            
            else return RedirectToAction("index", "home");

        }



        //POST /Compte/create
        [HttpPost]
        public async Task<IActionResult> Create(Compte compte)
        {
            
            compte.COM_Email = TempData["email"].ToString();
            
            accessToken = await managementAccessToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(compte), Encoding.UTF8, "application/json");

                //using var request = await httpClient.PostAsync($"https://localhost:44343/api/Compte", content);
                var request = await httpClient.PostAsync($"{_Configuration["MyCineBelApi"]}/api/Compte", content);

                string response = await request.Content.ReadAsStringAsync();
            }

            return RedirectToAction("index","Home");
        }


       
    }
}
