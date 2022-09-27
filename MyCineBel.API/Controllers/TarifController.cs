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
    public class TarifController : ControllerBase
    {

        private readonly ITarifService _tarifService;

        public TarifController(ITarifService tarifService)
        {
            _tarifService = tarifService;
        }

        [HttpGet]
        //GET api/Tarif   afficher tous les tarifs
        public async Task<ActionResult<List<Tarif>>> GetAllTarifs()
        {
            var tarifs = await _tarifService.GetAllTarifAsync();

            return tarifs;
        }

        [HttpGet("{id}")]
        //GET api/Tarif/id    retirer un tarif précis
        public async Task<ActionResult<Tarif>> GetTarif(int id)
        {
            var tarif = await _tarifService.GetTarifAsync(id);

            if (tarif == null)
            {
                return NotFound();
            }
            else
            {
                return tarif;
            }
        }

        [HttpPost]
        //POST  api/tarif   créer un tarif
        public async Task<ActionResult<Tarif>> PostTarif(Tarif tarif)
        {
            if(ModelState.IsValid)
            {
                await _tarifService.PostTarifAsync(tarif);
            }
           

            return CreatedAtAction(nameof(PostTarif), tarif);
        }

        [HttpPut("{id}")]
        //PUT  api/tarif/id  mettre à jour un tarif
        public async Task<ActionResult<Tarif>> PutTarif(int id, Tarif tarif)
        {
            if (id!= tarif.TAR_Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _tarifService.PutTarifAsync(tarif);
            }
           

            return NoContent();
        }

        [HttpDelete("{id}")]
        //DELETE  api/tarif/id   effacer un tarif
        public async Task<ActionResult<Tarif>> DeleteTarif(int id)
        {
            await _tarifService.DeleteTarifAsync(id);

            return NoContent();
        }

        
    }
}
