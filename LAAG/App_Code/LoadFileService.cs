
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

        internal List<DataRow> loadFile(string fileName, string page)
        {
            List<DataRow> data = new List<DataRow>();

            try
            {
                string conString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", fileName);

                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    string query = "Select *";
                    query += " from [" + page + "$]";
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
                        data.Add(dr);
                    }
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
            return data;
        }
    }
}