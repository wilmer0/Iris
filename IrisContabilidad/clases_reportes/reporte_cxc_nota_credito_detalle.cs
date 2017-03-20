using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_cxc_nota_credito_detalle
    {
        public int codigoNotaCredito { get; set; }
        public DateTime fechaDocumento { get; set; }
        public int codigoEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public int codigoCliente { get; set; }
        public string nombreCliente { get; set; }
        public string detalle { get; set; }
        public int codigoVenta { get; set; }
        public string numeroVenta { get; set; }
        public int codigoConcepto { get; set; }
        public string concepto { get; set; }
        public decimal monto { get; set; }
    }
}
