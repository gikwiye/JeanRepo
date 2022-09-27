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
    public class CompteController : ControllerBase
    {
        private readonly ICompteService _compteService;

        public CompteController(ICompteService compteService)
        {
            _compteService = compteService;
        }
        /// <summary>
        /// Retirer un compte au moyen d'une adresse email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        //GET api/compte/email
        //retirer compte avec son email
        [HttpGet("{email}")]
        
        public async Task<ActionResult<Compte>> GetCompte(string email)
        {
            var compte = await _compteService.GetCompteAsync(email);

            if (compte == null)
            {
                return NotFound();
            }
            else
            {
                return compte;
            }
        }
        /// <summary>
        /// POSTER un nouveau compte
        /// </summary>
        /// <param name="compte"></param>
        /// <returns></returns>
        //POST api/compte
        //creation d'un compte
        [HttpPost]
       
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            var name = await GetCompte(compte.COM_Email);

            if (name.Value == null && ModelState.IsValid)
            {
                await _compteService.PostCompteAsync(compte);

                return CreatedAtAction(nameof(PostCompte), compte);
            }


            else return NoContent();
        }
        /// <summary>
        /// mettre à jour un compte
        /// </summary>
        /// <param name="id"></param>
        /// <param name="compte"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Compte>> PutCompte(int id, Compte compte)
        { 
            // ne pas mettre à jour l'email

            if (id != compte.COM_Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _compteService.PutCompteAsync(compte);
            }
            return NoContent();
        }
        /// <summary>
        /// Supprimer un compte
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE api/compte/id
        //supprimer un compte
        [HttpDelete("{id}")]
       
        public async Task<ActionResult<Compte>> DeleteCompte(int id)
        {
            await _compteService.DeleteCompteAsync(id);

            return NoContent();
        }
    }
}
