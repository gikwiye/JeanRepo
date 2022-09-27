using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCineBel.Client.Areas.Admin.Controllers;
using MyCineBel.Client.Models;
using MyCineBel.Client.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCineBel.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IConfiguration _Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _Configuration = Configuration;
        }

        string accessToken;
   
        public async Task <ActionResult<HomePage>> Index()
        {
           
            string name="";

         
            //If the user is authenticated, then this is how you can get the access_token and id_token
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind);

                string idToken = await HttpContext.GetTokenAsync("id_token");

                var stream = idToken;
                var handler = new JwtSecurityTokenHandler();
                var jsontoken = handler.ReadToken(stream);
                var token = jsontoken as JwtSecurityToken;
                name = token.Claims.First(claim => claim.Type == "name").Value;

                ViewBag.email = name;
            }

            var homePage = new HomePage();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var valeur = _Configuration["MyCineBelApi"];
                //using var request = await httpClient.GetAsync("https://localhost:44343/api/Home");
                //using var request = await httpClient.GetAsync("http://mycinebelapi:8082/api/Home");
                //using var request = await httpClient.GetAsync("https://mycinebelapi.azurewebsites.net/api/Home");

                var request = await httpClient.GetAsync($"{_Configuration["MyCineBelApi"]}/api/Home");

                string response = await request.Content.ReadAsStringAsync();

               homePage = JsonConvert.DeserializeObject<HomePage>(response);

            }

         

            return View(homePage);


           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
