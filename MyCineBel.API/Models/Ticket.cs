using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    public class Ticket
    {
        [Key]
        public int TIC_Id { get; set; }

        public DateTime TIC_DateAchat { get; set; }

        public int TIC_TarSea_Id { get; set; }

        public int TIC_COM_Id { get; set; }
    }
}
