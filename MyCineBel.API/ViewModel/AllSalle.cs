using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.ViewModel
{
    public class AllSalle
    {
     
        public int SAL_Id { get; set; }

        public int SAL_Capacite { get; set; }

        public bool SAL_Climatise { get; set; }

        public bool SAL_3Dpossible { get; set; }

        public string CIN_Name { get; set; }
    }
}
