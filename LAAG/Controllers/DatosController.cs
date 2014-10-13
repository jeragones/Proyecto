using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public class DatosController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Datos/

        public ActionResult Index()
        {
            return View(db.Dato.ToList());
        }

        //
        // GET: /Datos/Details/5

        public ActionResult Details(int id = 0)
        {
            Dato dato = db.Dato.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        //
        // GET: /Datos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Datos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "IdDato")]Dato dato)
        {
            if (ModelState.IsValid)
            {
                db.Dato.Add(dato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dato);
        }

        //
        // GET: /Datos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Dato dato = db.Dato.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        //
        // POST: /Datos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dato dato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dato);
        }

        //
        // GET: /Datos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Dato dato = db.Dato.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        //
        // POST: /Datos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dato dato = db.Dato.Find(id);
            db.Dato.Remove(dato);
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