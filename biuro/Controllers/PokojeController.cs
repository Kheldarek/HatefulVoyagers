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
    public class PokojeController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        //
        // GET: /Pokoje/

        public ActionResult Index()
        {
            var pokojeset = db.PokojeSet.Include(p => p.Nocleg);
            return View(pokojeset.ToList());
        }

        //
        // GET: /Pokoje/Create

        public ActionResult Create()
        {
            ViewBag.NoclegID = new SelectList(db.NoclegSet, "ID", "Adres");
            return View();
        }

        //
        // POST: /Pokoje/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pokoje pokoje)
        {
            if (ModelState.IsValid)
            {
                db.PokojeSet.Add(pokoje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NoclegID = new SelectList(db.NoclegSet, "ID", "Adres", pokoje.NoclegID);
            return View(pokoje);
        }

        //
        // GET: /Pokoje/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pokoje pokoje = db.PokojeSet.Find(id);
            if (pokoje == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoclegID = new SelectList(db.NoclegSet, "ID", "Adres", pokoje.NoclegID);
            return View(pokoje);
        }

        //
        // POST: /Pokoje/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pokoje pokoje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokoje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NoclegID = new SelectList(db.NoclegSet, "ID", "Adres", pokoje.NoclegID);
            return View(pokoje);
        }

        //
        // GET: /Pokoje/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pokoje pokoje = db.PokojeSet.Find(id);
            if (pokoje == null)
            {
                return HttpNotFound();
            }
            return View(pokoje);
        }

        //
        // POST: /Pokoje/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokoje pokoje = db.PokojeSet.Find(id);
            db.PokojeSet.Remove(pokoje);
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