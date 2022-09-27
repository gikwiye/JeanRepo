using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface ICinemaService
    {
        Task<List<Cinema>> GetAllCinemaAsync();

        Task<IEnumerable<Cinema>> GetCinemaAsync(int CinemaId);

        Task<Cinema> GetCinemaAvecCompteAsync(int CompteId);

        Task<Cinema> PostCinemaAsync(Cinema cinema);

        Task<Cinema> PutCinemaAsync(Cinema cinema);

        Task DeleteCinemaAsync(int cinemaId);
    }
}
