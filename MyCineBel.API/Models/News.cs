using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        public int NEWS_Id { get; set; }
        [Required]

        public string NEWS_Titre { get; set; }
        [Required]

        public DateTime NEWS_Date { get; set; }
        [Required]

        public string NEWS_Text { get; set; }

        public int NEWS_COM_Id { get; set; }
    }
}
