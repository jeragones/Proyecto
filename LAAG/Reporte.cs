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
    
    public partial class Reporte
    {
        public Reporte()
        {
            this.Resultado_Analisis = new HashSet<Resultado_Analisis>();
        }
    
        public int IdReporte { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Metodologia { get; set; }
        public string Observaciones { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Resultado_Analisis> Resultado_Analisis { get; set; }
    }
}
