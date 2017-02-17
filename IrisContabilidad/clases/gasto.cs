using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class gasto
    {
        public int codigo { get; set; }
        public int codigo_empleado { get; set; }
        public int codigo_tipo_gasto { get; set; }
        public int codigo_suplidor { get; set; }
        public string numero_factura { get; set; }
        public string ncf { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto_subtotal { get; set; }
        public decimal monto_itebis { get; set; }
        public decimal monto_isr { get; set; }
        public decimal monto_total { get; set; }
        public int codigo_tipo_isr { get; set; }
        public int codigo_tipo_itebis { get; set; }
        public string detalles { get; set; }
        public string detalle_anulado { get; set; }
        public bool contabilizado { get; set; }
        public bool activo { get; set; }

    }
}
