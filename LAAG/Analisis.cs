//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAAG
{
    using System;
    using System.Collections.Generic;
    
    public partial class Analisis
    {
        public Analisis()
        {
            this.Analisis_Dato = new HashSet<Analisis_Dato>();
            this.Muestra_Analisis = new HashSet<Muestra_Analisis>();
        }
    
        public int IdAnalisis { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Analisis_Dato> Analisis_Dato { get; set; }
        public virtual ICollection<Muestra_Analisis> Muestra_Analisis { get; set; }
    }
}
