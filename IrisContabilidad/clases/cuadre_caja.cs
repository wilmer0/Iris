using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class cuadre_caja
    {
        public int codigo { get; set; }
        public int codigo_cajero { get; set; }
        public DateTime fecha { get; set; }
        public int turno { get; set; }
        public bool activo { get; set; }
        public int codigo_sucursal { get; set; }
        public int codigo_caja { get; set; }
        public decimal efectivo_inicial { get; set; }
        public bool caja_cuadrada { get; set; }
    }
}
