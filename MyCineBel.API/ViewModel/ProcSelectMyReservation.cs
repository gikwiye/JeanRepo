using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.ViewModel
{
    public class ProcSelectMyReservation
    {
        public int TicketId{ get; set; }
        public string Cinema { get; set; }

        public string Film { get; set; }

        public int salle { get; set; }

        public decimal prix { get; set; }

        public DateTime DateSeance { get; set; }
    }
}
