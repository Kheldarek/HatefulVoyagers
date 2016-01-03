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
    public class MiejscaController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        //
        // GET: /Miejsca/

        public ActionResult Index()
        {
            return View(db.MiejsceSet.ToList());
        }

        //
        // GET: /Miejsca/Details/5

        public ActionResult Details(int id = 0)
        {
            Miejsce miejsce = db.MiejsceSet.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        //
        // GET: /Miejsca/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Miejsca/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                db.MiejsceSet.Add(miejsce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miejsce);
        }

        //
        // GET: /Miejsca/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Miejsce miejsce = db.MiejsceSet.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        //
        // POST: /Miejsca/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miejsce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miejsce);
        }

        //
        // GET: /Miejsca/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Miejsce miejsce = db.MiejsceSet.Find(id);
            if (miejsce == null)
            {
                return HttpNotFound();
            }
            return View(miejsce);
        }

        //
        // POST: /Miejsca/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miejsce miejsce = db.MiejsceSet.Find(id);
            db.MiejsceSet.Remove(miejsce);
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