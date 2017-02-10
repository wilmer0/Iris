using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class compra
    {
        public int codigo { get; set; }
        public string numero_factura { get; set; }
        public int cod_suplidor { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fecha_limite { get; set; }
        public string ncf { get; set; }
        public string tipo_compra { get; set; }
        public bool activo { get; set; }
        public bool pagada { get; set; }
        public int codigo_sucursal { get; set; }
        public int codigo_empleado { get; set; }
        public int codigo_empleado_anular { get; set; }
        public string motivo_anulada { get; set; }
        public string detalle { get; set; }
        public bool suplidor_informal { get; set; }

    }
}
