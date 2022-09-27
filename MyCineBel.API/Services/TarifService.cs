using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    
    public class TarifService : ITarifService
    {
        private readonly ProjetMyCinebelContext _context;

        public TarifService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //effacer les tarifs
        public async Task DeleteTarifAsync(int id)
        {
            var tarif = await _context.Tarifs.FindAsync(id);

            if (tarif != null)
            {
                _context.Tarifs.Remove(tarif);
            }

            await _context.SaveChangesAsync();
        }

        //avoir tous les types de tarifs
        public async Task<List<Tarif>> GetAllTarifAsync()
        {
            //return await _context.Tarifs.ToListAsync();

            return await _context.Tarifs.FromSqlRaw("SelectAllTarif").ToListAsync();
        }

        //retirer un tarif
        public async Task<Tarif> GetTarifAsync(int id)
        {
            var tarif = await _context.Tarifs.FirstOrDefaultAsync(x => x.TAR_Id == id);

            return tarif;
        }

        //Creer un tarif
        public  async Task<Tarif> PostTarifAsync(Tarif tarif)
        {
            _context.Tarifs.Add(tarif);

            await _context.SaveChangesAsync();

            return tarif;
        }

        //mettre à jour un tarif
        public async Task<Tarif> PutTarifAsync(Tarif tarif)
        {
            _context.Entry(tarif).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return tarif;
        }
    }
}
