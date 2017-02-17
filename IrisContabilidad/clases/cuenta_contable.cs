using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class cuenta_contable
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string numero_cuenta { get; set; }
        public int cuenta_superior { get; set; }
        public bool cuenta_acumulativa { get; set; }
        public bool cuenta_movimiento { get; set; }
        public bool origen_credito { get; set; }
        public bool origen_debito { get; set; }
        public bool activo { get; set; }
    }
}
