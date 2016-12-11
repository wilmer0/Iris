using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidadModelo.modelos
{
    public class DatosConeccionBD
    {
        public String Servidor { get; set; }
        public String BaseDatos { get; set; }
        public String Usuario { get; set; }
        public String Contrasena { get; set; }
        public String Puerto { get; set; }
    }
}
