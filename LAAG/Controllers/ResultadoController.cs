using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAAG;

namespace LAAG.Controllers
{
    public partial class ResultadoController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        // GET: Resultado
        public ActionResult Index()
        {
            var res = db.Muestra_Analisis.ToList();
            return View(res);
        }

        // GET: Resultado
        public ActionResult Muestras(int? estado)
        {
            var res = db.Muestra_Analisis.Where(x=>x.Estado==estado).ToList();
            return View(res);
        }

        // GET: Resultado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado_Analisis resultado_Analisis = db.Resultado_Analisis.Find(id);
            if (resultado_Analisis == null)
            {
                return HttpNotFound();
            }
            return View(resultado_Analisis);
        }

        // GET: Resultado/Create
        public ActionResult Create(int? analisis)
        {
            ViewBag.IdMuestraAnalisis = analisis;
            return View();
        }


        // GET: Resultado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado_Analisis resultado_Analisis = db.Resultado_Analisis.Find(id);
            if (resultado_Analisis == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMuestraAnalisis = new SelectList(db.Muestra_Analisis, "IdMuestraAnalisis", "Nombre", resultado_Analisis.IdMuestraAnalisis);
            ViewBag.IdReporte = new SelectList(db.Reporte, "IdReporte", "Metodologia", resultado_Analisis.IdReporte);
            return View(resultado_Analisis);
        }


        // GET: Resultado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado_Analisis resultado_Analisis = db.Resultado_Analisis.Find(id);
            if (resultado_Analisis == null)
            {
                return HttpNotFound();
            }
            return View(resultado_Analisis);
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
