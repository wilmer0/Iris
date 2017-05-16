using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    class venta_detalle_lista
    {
        public producto producto { get; set; }
        public Int64 codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string codigoBarra { get; set; }
        public string referencia { get; set; }
        public unidad unidad { get; set; }
        public Int64 codigoUnidad { get; set; }
        public string nombreUnidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public decimal itbis { get; set; }
        public decimal total { get; set; }

    }
}
