using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_venta_detalle
    {
        public string producto { get; set; }
        public string unidad { get; set; }
        public string unidad_abreviada { get; set; }
        public decimal cantidad { get; set; }
        public decimal itbis { get; set; }
        public decimal descuento { get; set; }
        public decimal importe { get; set; }

    }
}
