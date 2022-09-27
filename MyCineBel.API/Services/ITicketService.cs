using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
   public interface ITicketService
    {
        //Task<List<Ticket>> GetAllTicketfBySeanceAsync(int idSeance);

        //Task<ReservationModel> GetReservation(int idCine, int idFilm, int idSeance, int idUser);

        Task<ProcSelectMyReservation> GetMaReservation(int Id);

        Task<List<ProcSelectMyReservation>> GetReservation(string email);

        

        Task<bool> AddReservation(ReservationModel reservation);

        string GetHTMLString(int Id);

        Task DeleteTicketAsync(int TicketId);

    }
}
