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
    public class RealisateurService : IRealisateurService
    {
        private readonly ProjetMyCinebelContext _context;
        public RealisateurService(ProjetMyCinebelContext context)
        {
            _context = context;
        }
        //effacer un réalisateur
        public async Task DeleteRealisateurAsync(int REA_Id)
        {
            var realisateur = await _context.Realisateurs.FindAsync(REA_Id);

            if (realisateur != null)
            {
                _context.Realisateurs.Remove(realisateur);
            }

            await _context.SaveChangesAsync();

        }

        //retirer tous les realisateurs
        public async Task<List<Realisateur>> GetAllRealisateurAsync()
        {
            var lst = await _context.Realisateurs.FromSqlRaw("SelectAllRealisateur").ToListAsync();

            return lst;
        }


        //retirer un realisateur précis
        public async Task<Realisateur> GetRealisateurAsync(int REA_Id)
        {
            var realisateur = await _context.Realisateurs.FirstOrDefaultAsync(X => X.REA_Id == REA_Id);

            return realisateur;
        }

        //creer un realisateur
        public async Task<Realisateur> PostRealisateurAsync(Realisateur realisateur)
        {
            var nom = new SqlParameter("@nom", realisateur.REA_Nom);
            var prenom = new SqlParameter("@prenom", realisateur.REA_Prenom);
            var nationalite = new SqlParameter("@nationalite", realisateur.REA_Nationalite);

            var realisateurId = new SqlParameter("@Id", SqlDbType.Int);

            realisateurId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
                "exec Add_Realisateur @nom, @prenom, @nationalite, @Id out ",
                nom,
                prenom,
                nationalite,
                realisateurId
                );

            return realisateur;
        }

        //mettre à jour un realisateur
        public async Task<Realisateur> PutRealisateurAsync(Realisateur realisateur)
        {
            _context.Entry(realisateur).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return realisateur;


        }
    }
}
