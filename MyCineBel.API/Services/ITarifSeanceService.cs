using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface ITarifSeanceService
    {
        Task<List<TarifSeance>> GetAllTarifBySeanceAsync(int idSeance);

        Task<TarifSeance> GetTarifSeanceAsync(int id);

        Task<List<ReservationModel>> GetAllTypeTarifbySeance(int idSeance);

        Task<TarifSeance> PostTarifSeanceAsync(TarifSeance tarifSeance);

        Task<TarifSeance> PutTarifSeanceAsync(TarifSeance tarifSeance);

        Task DeleteTarifseanceAsync(int id);
    }
}
