using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class PersonasController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Personas/

        public ActionResult Index()
        {
            return View(db.Persona.ToList());
        }

        //
        // GET: /Personas/Details/5

        public ActionResult Details(int? id)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Personas/Create

        public ActionResult Create()
        {
            return View();
        }


        //
        // GET: /Personas/Edit/5

        public ActionResult Edit(int? id)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Personas/Delete/5

        public ActionResult Delete(int? id)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

   
    }
}