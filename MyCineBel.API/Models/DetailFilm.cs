using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    public class DetailFilm
    {
        public int DetailFilm_Id { get; set; }

       
        public string Titre { get; set; }

      
        public string Genre { get; set; }

      
        public string duree { get; set; }
        
        public string BandeAnnonce { get; set; }
       
        public DateTime DateSortie { get; set; }
      
        public string Synopsis { get; set; }

        
        public string Image { get; set; }
    }
}
