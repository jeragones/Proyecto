using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class AnalisisController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Analisis/

        public ActionResult Index()
        {
            var analisis = db.Analisis.Include(a => a.Categoria);
            return View(analisis.ToList());
        }

        //
        // GET: /Analisis/Details/5

        public ActionResult Details(int id = 0)
        {
            Analisis analisis = db.Analisis.Find(id);
            if (analisis == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre");

            var mquery = (from d in db.Dato
                          select new SelectListItem
                          {
                              Value = d.IdDato.ToString(),
                              Text = d.Nombre + " / " + d.unidadMedida
                          }
             );

            ViewBag.Datos = new SelectList(db.Dato, "IdDato", "Nombre");

            return View(analisis);
        }

        //
        // GET: /Analisis/Create

        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre");
            var mquery = (from d in db.Dato
                          select new SelectListItem
                          {
                              Value = d.IdDato.ToString(),
                              Text = d.Nombre + " / " + d.unidadMedida
                          }
    );

            ViewBag.Datos = new SelectList(db.Dato, "IdDato", "Nombre");
            return View();
        }

        //
        // GET: /Analisis/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Analisis analisis = db.Analisis.Find(id);
            if (analisis == null)
            {
                return HttpNotFound();
            }

            var mquery = (from d in db.Dato
                          select new SelectListItem
                          {
                              Value = d.IdDato.ToString(),
                              Text = d.Nombre + " / " + d.unidadMedida
                          }
             );

            ViewBag.Datos = new SelectList(db.Dato, "IdDato", "Nombre");

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre", analisis.IdCategoria);
            return View(analisis);
        }

       
        //
        // GET: /Analisis/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Analisis analisis = db.Analisis.Find(id);
            if (analisis == null)
            {
                return HttpNotFound();
            }
            return View(analisis);
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}