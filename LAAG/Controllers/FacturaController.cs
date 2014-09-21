using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public class FacturaController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Factura/

        public ActionResult Index()
        {
            var factura = db.Factura.Include(f => f.Persona);
            return View(factura.ToList());
        }

        //
        // GET: /Factura/Details/5

        public ActionResult Details(int id = 0)
        {
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        //
        // GET: /Factura/Create

        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre");
            return View();
        }

        //
        // POST: /Factura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre", factura.IdCliente);
            return View(factura);
        }

        //
        // GET: /Factura/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre", factura.IdCliente);
            return View(factura);
        }

        //
        // POST: /Factura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre", factura.IdCliente);
            return View(factura);
        }

        //
        // GET: /Factura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        //
        // POST: /Factura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
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