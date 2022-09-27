using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface ISalleService
    {
        Task<List<Salle>> GetAllSalleAsync();

        Task<Salle> GetSalleAsync(int id);

        Task<List<Salle>> GetSalleByCinema(int cineId);

        Task<Salle> PostSalleAsync(Salle salle);

        Task<Salle> PutSalleAsync(Salle salle);

        Task DeleteSalleAsync(int SalleId);
    }
}
