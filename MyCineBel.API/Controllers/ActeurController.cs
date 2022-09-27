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
    public class ActeurController : ControllerBase
    {
        private readonly IActeurService _ActeurService;

        public ActeurController(IActeurService acteurService)
        {
            _ActeurService = acteurService;
        }
        /// <summary>
        /// Retourne tous les acteurs
        /// </summary>
        /// <returns></returns>
        // GET api/Acteur
        [HttpGet]
        public async Task<ActionResult<List<Acteur>>> AllActeurs()
        {
            List<Acteur> laLIste = new List<Acteur>();

            laLIste = await _ActeurService.GetAllActeurAsync();

            return laLIste;
        }
        /// <summary>
        /// Retourne un acteur par son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
     
        //GEt api/Acteur/5
        [HttpGet("{id}")]
       
        public async Task<ActionResult<Acteur>> Acteur(int id)
        {
            
            var acteur = await _ActeurService.GetActeurAsync(id);
            if(acteur == null)
            {
                return NotFound();

            }
            else
            {
                return acteur;
            }

           
        }
        /// <summary>
        /// POST un acteur
        /// </summary>
        /// <param name="acteur"></param>
        /// <returns></returns>
       // POST api/Acteur   Poster un acteur
        [HttpPost]
        public async Task<ActionResult<Acteur>> postActeur(Acteur acteur)
        {
            if (ModelState.IsValid)
            {
                await _ActeurService.PostActeurAsync(acteur);
            }
            return CreatedAtAction(nameof(postActeur), acteur);
        }
        /// <summary>
        /// Mettre à jour un acteur
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="acteur"></param>
        /// <returns></returns>
      
        [HttpPut("{Id}")]

        //PUT api/Acteur/5  mettre à jour un acteur
        public async Task<ActionResult<Acteur>> PutActeur(int Id, Acteur acteur)
        {
            if (Id != acteur.ACT_Id)
            {
                return BadRequest();
            }

            if(ModelState.IsValid)
            {
                await _ActeurService.PutActeurAsync(acteur);
            }
            

            return NoContent();

        }
        /// <summary>
        /// Supprimer un acteur
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

      
        [HttpDelete("{Id}")]
        //Delete api/Acteur/5  supprimer un acteur
        public async Task<ActionResult<Acteur>> DeleteActeur(int Id)
        {
            await _ActeurService.DeleteActeurAsync(Id);

            return NoContent();
        }
    }
}
