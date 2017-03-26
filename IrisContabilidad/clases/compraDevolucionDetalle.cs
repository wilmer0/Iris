using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class compraDevolucionDetalle
    {
        public int codigo { get; set; }
        public int codigo_devolucion { get; set; }
        public int codigo_producto { get; set; }
        public int codigo_unidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal monto_total { get; set; }
    }
}
