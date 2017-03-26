using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class cxp_nota_debito
    {
        public int codigo { get; set; }
        public int codigoSuplidor { get; set; }
        public DateTime fecha;
        public bool activo { get; set; }
        public int codigoEmpleado { get; set; }
        public decimal monto { get; set; }
        public string detalle { get; set; }
        public int codigoCompra { get; set; }
        public int codigoConcepto { get; set; }
    }
}
