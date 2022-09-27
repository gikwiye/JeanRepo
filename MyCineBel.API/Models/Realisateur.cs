using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("Realisateurs")]
    public class Realisateur
    {
        [Key]
        public int REA_Id { get; set; }

       
        public string REA_Nom { get; set; }
        
        public string REA_Prenom { get; set; }
        
        public string REA_Nationalite { get; set; }
    }
}
