using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace LAAG.Controllers.MyControllers
{
    class LoadFileService
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        internal List<DataRow> loadFile(string fileName, /*List<string> columns,*/ string page)
        {
            List<DataRow> data = new List<DataRow>();

            try 
            {
                string conString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", fileName);

                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    //if (columns.Count > 0) 
                    //{
                        string query = "Select *";
                        //for (int i = 0; i < columns.Count; i++)
                        //{
                        //    if (i > 0)
                        //        query += ",";
                        //    query += " [" + columns[i] + "]";
                        //}

                        query += " from ["+page+"$]";
                        // "Select [Employee ID], [Contact Tile], [Contact Name],[Contact Title],[Employee Address],[Postal Code] from [Hoja1$]"
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

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //List<DataRow> list = new List<DataRow>();
                            //for (int i = 0; i < columns.Count; i++)
                            
                                //list.Add(dr);
                                data.Add(dr);
                        }
                    //}
                }
            } 
            catch(Exception e)
            {
                string err = e.Message;
            }

            return data;
        }
    }
}
