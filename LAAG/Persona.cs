//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAAG
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persona
    {
        public Persona()
        {
            this.Factura = new HashSet<Factura>();
            this.Muestra = new HashSet<Muestra>();
            this.Reporte = new HashSet<Reporte>();
        }
    
        public int ID_Persona { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public byte Estado { get; set; }
        public byte Tipo { get; set; }
        public string NombreUsuario { get; set; }
        public bool PasswordChange { get; set; }
    
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Muestra> Muestra { get; set; }
        public virtual ICollection<Reporte> Reporte { get; set; }
    }
}
