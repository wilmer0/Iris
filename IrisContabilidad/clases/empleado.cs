using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class empleado
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string login { get; set; }
        public string clave { get; set; }
        public decimal sueldo { get; set; }
        public int codigo_situacion { get; set; }
        public bool activo { get; set; }
        public int codigo_sucursal { get; set; }
        public int codigo_departamento { get; set; }
        public int codigo_cargo { get; set; }
        public int codigo_grupo_usuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string tipo_permiso { get; set; }
        public int codigo_tipo_nomina { get; set; }
        public string identificacion { get; set; }
        public string pasaporte { get; set; }
        

    }
}
