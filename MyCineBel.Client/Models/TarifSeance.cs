using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
   

    public class TarifSeance
    {
       
        public int TarSea_Id { get; set; }
        [Display(Name = "Prix")]
        [Required(ErrorMessage = "Specifier votre prix")]
        [Range(5, 10, ErrorMessage = "Prix compris entre 5 et 15")]
        public decimal TarSea_Prix { get; set; }

      
        [ForeignKey("tarif")]
        public int TarSea_TAR_Id { get; set; }

        public Tarif tarif { get; set; }
        [Display(Name ="Numero Seance")]
        public int TarSea_Sea_Id { get; set; }

    }
}
