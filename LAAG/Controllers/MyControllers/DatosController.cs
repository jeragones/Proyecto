using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class DatosController : Controller
    {

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
        // POST: /Datos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dato dato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dato).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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

      
    }
}