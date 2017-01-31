using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class sucursal
    {
        public int codigo { get; set; }
        public int codigo_empresa { get; set; }
        public string secuencia { get; set; }
        public bool activo { get; set; }
        public string direccion { get; set; }
        public string telefono1 { get;set;}
        public string telefono2 { get; set; }
        public string fax { get; set; }

    }
}
