﻿//------------------------------------------------------------------------------
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
    
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Muestra> Muestra { get; set; }
        public DbSet<Muestra_analisis> Muestra_analisis { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Reporte> Reporte { get; set; }
        public DbSet<Resultado_analisis> Resultado_analisis { get; set; }
        public DbSet<Resultado_elemento> Resultado_elemento { get; set; }
        public DbSet<Analisis> Analisis { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}
