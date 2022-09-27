using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class TarifSeanceService : ITarifSeanceService
    {
        private readonly ProjetMyCinebelContext _context;
        public TarifSeanceService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

       //supprimer un tarifseance
        public async Task DeleteTarifseanceAsync(int id)
        {
            var tarifSeance = await _context.TarifSeances.FindAsync(id);

            if (tarifSeance != null)
            {
                _context.TarifSeances.Remove(tarifSeance);
            }

            await _context.SaveChangesAsync();
        }

        //Recupérer tous les tarifSeance pour une seance précise
        public async Task<List<TarifSeance>> GetAllTarifBySeanceAsync(int idSeance)
        {

            var Tarifs = await _context.TarifSeances.Include(y =>y.tarif).Where(X => X.TarSea_Sea_Id== idSeance).ToListAsync();

            return Tarifs;

        }

        //avoir toutes les types de seance
        public async Task<List<ReservationModel>> GetAllTypeTarifbySeance(int idSeance)
        {
            var TypeTarif = await (from Sea in _context.Seances join Ta in _context.TarifSeances on Sea.SEA_Id equals Ta.TarSea_Sea_Id
                                   join Tari in _context.Tarifs on Ta.TarSea_TAR_Id equals Tari.TAR_Id
                                   where Sea.SEA_Id == idSeance
                                   select new ReservationModel { idSeance = Ta.TarSea_Sea_Id,TarSea_Id = Ta.TarSea_Id,Tarif = new Dictionary<Decimal, string>() { { Ta.TarSea_Prix, Tari.TAR_Libelle } } }).ToListAsync();

            return TypeTarif;
        }

        //avoir  un tarifSeance
        public async Task<TarifSeance> GetTarifSeanceAsync(int id)
        {
            var tarifSeance = await _context.TarifSeances.FirstOrDefaultAsync(x => x.TarSea_Id == id);
            return tarifSeance;
        }

        //Créer un tarifSeance
        public async Task<TarifSeance> PostTarifSeanceAsync(TarifSeance tarifSeance)
        {
            _context.TarifSeances.Add(tarifSeance);

            await _context.SaveChangesAsync();

            return tarifSeance;
        }

        //mettre à jour les tarifSeances
        public async Task<TarifSeance> PutTarifSeanceAsync(TarifSeance  tarifSeance)
        {
            _context.Entry(tarifSeance).State = EntityState.Modified;

            await  _context.SaveChangesAsync();

            return tarifSeance;
        }
    }
}
