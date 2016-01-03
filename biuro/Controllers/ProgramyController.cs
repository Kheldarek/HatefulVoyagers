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
    public class ProgramyController : Controller
    {
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        //
        // GET: /Programy/

        public ActionResult Index()
        {
            return View(db.ProgramSet.ToList());
        }

        //
        // GET: /Programy/Details/5

        public ActionResult Details(int id = 0)
        {
            Program program = db.ProgramSet.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        //
        // GET: /Programy/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Programy/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Program program)
        {
            if (ModelState.IsValid)
            {
                db.ProgramSet.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(program);
        }

        //
        // GET: /Programy/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Program program = db.ProgramSet.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        //
        // POST: /Programy/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(program);
        }

        //
        // GET: /Programy/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Program program = db.ProgramSet.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        //
        // POST: /Programy/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = db.ProgramSet.Find(id);
            db.ProgramSet.Remove(program);
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