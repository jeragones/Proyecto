using System.Linq;
namespace LAAG
{
    partial class DataDataContext
    {
        public bool IsValidUser(string userName, string passWord)
        {
            DataDataContext myDB = new DataDataContext();
            var userResults = from u in myDB.Persona
                              where u.NombreUsuario == userName
                              && u.Clave == passWord
                              select u;
            return Enumerable.Count(userResults) > 0;
        }
    }
}
