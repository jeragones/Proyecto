﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LAAG.Controllers
{
    public partial class AnalisisController : Controller
    {

        // GET: Obtener los detalles de un ingeniero específico
        public ActionResult DatoDetalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // SE busca el id de ingeniero en la lista de ingenieros
            Dato dato = db.Dato.Find(id);

            if (dato == null)
            {
                //Si no se encuetra una coincidencia se retorna un NotFound
                return HttpNotFound();
            }

            // Se crea un objeto con las propiedades de ingeniero y persona
            //var obj = new dato
            //{
            //    idPersona = ingeniero.idPersona,
            //    persona = new persona
            //    {
            //        id = ingeniero.persona.id,
            //        nombre = ingeniero.persona.nombre,
            //        apellido1 = ingeniero.persona.apellido1,
            //        apellido2 = ingeniero.persona.apellido2
            //    },
            //    rol = ingeniero.rol,
            //    descripcion = ingeniero.descripcion,
            //    departamento = ingeniero.departamento
            //};

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(dato);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Analisis/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Analisis analisis)
        {
            if (ModelState.IsValid)
            {
                db.Analisis.Add(analisis);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        // POST: /Analisis/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Analisis analisis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analisis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre", analisis.IdCategoria);
            return View(analisis);
        }

        
        //
        // POST: /Analisis/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Analisis analisis = db.Analisis.Find(id);
            db.Analisis.Remove(analisis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}