using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidad.clases
{
    public class tipoVentana
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int tamanoVentanaAncho { get; set; }
        public int tamanoVentanaAlto { get; set; }
        public int tamanoVentanaLetra { get; set; }

        public int tamanoModuloAncho { get; set; }
        public int tamanoModuloAlto { get; set; }
        public int tamanoSeparacion { get; set; }
        public int tamanoModuloLetra { get; set; }
        
    }
}
