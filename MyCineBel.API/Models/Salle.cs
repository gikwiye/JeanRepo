using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("Salles")]
    public class Salle
    {
        [Key]
        public int SAL_Id { get; set; }

        public string SAL_Name { get; set; }

        public int SAL_Capacite { get; set; }

        public bool SAL_Climatise { get; set; }

        public bool SAL_3Dpossible { get; set; }

        [ForeignKey("cinema")]
        public int SAL_CIN_Id { get; set; }

        [NotMapped]
        public string CIN_Name { get; set; }

        public Cinema cinema { get; set; }

    }
}
