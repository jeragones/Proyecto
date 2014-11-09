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
        public ActionResult Canton(int id)
        {
            List<Object> listCantons = new List<Object>();
            ICollection<Canton> cantons = db.Provincia.Find(id).Canton;

            foreach (var item in cantons) 
            {
                listCantons.Add(new { id = item.ID_Canton, nombre = item.nombre });
            }

            var json = new JavaScriptSerializer().Serialize(listCantons);

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Costo/distrito
        //[HttpPost]
        public ActionResult Distrito(int id)
        {
            List<Object> listDistricts = new List<Object>();
            ICollection<Distrito> districts = db.Canton.Find(id).Distrito;

            foreach (var item in districts)
            {
                listDistricts.Add(new { id = item.ID_Distrito, nombre = item.nombre });
            }

            var json = new JavaScriptSerializer().Serialize(listDistricts);

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
            /*
            var consult = from row in db.Muestra
                          select row;*/
            var consult = db.Muestra.ToList();

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
            //String tmp1 = ;
            Object tmp2 = json.muestra;
            if (!"[]".Equals(json.id.ToString())) 
            {
                Analisis analisis = db.Analisis.Find(Convert.ToInt32(json.id[0].ToString()));

                Categoria categoria = db.Categoria.Find(analisis.IdCategoria);

                var consult = db.Muestra.ToList();
                /*
                var consult = from row in db.Muestra
                              select row;*/

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
                muestra.Codigo = codigo;
                muestra.Campo = json.muestra.campo;
                muestra.IdPersona = json.muestra.id;
                muestra.Provincia = json.muestra.provincia;
                muestra.Canton = json.muestra.canton;
                muestra.Distrito = json.muestra.distrito;
                muestra.Direccion = json.muestra.direccion;
                db.Muestra.Add(muestra);
                db.SaveChanges();

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
                db.Factura.Add(factura);
                db.SaveChanges();

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
                    db.Muestra_Analisis.Add(muestraAnalisis);
                    db.SaveChanges();
                }
            }
            else
            {
                return RedirectToAction("Create");
            }

            return RedirectToAction("Index");
        }

        // GET: Obtener un analisis
        public ActionResult Agregar(int? id)
        {
            List<Object> analisis = new List<Object>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // SE busca el id de ingeniero en la lista de ingenieros
            Analisis consult = db.Analisis.Find(id);

            if (analisis == null)
            {
                //Si no se encuetra una coincidencia se retorna un NotFound
                return HttpNotFound();
            }
            else
            {
                analisis.Add(consult.IdAnalisis);
                analisis.Add(consult.Nombre);
                analisis.Add(consult.Costo);
            }

            //Se procede a convertir a JSON el objeto recien creado
            var json = new JavaScriptSerializer().Serialize(analisis);

            //Se retorna el JSON
            return Json(json, JsonRequestBehavior.AllowGet);
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
        // GET: /Costo/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 1) 
        {
            int ids = 1;
            Muestra muestra = db.Muestra.Find(id);
            db.Muestra.Remove(muestra);
            db.SaveChanges();

            var lstAnalisis = from row in db.Muestra_Analisis
                              where row.Codigo == muestra.Codigo
                              select row;

            foreach (var item in lstAnalisis) 
            {
                ids = item.IdFactura;
                db.Muestra_Analisis.Remove(item);
                db.SaveChanges();
            }

            Factura factura = db.Factura.Find(ids);
            db.Factura.Remove(factura);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}