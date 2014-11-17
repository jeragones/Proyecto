using System;
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
                        var configFile = Path.Combine(Server.MapPath("~/"), "LAAG_config.json");

                        StreamReader r = new StreamReader(configFile);
                        string json = r.ReadToEnd();
                        dynamic categories = JsonConvert.DeserializeObject(json);
                        
                        foreach (var category in categories) 
                        {
                            foreach (var analysis in category.analisis) 
                            {
                                var nomAnalysis = analysis.nombre.ToString();
                                List<DataRow> data = insLoadFile.loadFile(path, analysis.hoja.ToString());
                                if (data.Count > 0) 
                                {
                                    foreach (DataRow analisis in data)
                                    {
                                        string column = analysis.codigo.ToString();
                                        Muestra muestra = db.Muestra.Find((analisis[column]).ToString());
                                        if (muestra != null)
                                        {
                                            var muest_anal = (from row in db.Muestra_Analisis
                                                              where row.Codigo == muestra.Codigo && row.Estado == 0
                                                              select row).ToList();

                                            for (int x = 0; x < muest_anal.Count(); x++)
                                            {
                                                Analisis tmpAnalysis = db.Analisis.Find(muest_anal[x].IdAnalisis);
                                                string nomAnal = tmpAnalysis.Nombre;
                                                int idAnal = tmpAnalysis.IdAnalisis;

                                                if (nomAnal.Equals(nomAnalysis)) {
                                                    /*
                                                    var ra = from row in db.Resultado_Analisis
                                                             where row.IdMuestraAnalisis == muest_anal.ElementAt(x).IdMuestraAnalisis
                                                             select row.IdResultadoAnalisis;
                                                    */
                                                    Resultado_Analisis resAnalisis = new Resultado_Analisis();
                                                    resAnalisis.IdMuestraAnalisis = muest_anal[x].IdMuestraAnalisis;
                                                    
                                                    muest_anal[x].Estado = 1;
                                                    db.SaveChanges();
                                                    resAnalisis.IdReporte = -1;
                                                    resAnalisis.Estado = 1;

                                                    db.Resultado_Analisis.Add(resAnalisis);
                                                    db.SaveChanges();

                                                    var datos = (from row in db.Analisis_Dato
                                                                 where row.IdAnalisis == idAnal
                                                                 select row).ToList();

                                                    List<string> columns = new List<string>();
                                                    foreach (var col in analysis.columnas)
                                                    {
                                                        columns.Add(col.nombre.ToString());
                                                    }

                                                    for (int i = 0; i < datos.Count(); i++)
                                                    {
                                                        Resultado_Dato analisis_dato = new Resultado_Dato();
                                                        analisis_dato.IdDato = ((Analisis_Dato)datos[i]).IdDato;
                                                        double value = Convert.ToDouble(analisis[columns[i]]);
                                                        analisis_dato.Resultado = value.ToString("#.##");
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
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
