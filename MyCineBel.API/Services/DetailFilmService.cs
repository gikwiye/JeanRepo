using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class DetailFilmService : IDetailFilmService
    {

        private readonly ProjetMyCinebelContext _context;
        public DetailFilmService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //Retourner la liste des acteurs pour un film
        public async Task<List<Acteur>> GetActeur(int filmId)
        {
            var ListActeur = await _context.Acteurs.FromSqlRaw($"SelectActeurs {filmId}").ToListAsync();

            return ListActeur;
        }

        //retourner un film
        public async Task<Film> GetFilmAsync(int id)
        {
            var film = await _context.Films.FirstOrDefaultAsync(X => X.Film_Id == id);

            return film;
        }


    }
}
