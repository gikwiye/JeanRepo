using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
    public class Realisateur
    {
        [Key]
        public int REA_Id { get; set; }

        [Display(Name = "Nom")]
        public string REA_Nom { get; set; }
        [Display(Name = "Prenom")]
        public string REA_Prenom { get; set; }
        [Display(Name = "Nationalite")]
        public string REA_Nationalite { get; set; }


    }
}
