using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
     public  interface IFilmService
    {
        Task<List<Film>> GetAllFilmAsync();

        Task<List<Film>> GetNouveaute();

        Task<Film> GetFilmAsync(int id);

        Task<Film> PostFilmAsync(Film film);

        Task<Film> PutFilmAsync(Film film);

        Task DeleteFilmAsync(int FilmId);
    }
}
