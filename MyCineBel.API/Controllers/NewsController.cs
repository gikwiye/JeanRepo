using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCineBel.API.Models;
using MyCineBel.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService )
        {
            _newsService = newsService;
        }

        /// <summary>
        /// Retourner tous les news
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // GET api/News afficher tous les news
        public async Task<ActionResult<List<News>>> GetAllNews()
        {
            var news = await _newsService.GetAllNewsAsync();

            return news;
        }
        /// <summary>
        /// Retourner un news par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        //GET api/news/5  afficher une nouvelle
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var news = await _newsService.GetNewsAsync(id);

            if (news == null)
            {
                return NotFound();
            }
            else
            {
                return news;
            }
        }
        /// <summary>
        /// Retourner la news la plus récente sur la Home Page
        /// </summary>
        /// <returns></returns>
        [HttpGet("HomeNews")]
        //GET api/News/homeNews afficher la nouvelle sur la  page home
        public async Task<ActionResult<News>> HomeNews()
        {
            var news = await _newsService.GetNewsAsync();

            if (news == null)
            {
                return NotFound();
            }
            else
            {
                return news;
            }
        }
        /// <summary>
        /// Creer une news
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>

        [HttpPost]
        //POST api/news
        public async Task<ActionResult<News>> PostNews(News news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.PostNewsAsync(news);
            }


            return CreatedAtAction(nameof(PostNews), news);
        }
        /// <summary>
        /// Mettre à jour une news
        /// </summary>
        /// <param name="id"></param>
        /// <param name="news"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        //PUT api/news/id  mettre à jour une nouvelle
        public async Task<ActionResult<Tarif>> PutNews(int id, News news)
        {
            if (id != news.NEWS_Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _newsService.PutNewsAsync(news);
            }


            return NoContent();
        }
        /// <summary>
        /// mettre à jour une news
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        // Delete  api/news/id  supprimer une nouvelle
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            await _newsService.DeleteNewsAsync(id);

            return NoContent();
        }
    }
}
