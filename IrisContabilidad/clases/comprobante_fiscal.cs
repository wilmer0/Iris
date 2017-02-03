using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class comprobante_fiscal
    {
        public int codigo { get; set; }
        public int codigo_serie { get; set; }
        public int codigo_caja { get; set; }
        public int codigo_tipo { get; set; }
        public int numero_desde { get; set; }
        public int numero_hasta { get; set; }
        public int contador { get; set; }
        public int numero_avisar { get; set; }
        public DateTime fecha { get; set; }
    }
}
