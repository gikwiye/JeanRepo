using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.ViewModel
{
    // pour afficher les seances par cinema et par date ===> getSeanceByCinemaAndDate
    public class ProcFilmSeance
    {
        public Seance seance { get; set; }

        public int CIN_Id { get; set; }
        public string CIN_Name { get; set; }

        public string CIN_Photo { get; set; }

        public string  filmTitre { get; set; }

        public string Film_Image { get; set; }
    }
}
