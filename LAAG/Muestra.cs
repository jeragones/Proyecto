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
    
    public partial class Muestra
    {
        public Muestra()
        {
            this.Muestra_Analisis = new HashSet<Muestra_Analisis>();
        }
    
        public string Codigo { get; set; }
        public string Campo { get; set; }
        public int IdPersona { get; set; }
        public int Provincia { get; set; }
        public int Canton { get; set; }
        public int Distrito { get; set; }
        public string Direccion { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Muestra_Analisis> Muestra_Analisis { get; set; }
        public virtual Provincia Provincia1 { get; set; }
    }
}
