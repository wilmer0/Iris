using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_detalle
    {
        public string producto { get; set; }
        public string unidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal monto_itebis { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal monto_total { get; set; }

    }
}
