using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class empresa
    {
        public int codigo { get; set; }
        public string secuencia { get; set; }
        public string division { get; set; }
        public bool activo { get; set; }
        public string rnc { get; set; }
        public string nombre { get; set; }
        public string serie_comprobante { get; set; }
    }
}
