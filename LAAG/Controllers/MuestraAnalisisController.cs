using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public class MuestraAnalisisController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /MuestraAnalisis/

        public ActionResult Index()
        {
            var muestra_analisis = db.Muestra_analisis.Include(m => m.Analisis).Include(m => m.Factura).Include(m => m.Muestra);
            return View(muestra_analisis.ToList());
        }

        //
        // GET: /MuestraAnalisis/Details/5

        public ActionResult Details(int id = 0)
        {
            Muestra_analisis muestra_analisis = db.Muestra_analisis.Find(id);
            if (muestra_analisis == null)
            {
                return HttpNotFound();
            }
            return View(muestra_analisis);
        }

        //
        // GET: /MuestraAnalisis/Create

        public ActionResult Create()
        {
            ViewBag.IdAnalisis = new SelectList(db.Analisis, "IdAnalisis", "Nombre");
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "UsuarioCreacion");
            ViewBag.Codigo = new SelectList(db.Muestra, "Codigo", "Campo");
            return View();
        }

        //
        // POST: /MuestraAnalisis/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Muestra_analisis muestra_analisis)
        {
            if (ModelState.IsValid)
            {
                db.Muestra_analisis.Add(muestra_analisis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnalisis = new SelectList(db.Analisis, "IdAnalisis", "Nombre", muestra_analisis.IdAnalisis);
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "UsuarioCreacion", muestra_analisis.IdFactura);
            ViewBag.Codigo = new SelectList(db.Muestra, "Codigo", "Campo", muestra_analisis.Codigo);
            return View(muestra_analisis);
        }

        //
        // GET: /MuestraAnalisis/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Muestra_analisis muestra_analisis = db.Muestra_analisis.Find(id);
            if (muestra_analisis == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAnalisis = new SelectList(db.Analisis, "IdAnalisis", "Nombre", muestra_analisis.IdAnalisis);
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "UsuarioCreacion", muestra_analisis.IdFactura);
            ViewBag.Codigo = new SelectList(db.Muestra, "Codigo", "Campo", muestra_analisis.Codigo);
            return View(muestra_analisis);
        }

        //
        // POST: /MuestraAnalisis/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Muestra_analisis muestra_analisis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muestra_analisis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnalisis = new SelectList(db.Analisis, "IdAnalisis", "Nombre", muestra_analisis.IdAnalisis);
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "UsuarioCreacion", muestra_analisis.IdFactura);
            ViewBag.Codigo = new SelectList(db.Muestra, "Codigo", "Campo", muestra_analisis.Codigo);
            return View(muestra_analisis);
        }

        //
        // GET: /MuestraAnalisis/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Muestra_analisis muestra_analisis = db.Muestra_analisis.Find(id);
            if (muestra_analisis == null)
            {
                return HttpNotFound();
            }
            return View(muestra_analisis);
        }

        //
        // POST: /MuestraAnalisis/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Muestra_analisis muestra_analisis = db.Muestra_analisis.Find(id);
            db.Muestra_analisis.Remove(muestra_analisis);
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