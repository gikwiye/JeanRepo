using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
  
    public class FilmService : IFilmService
    {
        private readonly ProjetMyCinebelContext _context;
       
        public FilmService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //Effacer un film
        public async Task DeleteFilmAsync(int FilmId)
        {
            var film = await _context.Films.FindAsync(FilmId);
            if (film != null)
            {
                _context.Films.Remove(film);
            }
            await _context.SaveChangesAsync();

        }

        // retourner tous les films
        public async Task<List<Film>> GetAllFilmAsync()
        {
            var lst = await _context.Films.FromSqlRaw("SelectAllFilms").ToListAsync();

            return lst;
        }

        // retirer les films nouveaux
        public async Task<List<Film>> GetNouveaute()
        {
            var lst = await _context.Films.FromSqlRaw("SelectNouveaute").ToListAsync();

            return lst;
        }
        //retirer un film

        public async Task<Film> GetFilmAsync(int FilmId)
        {

            var film = await _context.Films.FirstOrDefaultAsync(X => X.Film_Id == FilmId);

            return film;

        }

 

        //Création d'un nouveau film par l'admnistrateur
        public async Task<Film> PostFilmAsync(Film film)
        {
           
            var titre = new SqlParameter("@titre", film.Film_Titre);
            var genre = new SqlParameter("@genre", film.Film_Genre);
            var duree = new SqlParameter("@duree", film.Film_duree);
            var bandeAnnonce = new SqlParameter("@bandeAnnonce", film.Film_BandeAnnonce);
            var dateSortie = new SqlParameter("@dateSortie", film.Film_DateSortie);
            var synopsis = new SqlParameter("@synopsis", film.Film_Synopsis);
            var image = new SqlParameter("@image", film.Film_Image);
            var realisateur = new SqlParameter("@realisateur", film.Film_Rea_Id);

            var filmId = new SqlParameter("@id", SqlDbType.Int);

            filmId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
                "exec Add_Film @titre, @genre, @duree, @bandeAnnonce, @dateSortie, @synopsis, @image, @realisateur, @id out",
                titre,
                genre,
                duree,
                bandeAnnonce,
                dateSortie,
                synopsis,
                image,
                realisateur,
                filmId
                );

            return film;

        }

        //mettre à jour un film
        public async Task<Film> PutFilmAsync(Film film)
        {
            _context.Entry(film).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return film;
        }

    }
}
