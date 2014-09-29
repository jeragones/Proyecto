using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAAG.AuxFiles
{
    public class AuxClass
    {
        AGRONOMICOSDBEntities myDB = new AGRONOMICOSDBEntities();

        public IQueryable<Persona> IsValidUser(string userName, string passWord)
        {    
            var userResults = from u in myDB.Persona
                              where u.NombreUsuario == userName
                              && u.Clave == passWord
                              select u;
            return userResults;
        }

        public IQueryable<Persona> GetPerson(string userName) 
        {
            var userResults = from u in myDB.Persona
                              where u.NombreUsuario == userName
                              select u;
            return userResults;
        }
    }
}