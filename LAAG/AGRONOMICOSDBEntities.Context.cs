﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AGRONOMICOSDBEntities : DbContext
    {
        public AGRONOMICOSDBEntities()
            : base("name=AGRONOMICOSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Analisis> Analisis { get; set; }
        public virtual DbSet<Analisis_Dato> Analisis_Dato { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Dato> Dato { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Muestra> Muestra { get; set; }
        public virtual DbSet<Muestra_Analisis> Muestra_Analisis { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<Resultado_Analisis> Resultado_Analisis { get; set; }
        public virtual DbSet<Resultado_Dato> Resultado_Dato { get; set; }
    }
}
