using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LAAG {
    [MetadataType(typeof(PersonaMetaData))]
    public partial class Persona {
        public class PersonaMetaData
        {
            [DisplayName("Identificador")]
            [Required]
            public int ID_Persona { get; set; }
            [Required]
            [DisplayName("Nombre")]
            public string Nombre { get; set; }
            public string Apellido1 { get; set; }
            public string Apellido2 { get; set; }
            public string Correo { get; set; }
            public string Clave { get; set; }
            public Nullable<System.DateTime> FechaCreacion { get; set; }
            public string Telefono1 { get; set; }
            public string Telefono2 { get; set; }
            public string UsuarioCreacion { get; set; }
            public Nullable<System.DateTime> FechaActualizacion { get; set; }
            public string UsuarioActualizacion { get; set; }
            public byte Estado { get; set; }
            public byte Tipo { get; set; }
            [Required]
            [DisplayName("Usuario")]
            public string NombreUsuario { get; set; }
            public bool PasswordChange { get; set; }
        }
    }
}