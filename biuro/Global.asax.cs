﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using biuro.Controllers;

namespace biuro
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {              
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string role = string.Empty;

                        using (var baza = new BiuroPodrozyContainer())
                        {
                            Uzytkownik u = baza.UzytkownikSet.Where(user => user.Login == username).First();
                            role = ((AccountController.Roles)u.Rola).ToString();
                        }
                        e.User = new System.Security.Principal.GenericPrincipal(
                           new System.Security.Principal.GenericIdentity(username, "Forms"), role.Split(';'));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}