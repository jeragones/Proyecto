using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class DatosController : Controller
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


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}