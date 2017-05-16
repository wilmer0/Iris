using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class tipo_ventas
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string nombreAbreviado { get;set; }//para tener el nombre corto ejemplo CON<CRE<COT<PED
        public bool activo { get; set; }
    }
}
