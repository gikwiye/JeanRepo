using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _CinemaService;
        private readonly IBlobService _blobService;
        public CinemaController(ICinemaService CinemaService, IBlobService blobService)
        {
            _CinemaService = CinemaService;
            _blobService = blobService;
        }

        /// <summary>
        /// Retourne tous les cinemas
        /// </summary>
        /// <returns></returns>
        // GET api/Cinema  retirer tous les cinemas
        [HttpGet]
        public async Task<ActionResult<List<Cinema>>> AllCinema()
        {
            List<Cinema> laLIste = new List<Cinema>();

            laLIste = await _CinemaService.GetAllCinemaAsync();

            return laLIste;
        }
        /// <summary>
        /// Retourne un cinema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        //GEt api/Cinema/5  //retirer un cinema
        public async Task<ActionResult<IEnumerable<Cinema>>> Cinema(int id)
        {

            var cinema = await _CinemaService.GetCinemaAsync(id);

            if(cinema == null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }
        /// <summary>
        /// Retourne un cinema géré par le gestionnaire (Id du compte)
        /// </summary>
        /// <param name="CompteId"></param>
        /// <returns></returns>
        //GEt api/Cinema/5    Retirer un cinema géré par le gestionnaire ( id du compte)
        [HttpGet("GetCinemaAvecCompteAsync/{CompteId}")]
      
        public async Task<ActionResult<Cinema>> GetCinemaAvecCompteAsync(int CompteId)
        {

            var cinema = await _CinemaService.GetCinemaAvecCompteAsync(CompteId);

            if(cinema == null)
            {
                return NotFound();
            }

            return cinema;
        }
        /// <summary>
        /// POST un nouveau cinema
        /// </summary>
        /// <param name="cinema"></param>
        /// <returns></returns>
        [HttpPost]

        //POST api/cinema    poster un cinema
        public async Task<ActionResult<Cinema>> postCinema([FromForm]Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                //enregister le cinema dans la DB
                await _CinemaService.PostCinemaAsync(cinema);

                //enregistrer l'image dans le blobStorage

                string fileName = cinema.CIN_Photo;

                // save sur azure
                //await _blobService.UploadFileBlobAsync(filePath, fileName);
                await _blobService.UploadStreamBlobAsync(cinema.ImageUpload, fileName);
            }

            return CreatedAtAction(nameof(postCinema), cinema);
        }
        /// <summary>
        /// Mettre à jour un cinema avec son Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cinema"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]

        //PUT api/Cinema/5 mettre à jour un cinema
        public async Task<ActionResult<Realisateur>> Put(int Id, Cinema cinema)
        {
            if (Id != cinema.CIN_Id)
            {
                return BadRequest();
            }

            await _CinemaService.PutCinemaAsync(cinema);

            //enregistrer l'image dans le blobStorage

            string filmImagePath = "C:\\media";

            string fileName = cinema.CIN_Photo;

            string filePath = Path.Combine(filmImagePath, fileName);

            // save sur azure
            await _blobService.UploadFileBlobAsync(filePath, fileName);



            return NoContent();

        }
        /// <summary>
        /// supprimer un cinema
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //Delete api/cinema/5 supprimer un cinema
        [HttpDelete("{Id}")]

        public async Task<ActionResult<Cinema>> DeleteCinema(int Id)
        {

            await _CinemaService.DeleteCinemaAsync(Id);

            Cinema cinema = (Cinema)await _CinemaService.GetCinemaAsync(Id);

           

            string fileName = cinema.CIN_Photo;

            // supprimer sur azure
            await _blobService.DeleteBlobAsync(fileName);

            return NoContent();
        }
    }
}
