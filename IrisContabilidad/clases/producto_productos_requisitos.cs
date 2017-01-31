using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class producto_productos_requisitos
    {
        public int codigo_producto_titular { get; set; }
        public int codigo_producto_requisito { get; set; }
        public int codigo_unidad { get; set; }
        public decimal cantidad { get; set; }
    }
}
