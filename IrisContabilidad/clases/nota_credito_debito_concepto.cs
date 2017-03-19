using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class nota_credito_debito_concepto
    {
        public int codigo { get; set; }
        public string concepto { get; set; }
        public string detalle { get; set; }
        public bool activo { get; set; }
    }
}
