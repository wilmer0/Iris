using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class metodo_pago
    {
        public int codigo { get; set; }
        public string metodo { get; set; }
        public string detalle { get; set; }
        public bool activo { get; set; }
    }
}
