using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCineBel.API.Models;
using MyCineBel.API.Services;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly  IFilmService _FilmService;
        private readonly INewsService _NewsService;

        public HomeController(IFilmService FilmService, INewsService NewsService)
        {
            _FilmService = FilmService;
            _NewsService = NewsService;
        }

        /// <summary>
        /// Afficher la page Home
        /// </summary>
        /// <returns></returns>
        ///   // GET api/home
        // Afficher la page home
        [HttpGet]
      
        public async Task<ActionResult<HomePage>> GetHomePage()
        {
            List<Film> laLIste = new List<Film>();
            News laNews = new News();

            laLIste = await _FilmService.GetNouveaute();

            laNews = await _NewsService.GetNewsAsync();



            var home = new HomePage { film = laLIste, news =laNews };

            return home;
        }
    }
}
