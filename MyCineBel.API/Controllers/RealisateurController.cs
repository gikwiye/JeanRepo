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
    public class RealisateurController : ControllerBase
    {
        private readonly IRealisateurService _RealisateurService;

        public RealisateurController(IRealisateurService RealisateurService)
        {
            _RealisateurService = RealisateurService;
        }


        // GET api/Realisateur
        [HttpGet]
        public async Task<ActionResult<List<Realisateur>>> AllRealisateurs()
        {
            List<Realisateur> laLIste = new List<Realisateur>();

            laLIste = await _RealisateurService.GetAllRealisateurAsync();

            return laLIste;
        }

        [HttpGet("{id}")]
        //GEt api/FilmController/5
        public async Task<ActionResult<Realisateur>> Realisateur(int id)
        {

            var realisateur = await _RealisateurService.GetRealisateurAsync(id);

            return realisateur;
        }

        [HttpPost]
        // POST api/Realisateur  creer un realisateur
        public async Task<ActionResult<Realisateur>> postRealisateur(Realisateur realisateur)
        {
            if(ModelState.IsValid)
            {
                await _RealisateurService.PostRealisateurAsync(realisateur);
            }
           

            return CreatedAtAction(nameof(postRealisateur), realisateur);
        }

        [HttpPut("{Id}")]

        //PUT api/Realisateur/5 mettre à jour un réalisateur
        public async Task<ActionResult<Realisateur>> Put(int Id, Realisateur realisateur)
        {
            if (Id != realisateur.REA_Id)
            {
                return BadRequest();
            }
            if(ModelState.IsValid)
            {
                await _RealisateurService.PutRealisateurAsync(realisateur);
            }
           

            return NoContent();

        }

        [HttpDelete("{Id}")]
        //Delete  api/Realisateur/5  supprimer un réalisateur
        public async Task<ActionResult<Realisateur>> DeleteRealisateur(int Id)
        {
            await _RealisateurService.DeleteRealisateurAsync(Id);

            return NoContent();
        }
    }
}
