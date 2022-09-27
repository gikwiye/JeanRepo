using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.ViewModel
{
    public class ProcfilmCinema
    {
        public int CIN_Id { get; set; }
        public string CIN_Name { get; set; }

        public string CIN_Photo { get; set; }

        public int FilmId { get; set; }

        public string filmTitre { get; set; }

        public string Film_Image { get; set; }

        public string FilmbandeAnnocne { get; set; }
    }
}
