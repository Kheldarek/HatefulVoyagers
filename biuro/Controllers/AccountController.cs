using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace biuro.Controllers
{
    public class AccountController : Controller
    {
        public enum Roles
        {
            Klient,
            Admin
        }
        private BiuroPodrozyContainer db = new BiuroPodrozyContainer();

        [HttpGet]
        public ActionResult Login()
        {
            if (Request.Params["ReturnUrl"] != null && Request.Params["ReturnUrl"].Contains("Logout"))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Uzytkownik u)
        {
            if (ModelState.IsValid)
            {
                Uzytkownik t = db.UzytkownikSet.Where(user => user.Login == u.Login).FirstOrDefault();
                if (t != null && t.Login == u.Login && t.Haslo == u.Haslo)
                {
                    FormsAuthentication.SetAuthCookie(t.Login, (Roles)t.Rola == Roles.Klient);
                    if (Request.Params["ReturnUrl"] != null && !Request.Params["ReturnUrl"].Contains("Logout"))
                    {
                        Response.Redirect(Request.Params["ReturnUrl"]);
                        return null;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Nieprawidłowe dane logowania.");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Uzytkownik u)
        {
            Uzytkownik t = db.UzytkownikSet.Find(u.ID);
            if (t == null)
            {
                u.Rola = (int)Roles.Klient;
                db.UzytkownikSet.Add(u);
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Taki użytkownik już istnieje w bazie.");
                return View();
            }
            return View("RegisterSuccess", u);
        }

        [HttpGet]
        public ActionResult RegisterSuccess(Uzytkownik u)
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            if (Request.Params["ReturnUrl"] != null)
            {
                Response.Redirect(Request.Params["ReturnUrl"]);
                return null;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
