using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCineBel.API.Models;
using MyCineBel.API.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _FilmService;

        private readonly IBlobService _blobService;



        public FilmController(IFilmService FilmService, IBlobService blobService)
        {
            _blobService = blobService;
            _FilmService = FilmService;
        }

        /// <summary>
        /// Retourner tous les films
        /// </summary>
        /// <returns></returns>
        //GET api/Film  afficher tous les films
        [HttpGet]

        
        public async Task<ActionResult<List<Film>>> Films()
        {
            var films = await _FilmService.GetAllFilmAsync();

            return films;
        }
        /// <summary>
        /// Retourner les nouveaux films
        /// </summary>
        /// <returns></returns>
         //GET api/Film  afficher les nouveautés
        [HttpGet("FilmNouveau")]

       
        public async Task<ActionResult<List<Film>>> FilmNouveau()
        {
            var films = await _FilmService.GetNouveaute();

            return films;
        }


        /// <summary>
        /// Retourner un film par son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        //GEt api/Film/5   afficher un film par son id
        public async Task<ActionResult<Film>> Film(int id)
        {

            var film = await _FilmService.GetFilmAsync(id);

            return film;
        }
        /// <summary>
        /// Mettre à jour un film
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="film"></param>
        /// <returns></returns>

        [HttpPut("{Id}")]

        //PUT api/film/5 mettre à jour un film
        public async Task<ActionResult<Film>> Put(int Id, Film film)
        {
            if (Id != film.Film_Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                //mettre à jour azureBlobStorage

                await _FilmService.PutFilmAsync(film);

                string[] file = { film.Film_Image, film.Film_BandeAnnonce };

                foreach (var fileName in file)
                {
                    string filmImagePath = "C:\\media";

                    string filePath = Path.Combine(filmImagePath, fileName);

                    // save sur azure
                    await _blobService.UploadFileBlobAsync(filePath, fileName);
                }
            }
            return NoContent();



        }
        /// <summary>
        /// Creer un nouveau film
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        [HttpPost]
        //POST api/film
        public async Task<ActionResult<Film>> PostFilm([FromForm]Film film)
        {
            if (ModelState.IsValid)
            {
                // enregister le film dans la db
                await _FilmService.PostFilmAsync(film);

                // enregistrement dans le blobStorage

                string filename = film.Film_BandeAnnonce;

                await _blobService.UploadStreamBlobAsync(film.BandeAnnonceUpload, filename);

                string filenamebis = film.Film_Image;

                await _blobService.UploadStreamBlobAsync(film.ImageUpload, filenamebis);
            }
          
            // renvoyer la page
            return CreatedAtAction(nameof(PostFilm), film);
        }
        /// <summary>
        /// supprimer un film
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("DeleteFilm/{Id}")]
        //Delete /api/Film/5  supprimer un film
        public async Task<ActionResult<Film>> DeleteFilm(int Id)
        {
            Film film = await _FilmService.GetFilmAsync(Id);

            await _FilmService.DeleteFilmAsync(Id);

            //supprimer dans le blob 

            string[] file = { film.Film_Image, film.Film_BandeAnnonce };

            foreach (var item in file)
            {
                await _blobService.DeleteBlobAsync(item);
            }

            return NoContent();
        }

    }
}
