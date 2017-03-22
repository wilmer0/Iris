using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class venta_detalle
    {
        public int codigo { get; set; }
        public int cod_venta { get; set; }
        public int codigo_producto { get; set; }
        public int codigo_unidad { get; set; }
        public decimal precio { get; set; }
        public decimal monto_itebis { get; set; }
        public decimal cantidad { get; set; }
        public decimal monto_total { get; set; }
        public decimal monto_descuento { get; set; }
        public bool activo { get; set; }

       
    }
}
