
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class SeanceService : ISeanceService
    {
        private readonly ProjetMyCinebelContext _context;
        public SeanceService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //effacer une seance
        public  async Task DeleteSeanceAsync(int Sea_Id)
        {
            var seance = await _context.Seances.FindAsync(Sea_Id);

            if (seance!= null)
            {
                _context.Seances.Remove(seance);
            }
            await _context.SaveChangesAsync();

        }

        //Retirer toutes les seances
        public Task<List<Seance>> GetAllSeanceAsync()
        {
            throw new NotImplementedException();
        }

        //Afficher les seances pour cinema et pour un film à partir d'aujourd'hui
        public async Task<List<ProcFilmSeance>> GetSeanceByCinemaAndDate(int idCine,int filmId, DateTime date)
        {

           

            var seance = await (from SE in _context.Seances
                                join SA in _context.Salles on SE.Sea_SAL_Id equals SA.SAL_Id
                                join Ci in _context.Cinemas on SA.SAL_CIN_Id equals
                                Ci.CIN_Id join fi in _context.Films on SE.Sea_Film_Id equals fi.Film_Id
                                where Ci.CIN_Id == idCine && SE.SEA_Date >= date && fi.Film_Id == filmId
                                select new ProcFilmSeance{seance=SE,CIN_Id = Ci.CIN_Id, CIN_Name= Ci.CIN_Name,CIN_Photo=Ci.CIN_Photo, Film_Image= fi.Film_Image ,filmTitre=fi.Film_Titre}).ToListAsync();

            // trouver l'id des seances concernées et calculer le nbr de tickets achetés.
         
            for(int i = 0; i<seance.Count; i++)
            {
                var idSeance = seance[i].seance.SEA_Id;

                var ListTickets = await (from SE in _context.Seances
                                         join Ta in _context.TarifSeances on SE.SEA_Id equals Ta.TarSea_Sea_Id
                                         join Ti in _context.Tickets on Ta.TarSea_Id equals Ti.TIC_TarSea_Id
                                         where (SE.SEA_Id == idSeance)
                                         select Ti.TIC_Id).ToListAsync();

                var placeMax = seance[i].seance.Sea_MaxPlace - ListTickets.Count;

                seance[i].seance.Sea_MaxPlace = placeMax;
            }

            // rajouter le film image

            return seance;

        }

       
        //afficher les films pour un cinema
        public async Task<List<ProcfilmCinema>> GetFilmByCinema(int idCine, DateTime date)
        {

            var film = await (from SE in _context.Seances
                                join SA in _context.Salles on SE.Sea_SAL_Id equals SA.SAL_Id
                                join Ci in _context.Cinemas on SA.SAL_CIN_Id equals Ci.CIN_Id
                                where Ci.CIN_Id == idCine && SE.SEA_Date >= date
                                join fi in _context.Films on SE.Sea_Film_Id equals fi.Film_Id
                           
                                select new ProcfilmCinema{CIN_Id = Ci.CIN_Id, CIN_Name = Ci.CIN_Name, CIN_Photo = Ci.CIN_Photo,
                                   FilmId = fi.Film_Id, Film_Image = fi.Film_Image, filmTitre = fi.Film_Titre, FilmbandeAnnocne = fi.Film_BandeAnnonce })
                                    .Distinct()
                                    .ToListAsync();
          

            return film;

        }

        //Retier une seance
        public  async Task<Seance> GetSeanceAsync(int id)
        {
            var seance = await _context.Seances.FirstOrDefaultAsync(x => x.SEA_Id == id);

            return seance;
        }


        //Poster une seance
        public async Task<Seance> PostSeanceAsync(Seance seance)
        {
            
         
            var date = new SqlParameter("@date", seance.SEA_Date);
            var heureDebut = new SqlParameter("@heureDebut", seance.SEA_HeureDebut);
            var nbrPlace = new SqlParameter("@nbrPlace", seance.Sea_MaxPlace);
            var idSalle = new SqlParameter("@idSalle", seance.Sea_SAL_Id);
            var idFilm = new SqlParameter("@idFilm", seance.Sea_Film_Id);

            var idSeance = new SqlParameter("@Id", SqlDbType.Int);

            idSeance.Direction = ParameterDirection.Output;

          
                await _context.Database.ExecuteSqlRawAsync(

                             "exec Add_Seance @date, @heureDebut,@nbrPlace,@idSalle,@idFilm,@Id out",
                              
                             date,
                             heureDebut,
                             nbrPlace,
                             idSalle,
                             idFilm,
                             idSeance
                             );
                return seance;
           
        }

        //mettre à jour une seance
        public async Task<Seance> PutSeanceAsync(Seance seance)
        {
            var idSeance = new SqlParameter("@idSeance", seance.SEA_Id);
            var date = new SqlParameter("@date", seance.SEA_Date);
            var heureDebut = new SqlParameter("@heureDebut", seance.SEA_HeureDebut);
            var maxPlace = new SqlParameter("@maxPlace", seance.Sea_MaxPlace);
            var idPlace = new SqlParameter("@idSalle", seance.Sea_SAL_Id);
            var idFilm = new SqlParameter("@idFilm", seance.Sea_Film_Id);
         

            //var cineId = new SqlParameter("@idbis", SqlDbType.Int);

            //cineId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
              "exec Update_Seance @idSeance, @date, @heureDebut, @maxPlace, @idSalle, @idFilm",
              idSeance,
               date,
               heureDebut,
               maxPlace,
               idPlace,
               idFilm
              );

            return seance;
        }

      


    }
}
