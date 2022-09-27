using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("Seances")]
    public class Seance
    {
        [Key]
        public int SEA_Id { get; set; }
        [Required]
        public DateTime SEA_Date { get; set; }
        [Required]
        public DateTime SEA_HeureDebut { get; set; }
        [Required]
        public int Sea_MaxPlace { get; set; }

        public int Sea_SAL_Id { get; set; }

        public int Sea_Film_Id { get; set; }
    }
}
