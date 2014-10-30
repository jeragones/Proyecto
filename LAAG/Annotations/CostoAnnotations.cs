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
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        
        [DisplayName("Costo")]
        public int Costo { get; set; }
        
        [DisplayName("Campo")]
        public string Campo { get; set; }
        
        [DisplayName("Provincias")]
        public int Provincia { get; set; }
        
        [DisplayName("Cantones")]
        public int Canton { get; set; }
        
        [DisplayName("Distritos")]
        public int Distrito { get; set; }
        
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        
        [DisplayName("Categorías")]
        public int Categoria { get; set; }

        [DisplayName("Análisis")]
        public int Analisis { get; set; }
    }
}