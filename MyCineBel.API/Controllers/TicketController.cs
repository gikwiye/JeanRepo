
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCineBel.API.Models;
using MyCineBel.API.Services;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        private IConverter _converter;

        public TicketController(ITicketService ticketService, IConverter converter)
        {
            _ticketService = ticketService;
            _converter = converter;

        }

       /// <summary>
       /// Retourner toutes les réservations par email
       /// </summary>
       /// <param name="email"></param>
       /// <returns></returns>
        //Recuperer toutes mes réservaions
        [HttpGet("{email}")]
        public async Task<ActionResult<List<ProcSelectMyReservation>>> GetReservation(string email)
        {

            return await _ticketService.GetReservation(email);
           
        }

        /// <summary>
        /// Récuperer une réservation par son Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        //Récuperer une réservation
        [HttpGet("GetMaReservation/{Id}")]
        public async Task<ActionResult<ProcSelectMyReservation>> GetMaReservation(int Id)
        {

            return await _ticketService.GetMaReservation(Id);

        }

        /// <summary>
        /// Douwnload a ticket
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //télecharger un ticket
        [HttpGet("CreatePDF/{Id}")]
        public IActionResult CreatePDF(int Id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                //Out = @"C:\Users\JEAN\Desktop\PDFCreator\monTicket"+$"{Id}"+".pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = _ticketService.GetHTMLString(Id),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);



            return File(file, "application/pdf", "ticket.pdf");
            
        }
        /// <summary>
        /// Réserver un ticket
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>

        [HttpPost("AddReservation")]
        public async Task<ActionResult>AddReservation([FromBody] ReservationModel reservation)
        {
            
                bool response = await _ticketService.AddReservation(reservation);

                if (response is true)
                {

                    return CreatedAtAction(nameof(AddReservation), reservation);
                }
                else
                {
                    return Ok(response);
                }
           
        }
        /// <summary>
        /// Supprimer un ticket
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        //Delete api/Ticket/5
        public async Task<ActionResult<Ticket>> DeleteTicket(int Id)
        {
            await _ticketService.DeleteTicketAsync(Id);

            return NoContent();
        }



    }
}
