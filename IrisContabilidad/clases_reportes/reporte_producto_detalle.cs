using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_producto_detalle
    {
        public int codigo_producto { get; set; }
        public string nombre { get; set; }
        public string referencia { get; set; }
        public string itebis { get; set; }
        public string categoria { get; set; }
        public string subcategoria { get; set; }
        public string almacen { get; set; }
        public string unidad_minima { get; set; }
        public decimal existencia { get; set; }
       

    }
}
