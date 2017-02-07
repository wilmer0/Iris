using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class cuadre_caja_detalle
    {
        public int codigo_cuadre_caja { get; set; }
        public decimal monto_efectivo { get; set; }
        public decimal monto_tarjeta { get; set; }
        public decimal monto_cheque { get; set; }
        public decimal monto_deposito { get; set; }
        public decimal monto_egreso { get; set; }
        public decimal monto_ingreso { get; set; }
        public decimal monto_sobrante { get; set; }
        public decimal monto_faltante { get; set; }

    }
}
