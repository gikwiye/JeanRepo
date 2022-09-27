using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class SalleService : ISalleService
    {
        private readonly ProjetMyCinebelContext _context;
        public SalleService(ProjetMyCinebelContext context)
        {
            _context = context;
        }
        //Effacer une salle
        public async Task DeleteSalleAsync(int SalleId)
        {
            var salle = await _context.Salles.FindAsync(SalleId);
            if (salle != null)
            {
                _context.Salles.Remove(salle);
            }
            await _context.SaveChangesAsync();
        }

        //Retirer toutes les salles
        public async Task<List<Salle>> GetAllSalleAsync()
        {
            var lst = await _context.Salles.FromSqlRaw("SelectAllSalle").ToListAsync();

            return lst;
        }

        //Retier une salle
        public async Task<Salle> GetSalleAsync(int id)
        {
            var salle = await _context.Salles.Include(Ci => Ci.cinema).FirstOrDefaultAsync(x => x.SAL_Id == id);

            return salle;
        }
        //Retirer les salles pour un cinema
        public  async Task<List<Salle>> GetSalleByCinema(int cineId)
        {
            //var idDuCinema = new SqlParameter("@cinema", cineId);
            var salle = await (from CO in _context.Comptes join CI in _context.Cinemas on CO.COM_Cin_Id equals
                               CI.CIN_Id join SA in _context.Salles on CI.CIN_Id equals SA.SAL_CIN_Id
                               where SA.SAL_CIN_Id == cineId
                               select  new Salle  { SAL_Id = SA.SAL_Id,SAL_Name = SA.SAL_Name, SAL_Capacite = SA.SAL_Capacite, SAL_Climatise = SA.SAL_Climatise,
                                   SAL_3Dpossible = SA.SAL_3Dpossible, SAL_CIN_Id = cineId }).Distinct()

                              .ToListAsync();
            return salle;
        }

        //creer une salle
        public async Task<Salle> PostSalleAsync(Salle salle)
        {
            var name    = new SqlParameter("@name", salle.SAL_Name);
            var capacite = new SqlParameter("@capacite", salle.SAL_Capacite);
            var climatise = new SqlParameter("@climatise", salle.SAL_Climatise);
            var troisDpossible = new SqlParameter("@3Dpossible", salle.SAL_3Dpossible);
            var cineId = new SqlParameter("@cineId", salle.SAL_CIN_Id);


            var salleId = new SqlParameter("@id", SqlDbType.Int);

            salleId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
                "exec Add_Salle @name,@capacite, @climatise, @3Dpossible, @cineId, @id out ",
                 name,
                 capacite,
                 climatise,
                 troisDpossible,
                 cineId,
                 salleId
                );

            return salle;
        }

        //mette à jour une salle
        public async Task<Salle> PutSalleAsync(Salle salle)
        {
            //_context.Entry(salle).State = EntityState.Modified;

            //await _context.SaveChangesAsync();



            var salleId = new SqlParameter("@salleId", salle.SAL_Id);
            var name = new SqlParameter("@name", salle.SAL_Name);
            var capacite = new SqlParameter("@capacite", salle.SAL_Capacite);
            var climatise = new SqlParameter("@climatise", salle.SAL_Climatise);
            var TroisDpossible = new SqlParameter("@3Dpossible", salle.SAL_3Dpossible);
            var cineId = new SqlParameter("@cineId", salle.SAL_CIN_Id);


            await _context.Database.ExecuteSqlRawAsync(
              "exec Update_Salle @salleId,@name, @capacite, @climatise, @3Dpossible, @cineId ",
             salleId,
             name,
             capacite,
             climatise,
             TroisDpossible,
             cineId
              );

            return salle;
        }
    }
}
