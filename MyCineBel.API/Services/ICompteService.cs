using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface ICompteService
    {
        //Task<List<Compte>> GetCompteGestionAsync(int compteCineId);

        //Task<Compte> GetCompteAsync(int compteId);

        Task<Compte> GetCompteAsync(string email);

        Task<Compte> PostCompteAsync(Compte compte);

        Task<Compte> PutCompteAsync(Compte compte);

        Task DeleteCompteAsync(int compteId);
    }
}
