using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class CategoriaController : Controller
    {

        //
        // POST: /Categoria/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "idCategoria")]Categoria categorias)
        {
            if (ModelState.IsValid)
            {
                db.Categoria.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorias);
        }

        //
        // POST: /Categoria/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias);
        }


        //
        // POST: /Categoria/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categorias = db.Categoria.Find(id);
            db.Categoria.Remove(categorias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}