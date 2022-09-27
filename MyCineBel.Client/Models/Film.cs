using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
    public class Film
    {
        [Key]
        public int Film_Id { get; set; }

        [Display(Name = "Titre")]
        [Required]
        public string Film_Titre { get; set; }
        [Display(Name = "Genre")]
        public string Film_Genre { get; set; }

        [Display(Name = "Duree (minute)")]
        [Required]
        public int Film_duree { get; set; }
        [Display(Name = "Bande Annonce")]
        //[Required]
        public string Film_BandeAnnonce { get; set; }
        [Display(Name = "Date de sortie")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime Film_DateSortie { get; set; }
        [Display(Name = "Synopsis")]
        [Required]
        public string Film_Synopsis { get; set; }

        [Display(Name = "Image")]
        public string Film_Image { get; set; }
        [Required]
        public int Film_Rea_Id { get; set; }

        [NotMapped]
        public IFormFile ImageUpload { get; set; }

        [NotMapped]
        public IFormFile BandeAnnonceUpload { get; set; }

    }
}
