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
        public decimal precio_costo { get; set; }

        public decimal precio_venta1 { get; set; }

        public decimal precio_venta2 { get; set; }

        public decimal precio_venta3 { get; set; }

        public decimal precio_venta4 { get; set; }

        public decimal precio_venta5 { get; set; }
    }
}
