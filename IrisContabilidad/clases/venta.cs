using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class venta
    {
        public int codigo { get; set; }
        public string numero_factura{ get; set; }
        public DateTime fecha { get; set; }
        public DateTime fecha_limite { get; set; }
        public int codigo_empleado { get; set; }
        public int codigo_cliente { get; set; }
        public string ncf { get; set; }
        public string tipo_venta { get; set; }
        public int codigo_sucursal { get; set; }
        public bool activo { get; set; }
        public bool pagada { get; set; }
        public int codigo_empelado_anular { get; set; }
        public string motivo_anulada { get; set; }
        public int codigo_vendedor { get; set; }
        public bool despachado { get; set; }
        public bool autorizar_pedido { get; set; }
        public bool cuadrado { get; set; }
        public string detalle { get; set; }
        public int codigo_tipo_comprobante { get; set; }
        public bool pedido { get; set; }
        public decimal monto_impuesto { get; set; }


    }
}
