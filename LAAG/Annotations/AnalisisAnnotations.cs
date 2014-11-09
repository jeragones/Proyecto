using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAAG
{
    [MetadataType(typeof(AnalisisMetaData))]
    public partial class Analisis
    {
    }
    
    public class AnalisisMetaData
        {
            [Required]
            [DisplayName("Nombre")]
            public string Nombre { get; set; }

            [Required]
            [DisplayName("Categoría")]
            public int IdCategoria { get; set; }

            [DisplayName("Descripción")]
            public string Descripcion { get; set; }
        }
}