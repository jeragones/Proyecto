using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace LAAG.Models
{
    public class ContactModel
    {
        [Display(Name = "Email")]
        public string Tipo { get; set; }


        [Required]
        [Display(Name = "Subject")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Body")]
        public string Apellidos { get; set; }

    }
}