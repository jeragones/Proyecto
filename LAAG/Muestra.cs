//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAAG
{
    using System;
    using System.Collections.Generic;
    
    public partial class Muestra
    {
        public Muestra()
        {
            this.Muestra_analisis = new HashSet<Muestra_analisis>();
        }
    
        public string Codigo { get; set; }
        public string Campo { get; set; }
        public int IdCliente { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string UsuarioCracion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Muestra_analisis> Muestra_analisis { get; set; }
    }
}
