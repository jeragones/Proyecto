using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAAG.App_Code
{
    public class LoadFileService
    {
        public List<object> loadFile(FileUpload file, List<string> columns) { 
            List<object> data = new List<object>();

            string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (file.HasFile)
            {
                if (file.PostedFile.ContentType == ExcelContentType || file.PostedFile.ContentType == Excel2010ContentType)
                {
                    try
                    {

                        string fileName = string.Concat(Server.MapPath("~/TempFiles/"), file.FileName);
                        FileUpload.PostedFile.SaveAs(fileName);
                        string conString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", fileName);

                        using (OleDbConnection con = new OleDbConnection(conString))
                        {
                            string query = "Select";
                            for (int i = 0; i < columns.Count; i++) 
                            {
                                if (i > 0)
                                    query += ",";
                                query += " [" + columns[i] + "]";
                            }
                            query += "from [Hoja1$]";
                            //string query = "Select [Employee ID], [Contact Tile], [Contact Name],[Contact Title],[Employee Address],[Postal Code] from [Hoja1$]";

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

            return null;
        }
    }
}