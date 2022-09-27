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
    public class TarifSeanceController : ControllerBase
    {
        private readonly ITarifSeanceService _tarifSeanceService;
        public TarifSeanceController(ITarifSeanceService tarifSeanceService)
        {
            _tarifSeanceService = tarifSeanceService;
        }

        [HttpGet("{idSeance}")]
        //GET api/TarifSeance/idSeance  retirer pour une seance précise   
        public async Task<ActionResult<List<TarifSeance>>> GetTarifBySeance(int idSeance)
        {
            var tarifSeances = await _tarifSeanceService.GetAllTarifBySeanceAsync(idSeance);

            return tarifSeances;
        }


        [HttpGet("GetAllTypeTarifbySeance/{idSeance}")]
        //GET api/TarifSeance/GetAllTypeTarifbySeance/{idSeance} reitere tous les types de tarif pour une seance
        public async Task<ActionResult<List<ReservationModel>>> GetAllTypeTarifbySeance(int idSeance)
        {
            var AlltarifBySeance = await _tarifSeanceService.GetAllTypeTarifbySeance(idSeance);

            return AlltarifBySeance;
        }



        [HttpPost]
        //POST api/TarifSeance  créer un tarif
        public async Task<ActionResult<TarifSeance>> PostTarifSeance(TarifSeance tarifSeance)
        {
            if(ModelState.IsValid)
            {
                await _tarifSeanceService.PostTarifSeanceAsync(tarifSeance);
            }
            

            return CreatedAtAction(nameof(PostTarifSeance), tarifSeance);
        }
    }
}
