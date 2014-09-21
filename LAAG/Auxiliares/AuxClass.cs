using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAAG.Auxiliares
{
    public class AuxClass
    {
        public IQueryable<Persona> IsValidUser(string userName, string passWord)
        {
            AGRONOMICOSDBEntities myDB = new AGRONOMICOSDBEntities();
            var userResults = from u in myDB.Persona
                              where u.NombreUsuario == userName
                              && u.Clave == passWord && u.Estado == 0
                              select u;
            return userResults;
        }
    }
}