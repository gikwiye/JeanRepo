
using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class CompteService : ICompteService
    {
        private readonly ProjetMyCinebelContext _context;

        public CompteService(ProjetMyCinebelContext context)
        {
            _context = context;
        }
        //effacer un compte
        public async Task DeleteCompteAsync(int compteId)
        {
            var compte = await _context.Comptes.FindAsync(compteId);

            if(compte != null)
            {
                _context.Remove(compte);
            }

            await _context.SaveChangesAsync();


        }

        //public async Task<List<Compte>> GetCompteGestionAsync(int compteCineId)
        //{
        //    return await _context.Comptes.Where(X => X.COM_CIN_Id == compteCineId).ToListAsync();
        //}

        //public async Task<Compte> GetCompteAsync(int compteId)
        //{
        //    var compte = await _context.Comptes.FirstOrDefaultAsync(X => X.COM_Id == compteId);

        //    return compte;
        //}

        // retirer un compte au moyen d'un email
        public async Task<Compte> GetCompteAsync(string email)
        {
            var compte = await _context.Comptes.FirstOrDefaultAsync(X => X.COM_Email == email);

            return compte;
        }

        //créer un compte
        public async Task<Compte> PostCompteAsync(Compte compte)
        {
            

            _context.Comptes.Add(compte);

            await _context.SaveChangesAsync();

            return compte;
        }

        //mettre à jour un compte
        public async Task<Compte> PutCompteAsync(Compte compte)
        {
            //ne pas mettre à jour l'adresse email

            _context.Entry(compte).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return compte;
        }
    }
}
