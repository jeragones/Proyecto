using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class CostoController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Costo/

        public ActionResult Index()
        {
            var factura = db.Factura.Include(f => f.IdPersona);
            //return View(factura.ToList());
            return View();
        }

        //
        // GET: /Costo/Details/5

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
        // GET: /Costo/Create

        public ActionResult Create()
        {
            ViewBag.IdPersona = new SelectList(db.Persona, "ID_Persona", "Nombre");

            return View();
        }

        //
        // GET: /Costo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPersona = new SelectList(db.Persona, "ID_Persona", "Nombre", factura.IdPersona);
            return View(factura);
        }

        //
        // GET: /Costo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}