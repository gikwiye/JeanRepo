using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{

    // Cette classe represente mes donnees dans la DB

    [Table("Films")]
    public class Film
    {
        [Key]
        public int Film_Id { get; set; }
        [Required]
        public string Film_Titre { get; set; }
        public string Film_Genre { get; set; }
        [Required]
        public int Film_duree { get; set; }
        [Required]
        public string Film_BandeAnnonce { get; set; }
        [Required]
        public DateTime Film_DateSortie { get; set; }
        [Required]
        public string Film_Synopsis { get; set; }
        public string Film_Image { get; set; }
        [Required]
        public int Film_Rea_Id { get; set; }

        [NotMapped]
        public IFormFile ImageUpload { get; set; }

        [NotMapped]
        public IFormFile BandeAnnonceUpload { get; set; }

    }
}

