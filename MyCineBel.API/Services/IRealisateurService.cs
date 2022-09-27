using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface IRealisateurService
    {
        Task<List<Realisateur>> GetAllRealisateurAsync();

        Task<Realisateur> GetRealisateurAsync(int REA_Id);

        Task<Realisateur> PostRealisateurAsync(Realisateur realisateur);

        Task<Realisateur> PutRealisateurAsync(Realisateur realisateur);

        Task DeleteRealisateurAsync(int REA_Id);
    }
}
