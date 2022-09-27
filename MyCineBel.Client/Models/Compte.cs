using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
    public class Compte
    {
        
        [Key]
        public int COM_Id { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string COM_Email { get; set; }

        [Display(Name = "Nom")]
        [Required]
        public string COM_Nom { get; set; }

        [Display(Name = "Prenom")]
        [Required]

        public string COM_Prenom { get; set; }

        [Display(Name = "NbrPoints")]
        [Required]

        public int COM_NbrPoints { get; set; }

        public int? COM_Cin_Id { get; set; }

    }
}
