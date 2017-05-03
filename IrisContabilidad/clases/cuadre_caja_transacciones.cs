using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class cuadre_caja_transacciones
    {
        public int codigoCuadreCaja { get; set; }
        public int codigoVenta { get; set; }
        public int codigoCobro { get; set; }
        public int codigoIngresoCaja { get; set; }
        public int codigoEgresoCaja { get; set; }
        public int codigoNotaCredito { get; set; }
        public int codigoNotaDebito { get; set; }
        public int codigoGasto { get; set; }
        public int codigoPago { get; set; }
    }
}
