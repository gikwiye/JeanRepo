using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("Tarifs")]
    public class Tarif
    {
        [Key]
        public int TAR_Id { get; set; }

        public string TAR_Libelle { get; set; }
    }
}
