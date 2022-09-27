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
    public class SeanceController : ControllerBase
    {
        private readonly ISeanceService _seanceService;
        public SeanceController(ISeanceService seanceService)
        {
           _seanceService = seanceService;
        }
        /// <summary>
        /// Retourne les seances par cinema, par film et par date
        /// </summary>
        /// <param name="idCine"></param>
        /// <param name="filmId"></param>
        /// <param name="date"></param>
        /// <returns></returns>

        [HttpGet("{idCine}/{filmId}/{date}")]
        public async Task<ActionResult<List<ProcFilmSeance>>> SeanceByCinemaAndDate(int idCine,int filmId, DateTime date)
        {

            var seance = await _seanceService.GetSeanceByCinemaAndDate(idCine,filmId, date);

            if (seance != null)
            {
                return seance;
            }

            else return NoContent();

        }
        /// <summary>
        /// Afficher les seances futures  par cimema
        /// </summary>
        /// <param name="idCine"></param>
        /// <param name="date"></param>
        /// <returns></returns>

        [HttpGet("Film/{idCine}/{date}")]
        //GET api/Seance/{idCine}/{filmId}/{date}  afficher les seances à venir par cinema
        public async Task<ActionResult<List<ProcfilmCinema>>> FilmByCinemaAndDate(int idCine, DateTime date)
        {

            var film = await _seanceService.GetFilmByCinema(idCine, date);

            if (film != null)
            {
                return film;
            }

            else return NoContent();

        }

        /// <summary>
        /// Retourner une seance par son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        //GEt api/Seance/5 afficher une seance  
        public async Task<ActionResult<Seance>> Seance(int id)
        {

            var seance = await _seanceService.GetSeanceAsync(id);

            return seance;
        }

        /// <summary>
        /// Creer une seance
        /// </summary>
        /// <param name="seance"></param>
        /// <returns></returns>

        [HttpPost]
        //POST api/seance  creer une seance
        public async Task<ActionResult<Seance>> PostSeance(Seance seance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // enregister la seance dans la db
                    await _seanceService.PostSeanceAsync(seance);
                }


                // renvoyer la page
                return CreatedAtAction(nameof(PostSeance), seance);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return NoContent();
            }

        }
        /// <summary>
        /// Supprimer une seance
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("{Id}")]
        //Delete api/Seance/5
        public async Task<ActionResult<Seance>> DeleteSeance(int Id)
        {
            await _seanceService.DeleteSeanceAsync(Id);

            return NoContent();
        }
        /// <summary>
        /// Mettre à jour une seance
        /// </summary>
        /// <param name="seance"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        //PUT api/Seance/id  mettre à jour une seance
        public async Task<ActionResult<Seance>> PutSeance(Seance seance)
        {
            if(ModelState.IsValid)
            {
                await _seanceService.PutSeanceAsync(seance);
            }
           

            return NoContent();

        }
    }
}
