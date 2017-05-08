using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class diario_general
    {
        public Int64 codigo { get; set; }
        public Int64 codigoAsiento { get; set; }
        public DateTime fechaSistema { get; set; }
        public DateTime fecha { get; set; }
        public int codigoCuentaContable { get; set; }
        public decimal debito { get; set; }
        public decimal credito { get; set; }
        public int codigoEmpleado { get; set; }
        public bool activo { get; set; }

    }
}
