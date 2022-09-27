using MyCineBel.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.ViewModel
{
    // pour afficher les seances par cinema et par date ===> getSeanceByCinemaAndDate
    public class ProcFilmSeance
    {
    
        public Seance seance { get; set; }

        public string CIN_Name { get; set; }

        public string CIN_Photo { get; set; }

        [Display(Name = "TITRE")]
        public string filmTitre { get; set; }

        [Display(Name = "IMAGE")]
        public string Film_Image { get; set; }
    }
}
