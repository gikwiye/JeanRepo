using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface ISeanceService
    {

        Task<List<Seance>> GetAllSeanceAsync();

        //Afficher les seances par cinema et par film
        Task<List<ProcFilmSeance>> GetSeanceByCinemaAndDate(int idCine,int filmId, DateTime date);

  
        Task<List<ProcfilmCinema>> GetFilmByCinema(int idCine, DateTime date);

        Task<Seance> GetSeanceAsync(int Sea_Id);

        //Ajouter une seance dans la DB
        Task<Seance> PostSeanceAsync(Seance seance);

        Task<Seance> PutSeanceAsync(Seance seance);

        Task DeleteSeanceAsync(int Sea_Id);
    }
}
