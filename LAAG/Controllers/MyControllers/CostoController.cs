using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LAAG.Controllers.MyControllers;


namespace LAAG.Controllers
{
    public partial class CostoController : Controller
    {        
        //
        // GET: /Costo/clientes
        public ActionResult Clientes()
        {
            var consult = db.Persona.ToList();
            List<Object> clients = new List<Object>();

            if (consult == null)
            {
                //Si no se encuetra una coincidencia se retorna un NotFound
                return HttpNotFound();
            }
            else
            {
                foreach (var item in consult)
                {
                    if(item.Tipo == 2)
                        clients.Add(new { id = item.ID_Persona, nombre = item.Nombre+" "+item.Apellido1+" "+item.Apellido2 });
                }
            }

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(clients);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Costo/categoria
        public ActionResult Categorias()
        {
            var consult = db.Categoria.ToList();
            List<Object> categories = new List<Object>();

            if (consult == null)
            {
                //Si no se encuetra una coincidencia se retorna un NotFound
                return HttpNotFound();
            }
            else
            {
                foreach (var item in consult)
                {
                    categories.Add(new { id = item.IdCategoria, nombre = item.Nombre });
                }
            }

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(categories);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Costo/provincia
        public ActionResult Provincia()
        {
            var consult = db.Provincia.ToList();
            List<Object> provinces = new List<Object>();

            
            if (consult == null)
            {
                //Si no se encuetra una coincidencia se retorna un NotFound
                return HttpNotFound();
            }
            else
            {
                foreach (var item in consult)
                {
                    provinces.Add(new { id = item.numeroProvincia, nombre = item.nombre });
                }
            }

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(provinces);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Costo/canton
        //[HttpPost]
        public ActionResult Canton(String id)
        {
            var consult = db.Canton.ToList();
            List<Object> cantons = new List<Object>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else 
            {
                if (consult == null)
                {
                    //Si no se encuetra una coincidencia se retorna un NotFound
                    return HttpNotFound();
                }
                else 
                {
                    foreach (var item in consult)
                    {
                        if (item.numeroProvincia == Convert.ToInt32(id))
                            cantons.Add(new { idCanton = item.numeroCanton, idProvince = item.numeroProvincia, nombre = item.nombre });
                    }
                }
            }

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(cantons);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Costo/distrito
        //[HttpPost]
        public ActionResult Distrito(String idCanton, String idProvince)
        {
            var consult = db.Distrito.ToList();
            List<Object> districts = new List<Object>();

            if (idCanton == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else 
            {
                if (consult == null)
                {
                    //Si no se encuetra una coincidencia se retorna un NotFound
                    return HttpNotFound();
                }
                else
                {
                    foreach (var item in consult)
                    {
                        if (item.numeroProvincia == Convert.ToInt32(idProvince) && item.numeroCanton == Convert.ToInt32(idCanton))
                            districts.Add(new { id = item.numeroDistrito, idCan = item.numeroCanton, nombre = item.nombre });
                    }
                }
            }

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(districts);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Costo/categoria
        //[HttpPost]
        public ActionResult Categoria(String id)
        {
            var consult = db.Analisis.ToList();
            List<Object> analysis = new List<Object>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (consult == null)
                {
                    //Si no se encuetra una coincidencia se retorna un NotFound
                    return HttpNotFound();
                }
                else
                {
                    foreach (var item in consult)
                    {
                        if (item.IdCategoria == Convert.ToInt32(id))
                            analysis.Add(new { id = item.IdAnalisis, nombre = item.Nombre });
                    }
                }
            }

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(analysis);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Costo/analisis
        //[HttpPost]
        public ActionResult Analisis(String id, String idCategoria, String categoria)
        {
            String codigo = "";
            DateTime dt = DateTime.Now;
            String[] temp = categoria.Split(' ');
            int num = 1;

            var consult = from row in db.Muestra
                          select row;

            for (int i = 0; i < temp.Length; i++)
            {
                codigo += temp[i][0];
            }

            foreach (var item in consult)
            {
                if (codigo.Equals(item.Codigo.Split('-')[0]))
                    num++;
            }

            codigo += '-' + dt.Year.ToString() + '-' + num.ToString();
            
            num = Convert.ToInt32(id);

            var analisis = from row in db.Analisis
                           where row.IdAnalisis == num
                           select new { id,
                                        codigo,
                                        row.Nombre,
                                        categoria,
                                        row.Costo
                           };

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(analisis);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Costo/precio
        //[HttpPost]
        public ActionResult Precio(String id, String cost, String op)
        {
            var consult = db.Analisis.ToList();
            Object price = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (consult == null)
                {
                    //Si no se encuetra una coincidencia se retorna un NotFound
                    return HttpNotFound();
                }
                else
                {
                    for(int i=0; i < consult.Count; i++)
                    {
                        if (consult[i].IdAnalisis == Convert.ToInt32(id)) 
                        {
                            price = consult[i].Costo;
                            break;
                        }
                    }
                }
            }

            if(Convert.ToBoolean(op))
                price = Convert.ToDouble(cost) + Convert.ToDouble(price);
            else
                price = Convert.ToDouble(cost) - Convert.ToDouble(price);

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(price);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Costo/guardar
        [HttpPost]
        public ActionResult Create([Bind(Include = "jsonDatos")] string jsonDatos)
        {

            Factura factura = new Factura();
            Muestra muestra = new Muestra();
            Muestra_Analisis muestraAnalisis = new Muestra_Analisis();
            
            String codigo = "";
            Decimal costo = 0;
            DateTime dt = DateTime.Now;

             //Obtener los laboratios
            dynamic json = JsonConvert.DeserializeObject(jsonDatos);
            Analisis analisis = db.Analisis.Find(Convert.ToInt32(json.id[0].ToString()));

            Categoria categoria = db.Categoria.Find(analisis.IdCategoria);

            var consult = from row in db.Muestra
                          select row;

            int num = 1;
            
            String[] temp = categoria.Nombre.Split(' ');

            for (int i = 0; i < temp.Length; i++)
            {
                codigo += temp[i][0];
            }

            foreach (var item in consult)
            {
                if (codigo.Equals(item.Codigo.Split('-')[0]))
                    num++;
            }

            codigo += '-' + dt.Year.ToString() + '-' + num.ToString();
           
            // creacion de la muestra
            String[] tmp = (json.muestra.canton).ToString().Split('_');
            muestra.Codigo = codigo;
            muestra.Campo = json.muestra.campo;
            muestra.IdPersona = json.muestra.id;
            muestra.Provincia = json.muestra.provincia;
            muestra.Canton = Convert.ToInt32(tmp[0]);
            muestra.Distrito = json.muestra.distrito;
            muestra.Direccion = json.muestra.direccion;
            //db.Muestra.Add(muestra);
            //db.SaveChanges();

            Analisis tmpAnalisis;
            foreach (var item in json.id)
            {
                tmpAnalisis = db.Analisis.Find(Convert.ToInt32(item.ToString()));
                costo += tmpAnalisis.Costo;
            }

            // creacion de la factura
            factura.IdPersona = json.muestra.id;
            factura.Fecha = DateTime.Today;
            factura.Costo = costo;
            //db.Factura.Add(factura);
            //db.SaveChanges();

            // creacion de un analisis para la muestra
            foreach (var item in json.id)
            {
                tmpAnalisis = db.Analisis.Find(Convert.ToInt32(item.ToString()));
                muestraAnalisis.Nombre = json.muestra.nombre;
                muestraAnalisis.Costo = tmpAnalisis.Costo;
                muestraAnalisis.Codigo = codigo;
                muestraAnalisis.IdFactura = db.Factura.Max(f => f.IdFactura);
                muestraAnalisis.IdAnalisis = Convert.ToInt32(item.ToString());
                muestraAnalisis.Estado = 0;
                //db.Muestra_Analisis.Add(muestraAnalisis);
                //db.SaveChanges();
            }
            
            return null;
        }

        //
        // POST: /Costo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPersona = new SelectList(db.Persona, "ID_Persona", "Nombre", factura.IdPersona);
            return View(factura);
        }

        //
        // POST: /Costo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}