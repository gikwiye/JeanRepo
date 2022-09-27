using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("TarifSeances")]
    public class TarifSeance
    {
        [Key]
        public int TarSea_Id { get; set; }

        public decimal TarSea_Prix { get; set; }

        [ForeignKey("tarif")]
        public int TarSea_TAR_Id { get; set; }

        public Tarif tarif { get; set; }
       

  
        public int TarSea_Sea_Id { get; set; }

       
    }
}
