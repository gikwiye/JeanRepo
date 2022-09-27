using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface ITarifService
    {
        Task<List<Tarif>> GetAllTarifAsync();

        Task<Tarif> GetTarifAsync(int id);

        Task<Tarif> PostTarifAsync(Tarif tarif);

        Task<Tarif> PutTarifAsync(Tarif tarif);

        Task DeleteTarifAsync(int id);
    }
}
