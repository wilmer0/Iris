using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class caja
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string secuencia { get; set; }
        public int codigo_sucursal { get; set; }
        public bool activo { get; set; }
    }
}
