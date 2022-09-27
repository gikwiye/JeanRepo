using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
        public class Tarif
        {
            [Key]
            public int TAR_Id { get; set; }
            [Display(Name ="Libelle")]
            public string TAR_Libelle { get; set; }
        }
    
}
