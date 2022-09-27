using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class CinemaService:ICinemaService
    {
        private readonly ProjetMyCinebelContext _context;
        public CinemaService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //effacer un acteur
        public async Task DeleteCinemaAsync(int id)
        {

            var cineId = new SqlParameter("@cinemaId", id);

            await _context.Database.ExecuteSqlRawAsync(
              "exec Delete_Cinema @cinemaId",
              cineId
              );

            
        }


        // retirer tous les cinemas
        public async Task<List<Cinema>> GetAllCinemaAsync()
        {
            var lst = await _context.Cinemas.FromSqlRaw("SelectAllCinema").ToListAsync();

            return lst;
        }

        //Retirer un cinema
        public async Task<IEnumerable<Cinema>> GetCinemaAsync(int cinemaId)
        {
            var cineId = new SqlParameter("@cinemaId", cinemaId);
            //var cinema = await _context.Cinemas.FromSqlRaw("Get_Cinema", cinemaId).FirstAsync(x => x.CIN_Id == cinemaId);
            var cinema =  await _context.Cinemas.FromSqlRaw(" EXECUTE Get_Cinema @cinemaId", cineId).ToListAsync();

            return cinema;
        }

        //public async Task<Cinema> GetCinemaAsync(int cinemaId)
        //{
        //    //var cineId = new SqlParameter("@cinemaId", cinemaId);
        //    //var cinema = await _context.Cinemas.FromSqlRaw("Get_Cinema", cinemaId).FirstAsync(x => x.CIN_Id == cinemaId);
        //    //var cinema = _context.Cinemas.FromSqlRaw(" EXECUTE Get_Cinema @cinemaId", cinemaId).AsEnumerable();


        //    var cinema = await _context.Cinemas.FirstOrDefaultAsync(X => X.CIN_Id == cinemaId);

        //    return cinema;
        //}

        //retirer un cinema suivant un compte de gestion
        public async Task<Cinema> GetCinemaAvecCompteAsync(int CompteId)
        {
            var cinema = await (from Co in _context.Comptes
                                join Ci in _context.Cinemas on Co.COM_Cin_Id equals Ci.CIN_Id
                                where Ci.CIN_Id == CompteId
                                select new Cinema
                                {
                                    CIN_Id = Ci.CIN_Id,
                                    CIN_Name = Ci.CIN_Name,
                                    CIN_Photo = Ci.CIN_Photo,
                                    CIN_CodePostal = Ci.CIN_CodePostal,
                                    CIN_Rue = Ci.CIN_Rue,
                                    CIN_Ville = Ci.CIN_Ville
                                }).FirstOrDefaultAsync();

            return cinema;
        }

        //créer un cinema
        public async Task<Cinema> PostCinemaAsync(Cinema cinema)
        {
            var name = new SqlParameter("@name", cinema.CIN_Name);
            var photo = new SqlParameter("@photo", cinema.CIN_Photo);
            var ville = new SqlParameter("@ville", cinema.CIN_Ville);
            var rue = new SqlParameter("@rue", cinema.CIN_Rue);
            var codePostal = new SqlParameter("@codePostal", cinema.CIN_CodePostal);

            var cinemaId = new SqlParameter("@id", SqlDbType.Int);

            cinemaId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
                "exec Add_Cinema @name, @photo, @ville, @rue, @codePostal, @id out ",
                name,
                photo,
                ville,
                rue,
                codePostal,
                cinemaId

                );

            return cinema;
        }

        //mettre à jour un cinema
        public async Task<Cinema> PutCinemaAsync(Cinema cinema)
        {
            // avec entityframework
            //_context.Entry(cinema).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            var cinemaId = new SqlParameter("@id", cinema.CIN_Id);
            var name = new SqlParameter("@name", cinema.CIN_Name);
            var photo = new SqlParameter("@photo", cinema.CIN_Photo);
            var ville = new SqlParameter("@ville", cinema.CIN_Ville);
            var rue = new SqlParameter("@rue", cinema.CIN_Rue);
            var codePostal = new SqlParameter("@codePostal", cinema.CIN_CodePostal);

            //var cineId = new SqlParameter("@idbis", SqlDbType.Int);

            //cineId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
              "exec Update_Cinema @id, @name, @photo, @ville, @rue, @codePostal ",
              cinemaId,
              name,
              photo,
              ville,
              rue,
              codePostal
              );

            return cinema;
        }
    }
}
