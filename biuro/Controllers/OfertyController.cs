using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace biuro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OfertyController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        //
        // GET: /Oferty/
        [AllowAnonymous]
        public ActionResult Index()
        {
            var ofertaset = db.OfertaSet.Include(o => o.Program).Include(o => o.PunktWyjazdu).Include(o => o.Miejsce);
            return View(ofertaset.ToList());
        }

        //
        // GET: /Oferty/Details/5

        public ActionResult Details(int id = 0)
        {
            Oferta oferta = db.OfertaSet.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        //
        // GET: /Oferty/Create

        public ActionResult Create()
        {
            ViewBag.ProgramID = new SelectList(db.ProgramSet, "ID", "Opis");
            ViewBag.PunktWyjazduID = new SelectList(db.PunktWyjazduSet, "ID", "Adres");
            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa");
            return View();
        }

        //
        // POST: /Oferty/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.OfertaSet.Add(oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramID = new SelectList(db.ProgramSet, "ID", "Opis", oferta.ProgramID);
            ViewBag.PunktWyjazduID = new SelectList(db.PunktWyjazduSet, "ID", "Adres", oferta.PunktWyjazduID);
            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa", oferta.MiejsceID);
            return View(oferta);
        }

        //
        // GET: /Oferty/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Oferta oferta = db.OfertaSet.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.ProgramSet, "ID", "Opis", oferta.ProgramID);
            ViewBag.PunktWyjazduID = new SelectList(db.PunktWyjazduSet, "ID", "Adres", oferta.PunktWyjazduID);
            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa", oferta.MiejsceID);
            return View(oferta);
        }

        //
        // POST: /Oferty/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramID = new SelectList(db.ProgramSet, "ID", "Opis", oferta.ProgramID);
            ViewBag.PunktWyjazduID = new SelectList(db.PunktWyjazduSet, "ID", "Adres", oferta.PunktWyjazduID);
            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa", oferta.MiejsceID);
            return View(oferta);
        }

        //
        // GET: /Oferty/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Oferta oferta = db.OfertaSet.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        //
        // POST: /Oferty/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oferta oferta = db.OfertaSet.Find(id);
            db.OfertaSet.Remove(oferta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}