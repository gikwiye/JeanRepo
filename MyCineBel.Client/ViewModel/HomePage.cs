using MyCineBel.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.ViewModel
{
    public class HomePage
    {
        public List<Film> film { get; set; }

        public News news { get; set; }
    }
}
