using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class ventana
    {
        public int codigo { get; set; }
        public string nombre_ventana{ get; set; }
        public string nombre_logico { get; set; }
        public string imagen { get; set; }
        public bool activo { get; set; }
        public bool programador { get; set; }//true-> no puede verla el usuario para modificarla---false-> si puede verla y ser modificada
        public int codigo_modulo { get; set; }
    }
}
