using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_producto_encabezado
    {
        public string producto { get; set; }
        public string referencia { get; set; }
        public int codigo_unidad_minima { get; set; }
        public int codigo_itebis { get; set; }
        public int codigo_categoria { get; set; }
        public int codigo_subcategoria { get; set; }
        public int codigo_almacen { get; set; }

    }
}
