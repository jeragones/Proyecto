using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAAG;
using System.Globalization;

namespace LAAG.Controllers
{
    public class ReporteController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        // GET: Reporte
        public ActionResult Index()
        {
            var reporte = db.Reporte.Include(r => r.Persona);
            return View(reporte.ToList());
        }

        // GET: Reporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // GET: Reporte/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre");
            return View();
        }

        // POST: Reporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Metodologia,Observaciones,IdCliente")] Reporte report)
        {
            Persona persona = (Persona)Session["CurrentSession"];
            if (ModelState.IsValid)
            {
                Reporte reporte = new Reporte();
                reporte.Fecha = DateTime.Today;
                reporte.IdCliente = report.IdCliente;
                reporte.IdUsuario = persona.ID_Persona;
                reporte.Metodologia = report.Metodologia;
                reporte.Observaciones = report.Observaciones;
                    
                db.Reporte.Add(reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre", report.IdCliente);
            return View(report);
        }

        // GET: Reporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre", reporte.IdCliente);
            return View(reporte);
        }

        // POST: Reporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReporte,Fecha,Metodologia,Observaciones,IdUsuario,IdCliente")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Persona, "ID_Persona", "Nombre", reporte.IdCliente);
            return View(reporte);
        }

        // GET: Reporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // POST: Reporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reporte reporte = db.Reporte.Find(id);
            db.Reporte.Remove(reporte);
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
