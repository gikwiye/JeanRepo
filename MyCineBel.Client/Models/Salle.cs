using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
    public class Salle
    {
        [Key]
        public int SAL_Id { get; set; }

        [Display (Name = "labelle")]
        public string SAL_Name { get; set; }
        [Display(Name ="Capacite")]
        public int SAL_Capacite { get; set; }
        [Display(Name ="Climatisation")]
        public bool SAL_Climatise { get; set; }
        [Display(Name ="3Dpossible")]
        public bool SAL_3Dpossible { get; set; }

        [ForeignKey("cinema")]
        public int SAL_CIN_Id { get; set; }

        //public string CIN_Name { get; set; }

        public Cinema cinema { get; set; }
    }
}
