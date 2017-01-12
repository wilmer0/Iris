using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class compra_vs_pagos_detalles
    {
        public int codigo { get; set; }
        public int codigo_pago { get; set; }
        public int codigo_compra { get; set; }
        public int codigo_metodo_pago { get; set; }
        public decimal monto_pagado { get; set; }
        public decimal monto_descontado { get; set; }
        public bool activo { get; set; }
    }
}
