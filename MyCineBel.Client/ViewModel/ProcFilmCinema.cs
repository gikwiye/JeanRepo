using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.ViewModel
{
    public class ProcFilmCinema
    {
        public int CIN_Id { get; set; }
        public string CIN_Name { get; set; }

        public string CIN_Photo { get; set; }

        public int FilmId { get; set; }

        [Display(Name = "Titre")]
        public string filmTitre { get; set; }
        [Display(Name = "Image")]
        public string Film_Image { get; set; }

        [Display(Name = "Bande annconce")]
        public string FilmbandeAnnocne { get; set; }
    }
}
