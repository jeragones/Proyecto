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
    
    public partial class Analisis_Dato
    {
        public int IdAnalisisDato { get; set; }
        public int IdAnalisis { get; set; }
        public int IdDato { get; set; }
    
        public virtual Analisis Analisis { get; set; }
    }
}
