using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.ViewModel
{
    public class ReservationModel
    {
        public string Cin_Name { get; set; }

        public string Cin_Photo { get; set; }

        public string Film_titre { get; set; }

        public string Film_Image { get; set; }

        public int TarSea_Id { get; set; }

        public Dictionary<Decimal, string> Tarif { get; set; } = new Dictionary<Decimal, string>();

        public int nbrDeplaceMax { get; set; }

     
        public int nbrDeplaDemande { get; set; }

        public int idSeance { get; set; }

        public int Com_Id { get; set; }
        public decimal TarSea_Prix { get; set; }
    }
}
