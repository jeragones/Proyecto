using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAAG
{
    public partial class Facturas
    {
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        
        [DisplayName("Costo")]
        public int Costo { get; set; }

        [Required]
        [DisplayName("Campo")]
        public string Campo { get; set; }
        
        [DisplayName("Provincia")]
        public int Provincia { get; set; }
        
        [DisplayName("Cantón")]
        public int Canton { get; set; }
        
        [DisplayName("Distrito")]
        public int Distrito { get; set; }
        
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        
        [DisplayName("Categoría")]
        public int Categoria { get; set; }

        [DisplayName("Análisis")]
        public int Analisis { get; set; }
    }
}