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
            List<Facturas> factura = new List<Facturas>();
            var muestra = db.Muestra.ToList();
            
            foreach (var item in muestra)
            {
                Facturas fact = new Facturas();
                Persona persona = db.Persona.Find(item.IdPersona);
                fact.Codigo = item.Codigo;
                fact.Campo = item.Campo;
                fact.Nombre = persona.Nombre + " " + persona.Apellido1 + " " + persona.Apellido2;
                var muestAnal = from row in db.Muestra_Analisis
                                         where row.Codigo == item.Codigo
                                         select new { row.IdFactura };
                int id = 1; 
                foreach (var x in muestAnal) {
                    id = x.IdFactura;
                    break;
                }
                
                fact.Costo = (int)db.Factura.Find(id).Costo;
                factura.Add(fact);
            }
            return View(factura);
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

        public ActionResult Delete(String id)
        {
            Facturas fact = new Facturas();
            List<Analisis> analisis = new List<Analisis>();
            int idFact = 0;
            var muestra = from row in db.Muestra
                             where row.Codigo == id
                             select row;
            
            foreach (var item in muestra)
            {
                Persona persona = db.Persona.Find(item.IdPersona);
                fact.Codigo = item.Codigo;
                fact.Campo = item.Campo;
                fact.Nombre = persona.Nombre + " " + persona.Apellido1 + " " + persona.Apellido2;
                ViewBag.Provincia = db.Provincia.Find(item.Provincia).nombre;
                
                ViewBag.Canton = db.Canton.Find(item.Canton).nombre;
                ViewBag.Distrito = db.Distrito.Find(item.Distrito).nombre;
                fact.Direccion = item.Direccion;
                var muestAnal = from row in db.Muestra_Analisis
                                where row.Codigo == item.Codigo
                                select row;
                foreach(var element in muestAnal) 
                {
                    analisis.Add(db.Analisis.Find(element.IdAnalisis));
                    idFact = element.IdFactura;
                }
                fact.Costo = (int)db.Factura.Find(idFact).Costo;
                ViewBag.categoria = analisis[0].IdCategoria;
            }
            ViewBag.analisis = analisis;
            
            return View(fact);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}