using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_ventas_mensuales_grafico_detalles
    {
        public int anoInicial { get; set; }
        public int anoFinal { get; set; }
        public int mesNumero { get; set; }
        public string mesNombre { get; set; }
        public decimal montoTotal { get; set; }
        public decimal montoItbis { get; set; }
        public decimal montoDescuento { get; set; }
        public decimal montoSubTotal { get; set; }
        public decimal montoNotaCredito { get; set; }
        public decimal montoNotaDebito { get; set; }

    }
}
