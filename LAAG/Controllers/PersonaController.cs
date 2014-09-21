using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LAAG;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class PersonaController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Persona/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Persona/

        public ActionResult Clientes(int tipoP = 2)
        {
            var query = db.Persona.Where(p => p.Tipo == tipoP).ToList();
            return View("Index",query);
        }

        //
        // GET: /Persona/

        public ActionResult Empleados(int tipoP = 0)
        {
            var query = db.Persona.Where(p => p.Tipo == tipoP).ToList();
            return View("Index",query);
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id = 0)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            return View();
        }


        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }


        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}