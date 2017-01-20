using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_venta_encabezado
    {
        public string empresa { get; set; }
        public string direccion { get; set; }
        public string rnc { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string fax { get; set; }
        public DateTime fecha_venta { get; set; }
        public DateTime fecha_impresion { get; set; }
        public string tipo_comprobante_fiscal { get; set; }
        public string numero_comprobante_fiscal { get; set; }
        public string numero_impresion_fiscal { get; set; }
        public string cajero { get; set; }
        public string cliente { get; set; }
        public string vendedor { get; set; }
        public string caja { get;set;}


    }
}
