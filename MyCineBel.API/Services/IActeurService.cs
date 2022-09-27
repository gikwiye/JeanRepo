using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
   public  interface IActeurService
    {
        Task<List<Acteur>> GetAllActeurAsync();

        Task<Acteur> GetActeurAsync(int ActeurId);

        Task<Acteur> PostActeurAsync(Acteur acteur);

        Task<Acteur> PutActeurAsync(Acteur acteur);

        Task DeleteActeurAsync(int ActeurId);
    }
}
