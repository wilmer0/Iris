using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class producto
    {
        
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string referencia { get; set; }
        public bool activo { get; set; }
        public decimal reorden { get; set; }
        public decimal punto_maximo { get; set; }
        public int codigo_itebis { get; set; }
        public int codigo_categoria { get; set; }
        public int codigo_subcategoria { get; set; }
        public int codigo_almacen { get; set; }
        public string imagen { get; set; }
        public int codigo_unidad_minima { get; set; }
        public Boolean controla_inventario { get; set; }

    }
}
