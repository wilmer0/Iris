using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_cobros_detalle
    {
        public int idCliente { get; set; }
        public string cliente { get; set; }
        public int idVenta { get; set; }
        public string NCF { get; set; }
        public decimal montoFactura { get; set; }
        public decimal montoCobrado { get; set; }
        public decimal montoPendiente { get; set; }

    }
}
