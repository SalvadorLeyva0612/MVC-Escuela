using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Escuela;

namespace MVC_Escuela.Controllers
{
    public class view_AlumnosGruposController : Controller
    {
        private EscuelaEntities db = new EscuelaEntities();

        // GET: view_AlumnosGrupos
        public ActionResult Index()
        {
            return View(db.view_AlumnosGrupos.ToList());
        }

        // GET: view_AlumnosGrupos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view_AlumnosGrupos view_AlumnosGrupos = db.view_AlumnosGrupos.Find(id);
            if (view_AlumnosGrupos == null)
            {
                return HttpNotFound();
            }
            return View(view_AlumnosGrupos);
        }

        // GET: view_AlumnosGrupos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: view_AlumnosGrupos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_,Grupo,ID_Alumno,Nombre_Alumno,ID_Profesor,Nombre_Profesor,Materia,Horario")] view_AlumnosGrupos view_AlumnosGrupos)
        {
            if (ModelState.IsValid)
            {
                db.view_AlumnosGrupos.Add(view_AlumnosGrupos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view_AlumnosGrupos);
        }

        // GET: view_AlumnosGrupos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view_AlumnosGrupos view_AlumnosGrupos = db.view_AlumnosGrupos.Find(id);
            if (view_AlumnosGrupos == null)
            {
                return HttpNotFound();
            }
            return View(view_AlumnosGrupos);
        }

        // POST: view_AlumnosGrupos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_,Grupo,ID_Alumno,Nombre_Alumno,ID_Profesor,Nombre_Profesor,Materia,Horario")] view_AlumnosGrupos view_AlumnosGrupos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_AlumnosGrupos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_AlumnosGrupos);
        }

        // GET: view_AlumnosGrupos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view_AlumnosGrupos view_AlumnosGrupos = db.view_AlumnosGrupos.Find(id);
            if (view_AlumnosGrupos == null)
            {
                return HttpNotFound();
            }
            return View(view_AlumnosGrupos);
        }

        // POST: view_AlumnosGrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            view_AlumnosGrupos view_AlumnosGrupos = db.view_AlumnosGrupos.Find(id);
            db.view_AlumnosGrupos.Remove(view_AlumnosGrupos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
