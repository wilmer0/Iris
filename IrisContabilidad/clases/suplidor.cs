using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class suplidor
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string rnc { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int codigo_sucursal_creado { get; set; }
        public decimal limite_credito { get; set; }
        public bool activo { get; set; }
        public string direccion { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public int cod_tipo_gasto { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string fax { get; set; }

    }
}
