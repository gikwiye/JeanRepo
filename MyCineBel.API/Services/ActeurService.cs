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
    public class ActeurService : IActeurService
    {
        private readonly ProjetMyCinebelContext _context;
        public ActeurService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //effacer un acteur
        public async Task DeleteActeurAsync(int ActeurId)
        {
            var acteur = await _context.Acteurs.FindAsync(ActeurId);

            if (acteur != null)
            {
                _context.Acteurs.Remove(acteur);
            }

            await _context.SaveChangesAsync();
        }

        // retirer un acteur précis
        public async Task<Acteur> GetActeurAsync(int ActeurId)
        {
            var acteur = await _context.Acteurs.FirstOrDefaultAsync(x => x.ACT_Id == ActeurId);

            return acteur;
        }

        //retirer tous les acteurs
        public async Task<List<Acteur>> GetAllActeurAsync()
        {

            var lst = await _context.Acteurs.FromSqlRaw("SelectAllActeurs").ToListAsync();

            return lst;
        }
        // Poster un acteur
        public async Task<Acteur> PostActeurAsync(Acteur acteur)
        {
            var nom = new SqlParameter("@nom", acteur.ACT_Nom);
            var prenom = new SqlParameter("@prenom", acteur.ACT_Prenom);

            var ActeurId = new SqlParameter("@Id", SqlDbType.Int);

            ActeurId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
                "exec Add_Acteur @nom, @prenom, @Id out ",
                nom,
                prenom,
                ActeurId
                );

            return acteur;
        }

        // mettre à jour un acteur
        public async Task<Acteur> PutActeurAsync(Acteur acteur)
        {
            _context.Entry(acteur).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return acteur;
        }
    }
}
