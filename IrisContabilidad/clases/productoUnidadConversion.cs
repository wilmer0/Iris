using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class productoUnidadConversion
    {
        public int codigo_producto { get; set; }
        public int codigo_unidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio_venta { get; set; }
        public decimal precio_costo { get; set; }

    }
}
