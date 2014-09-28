using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class CategoriaController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Categoria/

        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        //
        // GET: /Categoria/Details/5

        public ActionResult Details(int id = 0)
        {
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /Categoria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        //
        // GET: /Categoria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}