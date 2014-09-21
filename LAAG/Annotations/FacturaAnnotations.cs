using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LAAG {
    [MetadataType(typeof(FacturaMetaData))]
    public partial class Factura {
        public class FacturaMetaData
        {
            public int IdFactura { get; set; }

            [DataType(DataType.Date)]
            public System.DateTime Fecha { get; set; }

            [DisplayName("Cerote")]
            public int Costo { get; set; }
            public int IdCliente { get; set; }
            public string UsuarioCreacion { get; set; }
            public System.DateTime FechaCreacion { get; set; }
            public string UsuarioActualizacion { get; set; }
            public Nullable<System.DateTime> FechaActualizacion { get; set; }
        }
    }
}