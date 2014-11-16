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
                        List<string> columns = new List<string>();
                        
                        // DEPENDIENDO DEL ARCHIVO ESTO CAMBIA
                        columns.Add("Employee ID");
                        columns.Add("Contact Name");
                        columns.Add("Contact Title");
                        columns.Add("Employee Address");
                        columns.Add("Postal Code");

                        List<object> data = insLoadFile.loadFile(path, columns);
                        foreach (List<string> analisis in data) 
                        {
                            db.Muestra.Find(analisis[0]); // asumiendo que la posicion 0 es el codigo
                            /*
                             SACAR LOS DATOS DE LA LISTA
                             BUSCAR LA MUESTRA POR EL CODIGO
                             BUSCAR LOS ANALISIS PENDIENTES DE ESA MUESTRA
                             BUSCAR LOS DATOS DE LA LISTA EN LOS ANALISIS PENDIENTES
                             ASIGNARLE EL VALOR AL DATO DE LA BD
                             */
                        }

                    }
                }
            }
            /*
                string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (FileUpload.HasFile)
            {
                if (FileUpload.PostedFile.ContentType == ExcelContentType || FileUpload.PostedFile.ContentType == Excel2010ContentType) 
                {
                    try
                    {
                        
                        string fileName = string.Concat(Server.MapPath("~/TempFiles/"), FileUpload.FileName);
                        FileUpload.PostedFile.SaveAs(fileName);
                        string named = FileUpload.PostedFile.ToString();
                        string fimba = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                        string conString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", fileName);

                        //string ext = Path.GetExtension(FileUpload.PostedFile.FileName);
                        
                        
                        using (OleDbConnection con = new OleDbConnection(conString))
                        {
                            // CAMBIA ESTO
                            string query = "Select [Employee ID], [Contact Tile], [Contact Name],[Contact Title],[Employee Address],[Postal Code] from [Hoja1$]";

                            OleDbCommand cmd = new OleDbCommand(query, con);
                            if (con.State == System.Data.ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            da.Dispose();
                            con.Close();
                            con.Dispose();
                            //Import to Database
                            using (MyDatabaseEntities dc = new MyDatabaseEntities())
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    
                                    string empID = dr["Employee Id"].ToString();
                                    int y = 0;
                                    
                                    var v = dc.EmployeeMaster.Where(a => a.EmployeeID.Equals(empID)).FirstOrDefault();
                                    if (v != null)
                                    {
                                        // Update here
                                        v.CompanyName = dr["Contact Tile"].ToString();
                                        v.ContactName = dr["Contact Name"].ToString();
                                        v.ContactTitle = dr["Contact Title"].ToString();
                                        v.EmployeeAddress = dr["Employee Address"].ToString();
                                        v.PostaCode = dr["Postal Code"].ToString();
                                    }
                                    else
                                    {
                                        //insert
                                        dc.EmployeeMaster.Add(new EmployeeMaster
                                        {
                                            EmployeeID = dr["Employee Id"].ToString(),
                                            CompanyName = dr["Contact Tile"].ToString(),
                                            ContactName = dr["Contact Name"].ToString(),
                                            ContactTitle = dr["Contact Title"].ToString(),
                                            EmployeeAddress = dr["Employee Address"].ToString(),
                                            PostaCode = dr["Postal Code"].ToString()

                                        });

                                    }
                                     
                                }
                                dc.SaveChanges();
                            }
                            PopulateData();
                            lblMessage.Text = "Successfully data import done!";
                            
                        }
                        
                        
                        

                       

                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
            }
            */
               
            return RedirectToAction("Index");
        }
    }
}
