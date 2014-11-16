﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAAG;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Web.Helpers;
using LAAG.Controllers.MyControllers;

namespace LAAG.Controllers
{
    public partial class ResultadoController : Controller
    {
        // POST: Resultado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jsonDatos")] string jsonDatos,
            [Bind(Include = "jsonAnalisis")] string jsonAnalisis)
        {
            if (ModelState.IsValid)
            {
                dynamic analisis = JsonConvert.DeserializeObject(jsonAnalisis);
                Resultado_Analisis resAnalisis = new Resultado_Analisis();

                resAnalisis.IdMuestraAnalisis = analisis.analisis;
                Muestra_Analisis mAnalisis = db.Muestra_Analisis.Find(resAnalisis.IdMuestraAnalisis);
                mAnalisis.Estado = 1;

                dynamic json = JsonConvert.DeserializeObject(jsonDatos);

                resAnalisis.IdReporte = 1;
                resAnalisis.Estado = 1;

                db.Resultado_Analisis.Add(resAnalisis);
                db.SaveChanges();
                
                foreach (var child in json.Datos.Children())
                {
                    Resultado_Dato analisis_dato = new Resultado_Dato();
                    analisis_dato.IdDato = child.id;
                    analisis_dato.Resultado = child.valor;
                    analisis_dato.IdResultadoAnalisis = resAnalisis.IdResultadoAnalisis;
                    db.Resultado_Dato.Add(analisis_dato);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }

            return View();
        }

       
        // POST: Resultado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jsonDatos")] string jsonDatos,
            [Bind(Include = "jsonAnalisis")] string jsonAnalisis)
        {
            if (ModelState.IsValid)
            {
                dynamic analisis = JsonConvert.DeserializeObject(jsonAnalisis);
                Resultado_Analisis resAnalisis = db.Resultado_Analisis.Find(Convert.ToInt32(analisis.analisis));

                dynamic json = JsonConvert.DeserializeObject(jsonDatos);

                db.Resultado_Dato.RemoveRange(resAnalisis.Resultado_Dato);

                foreach (var child in json.Datos.Children())
                {
                    Resultado_Dato analisis_dato = new Resultado_Dato();
                    analisis_dato.IdDato = child.id;
                    analisis_dato.Resultado = child.valor;
                    analisis_dato.IdResultadoAnalisis = resAnalisis.IdResultadoAnalisis;
                    db.Resultado_Dato.Add(analisis_dato);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
           
           return View();
        }

        // POST: Resultado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultado_Analisis resultado_Analisis = db.Resultado_Analisis.Find(id);
            db.Resultado_Analisis.Remove(resultado_Analisis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Resultado/Delete/5
        [HttpPost, ActionName("Muestras")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Muestras(HttpPostedFileBase file)
        public ActionResult Muestras()
        {
            

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    string ExcelContentType = "application/vnd.ms-excel";
                    string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    if (file.ContentType == ExcelContentType || file.ContentType == Excel2010ContentType)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/TempFiles/"), fileName);
                        file.SaveAs(path);
                        LoadFileService insLoadFile = new LoadFileService();
                        
                        string page = "samples";
                        List<DataRow> data = insLoadFile.loadFile(path, page);
                        foreach (DataRow analisis in data) 
                        {
                            Muestra muestra = db.Muestra.Find((analisis.ItemArray[3]).ToString()); // TIESO
                            if (muestra != null) 
                            {
                                var muest_anal = (from row in db.Muestra_Analisis
                                               where row.Codigo == muestra.Codigo && row.Estado == 0
                                               select row).ToList();
                                //muest_anal.ToList();
                                for (int x=0; x<muest_anal.Count(); x++) 
                                {
                                    int idAnal = db.Analisis.Find(muest_anal[x].IdAnalisis).IdAnalisis;
                                    List<string> columns = new List<string>();
                                    switch(idAnal) {                                               // TIESO
                                        case 2:
                                            columns.Add("Percent1");
                                            break;
                                    }
                                        
                                    var ra= from row in db.Resultado_Analisis
                                            where row.IdMuestraAnalisis == muest_anal.ElementAt(x).IdMuestraAnalisis
                                            select row.IdResultadoAnalisis;
                                    
                                    /*var rd = (from row in db.Resultado_Dato
                                                     where row.IdResultadoDato == Convert.ToInt32(ra.ToString())
                                                     select row).ToList();

                                    for(int i=0; i < rd.Count(); i++) 
                                    {
                                        rd[i].Resultado = analisis[columns[i]].ToString();
                                    }
                                    */

                                    Resultado_Analisis resAnalisis = new Resultado_Analisis();
                                    resAnalisis.IdMuestraAnalisis = idAnal;

                                    Muestra_Analisis mAnalisis = db.Muestra_Analisis.Find(resAnalisis.IdMuestraAnalisis);
                                    mAnalisis.Estado = 1;
                                    db.SaveChanges();
                                    resAnalisis.IdReporte = 1;
                                    resAnalisis.Estado = 1;

                                    db.Resultado_Analisis.Add(resAnalisis);
                                    db.SaveChanges();

                                    var datos = (from row in db.Analisis_Dato
                                                where row.IdAnalisis == idAnal
                                                select row).ToList();

                                    for (int i = 0; i < datos.Count(); i++) 
                                    {
                                        Resultado_Dato analisis_dato = new Resultado_Dato();
                                        analisis_dato.IdDato = ((Analisis_Dato)datos[i]).IdDato;
                                        analisis_dato.Resultado = analisis[columns[i]].ToString();
                                        analisis_dato.IdResultadoAnalisis = resAnalisis.IdResultadoAnalisis;
                                        db.Resultado_Dato.Add(analisis_dato);
                                        db.SaveChanges();
                                    }

                                }
                            }
                        }

                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
