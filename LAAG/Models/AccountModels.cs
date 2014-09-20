using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace LAAG.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }


        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }


        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

       
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        
        [Display(Name = "Telefono2")]
        public string Telefono2 { get; set; }
    }

    public class RecoverPassword
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
    }

    public class SearchModel 
    {
        [Required]
        [Display(Name = "Buscar")]
        public string Buscar { get; set; }
    }

    public class ResultModel
    {

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }


        
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

       
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }


        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }


        [Display(Name = "Telefono")]
        public string Telefono { get; set; }


        [Display(Name = "Telefono2")]
        public string Telefono2 { get; set; }

    }

}
