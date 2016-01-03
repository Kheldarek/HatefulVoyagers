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
    public class PunktyWyjazduController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        //
        // GET: /PunktyWyjazdu/

        public ActionResult Index()
        {
            return View(db.PunktWyjazduSet.ToList());
        }

        //
        // GET: /PunktyWyjazdu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PunktyWyjazdu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PunktWyjazdu punktwyjazdu)
        {
            if (ModelState.IsValid)
            {
                db.PunktWyjazduSet.Add(punktwyjazdu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(punktwyjazdu);
        }

        //
        // GET: /PunktyWyjazdu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PunktWyjazdu punktwyjazdu = db.PunktWyjazduSet.Find(id);
            if (punktwyjazdu == null)
            {
                return HttpNotFound();
            }
            return View(punktwyjazdu);
        }

        //
        // POST: /PunktyWyjazdu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PunktWyjazdu punktwyjazdu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punktwyjazdu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(punktwyjazdu);
        }

        //
        // GET: /PunktyWyjazdu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PunktWyjazdu punktwyjazdu = db.PunktWyjazduSet.Find(id);
            if (punktwyjazdu == null)
            {
                return HttpNotFound();
            }
            return View(punktwyjazdu);
        }

        //
        // POST: /PunktyWyjazdu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PunktWyjazdu punktwyjazdu = db.PunktWyjazduSet.Find(id);
            db.PunktWyjazduSet.Remove(punktwyjazdu);
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