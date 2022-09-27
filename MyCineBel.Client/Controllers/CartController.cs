using Microsoft.AspNetCore.Mvc;
using MyCineBel.Client.Helpers;
using MyCineBel.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.Client.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<ReservationModel>(HttpContext.Session, "Cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.nbrDeplaDemande * cart.TarSea_Prix;

            return View();
        }

        //private int isExist(int idSeance)
        //{
        //    var cart = SessionHelper.GetObjectFromJson<ReservationModel>(HttpContext.Session, "Cart");

        //    if (cart.idSeance.Equals(idSeance)) return idSeance;

        //    else return -1;
        //}

        public IActionResult Buy (ReservationModel _reservation)
        {
            ReservationModel reservation = new ReservationModel();
                     
            reservation = _reservation;

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", reservation);

            return RedirectToAction("Index");
        }




       
    }
}
