using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class venta_detalle_lista
    {
        public int codigo { get; set; }
        public int codigoVenta { get; set; }
        public producto producto { get; set; }
        public int codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string codigoBarra { get; set; }
        public string referencia { get; set; }
        public unidad unidad { get; set; }
        public int codigoUnidad { get; set; }
        public string nombreUnidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public decimal itbis { get; set; }
        public decimal total { get; set; }
        public bool activo { get; set; }
    }
}
