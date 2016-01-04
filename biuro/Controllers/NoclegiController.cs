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
    public class NoclegiController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        //
        // GET: /Noclegi/

        public ActionResult Index()
        {
            var noclegset = db.NoclegSet.Include(n => n.Miejsce);
            return View(noclegset.ToList());
        }

        //
        // GET: /Noclegi/Details/5

        public ActionResult Details(int id = 0)
        {
            Nocleg nocleg = db.NoclegSet.Find(id);
            if (nocleg == null)
            {
                return HttpNotFound();
            }
            return View(nocleg);
        }

        //
        // GET: /Noclegi/Create

        public ActionResult Create()
        {
            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa");
            return View();
        }

        //
        // POST: /Noclegi/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nocleg nocleg)
        {
            if (ModelState.IsValid)
            {
                db.NoclegSet.Add(nocleg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa", nocleg.MiejsceID);
            return View(nocleg);
        }

        //
        // GET: /Noclegi/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Nocleg nocleg = db.NoclegSet.Find(id);
            if (nocleg == null)
            {
                return HttpNotFound();
            }
            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa", nocleg.MiejsceID);
            return View(nocleg);
        }

        //
        // POST: /Noclegi/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nocleg nocleg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nocleg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MiejsceID = new SelectList(db.MiejsceSet, "ID", "Nazwa", nocleg.MiejsceID);
            return View(nocleg);
        }

        //
        // GET: /Noclegi/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Nocleg nocleg = db.NoclegSet.Find(id);
            if (nocleg == null)
            {
                return HttpNotFound();
            }
            return View(nocleg);
        }

        //
        // POST: /Noclegi/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nocleg nocleg = db.NoclegSet.Find(id);
            db.NoclegSet.Remove(nocleg);
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