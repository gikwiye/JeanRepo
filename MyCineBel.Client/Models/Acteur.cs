using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
    public class Acteur
    {
        [Key]
        public int ACT_Id { get; set; }
       
        [Display(Name = "Nom")]
        [Required, MinLength(4, ErrorMessage = "Le nom est obligatoire, longueur min 4")]
        public string ACT_Nom { get; set; }
        [Display(Name = "Prenom")]
        [Required, MinLength(4, ErrorMessage = "Le prenom est obligatoire, longeur min 4")]
        public string ACT_Prenom { get; set; }
    }
}
