using biuro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace biuro.Controllers
{
    public class ReservationController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        [Authorize(Roles ="Klient")]
        public ActionResult Reserve(int oferta_id)
        {
            if(db.OfertaSet.Find(oferta_id) != null)
                return View();
            else
                return RedirectToAction("Index", "Oferty");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Klient")]
        public ActionResult Reserve(Rezerwacja r)
        {
            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            return View();
        }

        public JsonResult GetMatchingHotels(int oferta_id)
        {
            int m_id = db.OfertaSet.Find(oferta_id).Miejsce.ID;
            List<Nocleg> lista = db.NoclegSet.Where(n => n.MiejsceID == m_id).ToList();
            for (int i = 0; i < lista.Count(); i++)
            {
                while(lista[i].Miejsce != null)
                lista[i].Miejsce = null;
                while(lista[i].Pokoje != null)
                lista[i].Pokoje = null;
            }
            return new JsonResult { Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = int.MaxValue};
        }

        public JsonResult GetHotelRooms(int nocleg_id) //HOTEL ROOM PITBULL STYLE
        {
            List<Pokoje> lista = db.PokojeSet.Where(p => p.NoclegID == nocleg_id && p.Dostepny == true).ToList();
            for (int i = 0; i < lista.Count(); i++)
            {
                while(lista[i].Nocleg != null)
                lista[i].Nocleg = null;
                while(lista[i].Rezerwacje != null)
                lista[i].Rezerwacje = null;
            }
            return new JsonResult { Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = int.MaxValue };
        }
    }
}
