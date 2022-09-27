using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
    public class Cinema
    {
        [Key]
        public int CIN_Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string CIN_Name { get; set; }
        [Display(Name = "Photo")]
        //[Required]
        public string CIN_Photo { get; set; }
        [Display(Name = "Ville")]
        [Required]
        public string CIN_Ville { get; set; }
        [Display(Name = "Rue")]
        [Required]
        public string CIN_Rue { get; set; }
        [Display(Name = "CodePostal")]
        [Required]
        public int CIN_CodePostal { get; set; }
        [NotMapped]
        public IFormFile ImageUpload { get; set; }
    }
}
