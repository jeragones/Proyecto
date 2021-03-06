﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(dato);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Analisis/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "idAnalisis")]Analisis analisis,
            [Bind(Include = "jsonDatos")] string jsonDatos)
        {
            if (ModelState.IsValid)
            {
                //Obtener los laboratios
                dynamic json = JsonConvert.DeserializeObject(jsonDatos);

                db.Analisis.Add(analisis);
                db.SaveChanges();
                var idAnalisis = analisis.IdAnalisis;
                foreach (var child in json.Datos.Children())
                {
                    //Creación del ingeniero-contrato.
                    Analisis_Dato analisis_dato = new Analisis_Dato();
                    analisis_dato.IdDato = child;
                    //analisis_dato.Dato = db.Dato.Find((int)child);
                    analisis_dato.IdAnalisis = analisis.IdAnalisis;
                    //.Analisis = analisis;
                    db.Analisis_Dato.Add(analisis_dato);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.Datos = new SelectList(db.Dato, "IdDato", "Nombre");

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre", analisis.IdCategoria);
            return View(analisis);
        }

       
        //
        // POST: /Analisis/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Analisis analisis,
            [Bind(Include = "jsonDatos")] string jsonDatos)
        {
            if (ModelState.IsValid)
            {
                Analisis analisisEditar = db.Analisis.Find(analisis.IdAnalisis);
                //Obtener los datos
                dynamic json = JsonConvert.DeserializeObject(jsonDatos);

                //db.Entry(analisis).State = System.Data.Entity.EntityState.Modified;
                var idAnalisis = analisis.IdAnalisis;

                db.Analisis_Dato.RemoveRange(analisisEditar.Analisis_Dato);

                foreach (var child in json.Datos.Children())
                {
                    //Creación del ingeniero-contrato.
                    Analisis_Dato analisis_dato = new Analisis_Dato();
                    analisis_dato.IdDato = child;
                    //analisis_dato.Dato = db.Dato.Find((int)child);
                    analisis_dato.IdAnalisis = analisis.IdAnalisis;
                    //.Analisis = analisis;
                    db.Analisis_Dato.Add(analisis_dato);
                    db.SaveChanges();
                }

                analisisEditar.IdCategoria = analisis.IdCategoria;
                analisisEditar.Descripcion = analisis.Descripcion;
                analisisEditar.Nombre = analisis.Nombre;
                analisisEditar.Costo = analisis.Costo;

                db.Analisis.Attach(analisisEditar);
                db.Entry(analisisEditar).State = System.Data.Entity.EntityState.Modified;

                
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