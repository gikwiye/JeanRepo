using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    [Table("ActeurFilms")]
    public class ActeurFilm
    {
        [Key]
        public int ActeurFilm_Id { get; set; }

        public int ActeurFilm_ACT_Id { get; set; }

        public int ActeurFilm_Film_id { get; set; }
    }
}
