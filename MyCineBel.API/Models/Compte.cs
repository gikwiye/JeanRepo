using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("Comptes")]
    public class Compte
    {
        [Key]
        public int COM_Id { get; set; }

        [Required]
        public string COM_Email { get; set; }
        [Required]
        public string COM_Nom { get; set; }
        [Required]

        public string COM_Prenom { get; set; }
        [Required]
        public int COM_NbrPoints { get; set; }
        
        public int? COM_Cin_Id { get; set; }

      
    }
}
