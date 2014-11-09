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
            ViewBag.Estado = estado;
            return View(res);
        }

        // GET: Resultado/Details/5
        public ActionResult Details(int? analisis)
        {
            if (analisis == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muestra_Analisis mAnalisis = db.Muestra_Analisis.Find(analisis);
            var resAnalisis = db.Resultado_Analisis.Where(x => x.IdMuestraAnalisis == mAnalisis.IdMuestraAnalisis);
            Resultado_Analisis resultado_Analisis = mAnalisis.Resultado_Analisis.First();
            if (resultado_Analisis == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Resultado_Dato> resDatos = db.Resultado_Dato.Where(i => i.IdResultadoAnalisis == resultado_Analisis.IdResultadoAnalisis).ToList();
            ViewBag.Datos = resDatos;
            ViewBag.IdMuestraAnalisis = analisis;
            return View(resDatos);
        }

        // GET: Resultado/Create
        public ActionResult Create(int? analisis)
        {
            ViewBag.IdMuestraAnalisis = analisis;
            return View();
        }


        // GET: Resultado/Edit/5
        public ActionResult Edit(int? analisis)
        {
            if (analisis == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muestra_Analisis mAnalisis = db.Muestra_Analisis.Find(analisis);
            var resAnalisis = db.Resultado_Analisis.Where(x=> x.IdMuestraAnalisis == mAnalisis.IdMuestraAnalisis);
            Resultado_Analisis resultado_Analisis = mAnalisis.Resultado_Analisis.First();
            if (resultado_Analisis == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Resultado_Dato> resDatos = db.Resultado_Dato.Where(i => i.IdResultadoAnalisis == resultado_Analisis.IdResultadoAnalisis).ToList();
            ViewBag.Datos = resDatos;
            ViewBag.IdMuestraAnalisis = analisis;
            return View(resDatos);
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
