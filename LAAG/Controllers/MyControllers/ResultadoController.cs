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
    }
}
