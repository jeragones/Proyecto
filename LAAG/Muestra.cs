//------------------------------------------------------------------------------
// <auto-generated>
<<<<<<< HEAD
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
=======
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
>>>>>>> master
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
    
        public virtual Provincia Provincia1 { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Muestra_Analisis> Muestra_Analisis { get; set; }
    }
}
