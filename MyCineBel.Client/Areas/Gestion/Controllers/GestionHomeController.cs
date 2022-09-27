using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    [Authorize(Roles = "Gestion")]
    public class GestionHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

   
 
}
