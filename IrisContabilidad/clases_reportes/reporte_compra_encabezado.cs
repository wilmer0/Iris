using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_encabezado
    {
        public string empresa{ get; set; }
        public string rnc{ get; set; }
        public string direccion{ get; set; }
        public DateTime fecha_impresion { get; set; }
        public DateTime fecha_compa { get; set; }
        public DateTime fecha_limite { get; set; }
        public int codigo_compra { get; set; }
        public string numero_compra{ get; set; }
        public string tipo_compra { get; set; }
        public string empleado { get; set; }
        public int codigo_suplidor { get; set; }
        public string suplidor { get; set; }
        public string suplidor_rnc { get; set; }
        
    }
}
