using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class subCategoriaProducto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int codigo_categoria{get; set; }
        public bool activo { get; set; }
    }
}
