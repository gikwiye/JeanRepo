using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    interface IDetailFilmService
    {
        Task<Film> GetFilmAsync(int id);
        Task<List<Acteur>> GetActeur(int filmId);
    }
}
