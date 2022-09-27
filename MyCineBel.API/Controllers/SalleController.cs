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
    public class SalleController : ControllerBase
    {
        private readonly ISalleService _SalleService;
        public SalleController(ISalleService SalleService)
        {
            _SalleService = SalleService;
        }
        /// <summary>
        /// Retourner tous les salles
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        // GET api/Salle
        public async Task<ActionResult<List<Salle>>> AllSalles()
        {
            List<Salle> laLIste = new List<Salle>();

            laLIste = await _SalleService.GetAllSalleAsync();

            return laLIste;
        }
        /// <summary>
        /// Retourner une salle par son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        //GEt api/Salle/5
        public async Task<ActionResult<Salle>> Salle(int id)
        {

            var salle = await _SalleService.GetSalleAsync(id);
            if (salle == null)
            {
                return NotFound();

            }
            else
            {
                return salle;
            }

        }
        /// <summary>
        /// Retourner les salles par cinema donc par gestionnaire
        /// </summary>
        /// <param name="cineId"></param>
        /// <returns></returns>
         //GEt api/Salle/MesSalles/5
        [HttpGet("MesSalles/{cineId}")]
        
        
        public async Task<ActionResult<List<Salle>>> MesSalles(int cineId)
        {

            var salle = await _SalleService.GetSalleByCinema(cineId);

            if (salle == null)
            {
                return NotFound();

            }
            else
            {
                return salle;
            }

        }
        /// <summary>
        /// Créer une nouvelle salle
        /// </summary>
        /// <param name="salle"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ActionResult<Salle>> postSalle(Salle salle)
        {
            if(ModelState.IsValid)
            {
                await _SalleService.PostSalleAsync(salle);
            }
            

            return CreatedAtAction(nameof(postSalle), salle);
        }
        /// <summary>
        /// Mettre à jour une salle
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="salle"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]

        //PUT api/Salle/5
        public async Task<ActionResult<Salle>> PutSalle(int Id, Salle salle)
        {
            if (Id != salle.SAL_Id)
            {
                return BadRequest();
            }
            if(ModelState.IsValid)
            {
                await _SalleService.PutSalleAsync(salle);
            }
          

            return NoContent();

        }
        /// <summary>
        /// Supprimer une salle par son Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        //Delete api/Salle/5
        public async Task<ActionResult<Salle>> DeleteSalle(int Id)
        {
            await _SalleService.DeleteSalleAsync(Id);

            return NoContent();
        }
    }
}
