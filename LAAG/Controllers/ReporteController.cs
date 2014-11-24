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
            var res_ana = (from row in db.Resultado_Analisis
                          where row.IdReporte == -1
                          select row).ToList();
            
            List<Muestra_Analisis> analisis = new List<Muestra_Analisis>();
            foreach (var item in res_ana) 
            {
                Muestra_Analisis temp = db.Muestra_Analisis.Find(item.IdMuestraAnalisis);
                analisis.Add(temp);
            }

            List<Muestra> muestras = new List<Muestra>();
            foreach (var item in analisis) 
            {
                Muestra temp = db.Muestra.Find(item.Codigo);
                muestras.Add(temp);
            }

            List<Persona> clientes = new List<Persona>();
            for (int i = 0; i < muestras.Count; i++)
            {
                Persona temp = db.Persona.Find(muestras[i].IdPersona);
                //temp.Nombre = temp.Nombre + " " + temp.Apellido1 + " " + temp.Apellido2;
                clientes.Add(temp);
            }

            ViewBag.IdCliente = new SelectList(clientes.Distinct().ToList(), "ID_Persona", "Nombre");
            ViewBag.Muestras = muestras;
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
                //db.SaveChanges();

                List<Reporte> reportes = db.Reporte.ToList();

                var muestras = db.Persona.Find(reporte.IdCliente).Muestra;
                List<Muestra_Analisis> mue_ana = new List<Muestra_Analisis>();
                foreach (var item in muestras) 
                {
                    foreach (var item1 in item.Muestra_Analisis) 
                    {
                        mue_ana.Add(item1);
                    }
                }

                var res_ana = (from row in db.Resultado_Analisis
                               where row.IdReporte == -1
                               select row).ToList();

                foreach (var item in res_ana) 
                {
                    for (int i = 0; i < mue_ana.Count; i++) 
                    {
                        if (mue_ana[i].IdMuestraAnalisis == item.IdMuestraAnalisis) 
                        {
                            Resultado_Analisis analisis = db.Resultado_Analisis.Find(item.IdResultadoAnalisis);
                            analisis.IdReporte = reportes[reportes.Count - 1].IdReporte;
                            break;
                        }
                    }
                }

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
