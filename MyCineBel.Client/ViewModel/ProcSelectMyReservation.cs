using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.ViewModel
{
    public class ProcSelectMyReservation
    {
        public int TicketId { get; set; }
        public string Cinema { get; set; }

        public string Film { get; set; }

        public int salle { get; set; }

        public decimal prix { get; set; }

        [Display( Name="Date")]
        public DateTime DateSeance { get; set; }
    }
}
