using biuro.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace biuro.Controllers
{
    public class ReservationController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        [Authorize(Roles ="Klient")]
        public ActionResult Reserve(int oferta_id)
        {
            if (db.OfertaSet.Find(oferta_id) != null)
            {
                ViewData["oferta_id"] = oferta_id;
                return View();
            }
            else
                return RedirectToAction("Index", "Oferty");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Klient")]
        public ActionResult Reserve(Rezerwacja r)
        {
            int hotelid = int.Parse(HttpContext.Request.Form.GetValues("hotele").FirstOrDefault());
            int pokojid = int.Parse(HttpContext.Request.Form.GetValues("pokoje").FirstOrDefault());
            int ofertaid = int.Parse(HttpContext.Request.Form.GetValues("oferta_id").FirstOrDefault());
            var json = new JavaScriptSerializer();
            int m_id = db.OfertaSet.Find(ofertaid).Miejsce.ID;
            string jsonstring = HttpContext.Request.Form.GetValues("osoby").FirstOrDefault().Replace("\\", "").Replace("\"/", "");
            JArray osoby = JArray.Parse(jsonstring);
            var hotel  = db.NoclegSet.Find(hotelid);
            var pokoj = db.PokojeSet.Find(pokojid);
            r.nocleg = hotel;
            r.pokoj = pokoj;
            r.oferta = ofertaid;
            Rezerwacje tmp = new Rezerwacje();
            
            tmp.KlientID = r.klient.ID;
            tmp.OfertaID = ofertaid;
            tmp.PokojeID = pokojid;
            foreach (var i in osoby)
            {
                OsobyTowarzyszace o = new OsobyTowarzyszace();
                o.Imie = i["imie"].ToString();
                o.Nazwisko = i["nazwisko"].ToString();
                o.RezerwacjeID = tmp.ID;
                if (o.Imie != "" && o.Nazwisko != "")
                { 
                    o.DataUrodzenia = DateTime.Parse(i["dataur"].ToString());
                    tmp.OsobyTowarzyszace.Add(o);
                    db.OsobyTowarzyszaceSet.Add(o);
                }
            }
            r.klient.Uzytkownik = db.UzytkownikSet.Where(u => u.Login == User.Identity.Name).ToList().First();

            db.KlientSet.Add(r.klient);
            db.RezerwacjeSet.Add(tmp);
            db.SaveChanges();

            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            
            return View();
        }
        [Authorize(Roles = "Klient")]
        public ActionResult ReservationHistory()
        {

            var klient = db.KlientSet.Where(k => k.Uzytkownik.Login == HttpContext.User.Identity.Name).ToList().First();
            var rezerwacje = db.RezerwacjeSet.Where(u => u.KlientID == klient.ID).ToList();
            List < History > lista  = new List<History>();
            foreach (var trip in rezerwacje)
            {

                History historia = new History();
                historia.nazwa = trip.Oferta.Miejsce.Nazwa;
                historia.cena = trip.Oferta.Cena;
                historia.program = trip.Oferta.Program.Opis;
                historia.opis = trip.Oferta.Miejsce.Opis;
                historia.start = trip.Oferta.DataWyjazdu;
                historia.koniec = trip.Oferta.DataPowrotu;
                historia.MiejsceId = trip.Oferta.MiejsceID;
                lista.Add(historia);
            }
            return View(lista);
        }
        [Authorize(Roles = "Klient")]
        public ActionResult Opinion(int miejsce_id)
        {
            ViewData["miejsce_id"] = miejsce_id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Klient")]
        public ActionResult Opinion(Opinie o)
        {
            int m_id = int.Parse(HttpContext.Request.Form.GetValues("miejsce_id").First());
            o.MiejsceID = m_id;
            db.OpinieSet.Add(o);
            db.SaveChanges();
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
