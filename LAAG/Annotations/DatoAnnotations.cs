using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAAG
{
    [MetadataType(typeof(DatoMetaData))]
    public partial class Dato
    {
    }
    
    public class DatoMetaData
        {
            [Required]
            [DisplayName("Nombre")]
            public string Nombre { get; set; }

            [Required]
            [DisplayName("Unidad de Medida")]
            public string unidadMedida { get; set; }
        }
}