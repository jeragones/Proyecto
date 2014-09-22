using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAAG
{
    [MetadataType(typeof(PersonaMetaData))]
    public partial class Persona
    {
    }
    
    public class PersonaMetaData
        {
            [Required]
            [DisplayName("Nombre")]
            public string Nombre { get; set; }

            [Required]
            [DisplayName("Primer Apellido")]
            public string Apellido1 { get; set; }

            [Required]
            [DisplayName("Segundo Apellido")]
            public string Apellido2 { get; set; }

            [Required]
            [DisplayName("Correo Electrónico")]
            public string Correo { get; set; }

            [Required]
            [DisplayName("Contraseña")]
            public string Clave { get; set; }

            [DisplayName("Fecha de Creación")]
            public Nullable<System.DateTime> FechaCreacion { get; set; }

            [Required]
            [DisplayName("Teléfono")]
            public string Telefono1 { get; set; }

            [DisplayName("Teléfono opcional")]
            public string Telefono2 { get; set; }

            [Required]
            [DisplayName("Estado")]
            public byte Estado { get; set; }

            [Required]
            [DisplayName("Tipo")]
            public byte Tipo { get; set; }

            [Required]
            [DisplayName("Nombre de Usuario")]
            public string NombreUsuario { get; set; }

            [DisplayName("Cambio de contraseña")]
            public bool PasswordChange { get; set; }
        }
}