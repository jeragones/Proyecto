using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo_Excel
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!IsPostBack)
            {
                PopulateData();
                lblMessage.Text = "current Database Data!";
            }*/
        }

        private void PopulateData() 
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                gvData.DataSource = dc.EmployeeMaster.ToList();
                gvData.DataBind();
            }
 
        }

       

        protected void btnImport_Click1(object sender, EventArgs e)
        {
            string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (FileUpload.HasFile)
            {
                if (FileUpload.PostedFile.ContentType == ExcelContentType || FileUpload.PostedFile.ContentType == Excel2010ContentType) 
                {
                    try
                    {
                        object h = FileUpload.GetType();
                        string fileName = string.Concat(Server.MapPath("~/TempFiles/"), FileUpload.FileName);
                       
                        FileUpload.PostedFile.SaveAs(fileName);
                        string named = FileUpload.PostedFile.ToString();
                        string fimba = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                        string conString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", fileName);
<<<<<<< HEAD
                     
=======

                        //string ext = Path.GetExtension(FileUpload.PostedFile.FileName);
                        
                        
>>>>>>> f4fb7993924266a9ee3e6c2c7dca316843fc8339
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
                                    /*
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
                                     */
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

            

        }
    }
}