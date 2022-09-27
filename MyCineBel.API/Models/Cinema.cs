using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("Cinemas")]
    public class Cinema
    {
        [Key]
        public int CIN_Id { get; set; }
        [Required]
        public string CIN_Name { get; set; }
        [Required]
        public string CIN_Photo { get; set; }
        [Required]
        public string CIN_Ville { get; set; }
        [Required]
        public string CIN_Rue { get; set; }
        [Required]
        public int CIN_CodePostal { get; set; }

        [NotMapped]
        public IFormFile ImageUpload { get; set; }
    }
}
