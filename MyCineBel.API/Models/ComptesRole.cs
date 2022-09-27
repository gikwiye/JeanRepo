using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    public class ComptesRole
    {
        [Key]
        public int ComptesRoles_Id { get; set; }

        public int ComptesRoles_RoleId { get; set; }

        public int ComptesRoles_CompId { get; set; }
    }
}
