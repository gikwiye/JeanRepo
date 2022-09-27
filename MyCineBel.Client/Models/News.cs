using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Models
{
    public class News
    {
        [Key]
        public int NEWS_Id { get; set; }

        [Display(Name = "TITRE")]
        [Required]
        public string NEWS_Titre { get; set; }

        [Display(Name = "DATE SORTIE")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime NEWS_Date { get; set; }

        [Display(Name = "NEWS")]
        [Required]
        public string NEWS_Text { get; set; }

        public int NEWS_COM_Id { get; set; }
    }
}
