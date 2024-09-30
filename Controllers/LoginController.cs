using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVC_Escuela.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Usuarios usuarios) 
        {
            try
            {
                using (EscuelaEntities context = new EscuelaEntities())
                { 
                Usuarios original = (from u in context.Usuarios where u.Contraseña.Trim().ToUpper() == u.Contraseña.Trim().ToUpper() && u.Nombre_Usuario.Trim().ToLower() == usuarios.Nombre_Usuario.Trim().ToUpper() select u).FirstOrDefault();

                    if (original != null) 
                    {
                        Session["usu"] = original.Nombre_Usuario;
                        Session["rol"] = original.Rol_ID;

                        TempData["sweetalert"] = SweetAlert.Sweet_Alert("Bienvenido", $"Bienvenido de vuelta {original.Nombre_Usuario}",
                            Notificationtype.success);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session.RemoveAll();
                        Session.Clear();
                        //Sweet Alert
                        TempData["sweetAlert"] = SweetAlert.Sweet_Alert("Alto", "Usuario y/o contraseña incorrecta", Notificationtype.warning);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (HttpAntiForgeryException ex)
            {
                Session.RemoveAll();
                Session.Clear();
                //Sweet Alert
                TempData["Alert"] = SweetAlert.Sweet_Alert("Error",ex.Message, Notificationtype.error);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();
            //Sweet Alert
            TempData["Alert"] = SweetAlert.Sweet_Alert("Uis", "Cuida tus gomitas", Notificationtype.error);
            return RedirectToAction("Index");
        }
    }
}