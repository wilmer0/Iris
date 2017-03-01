using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class tipoRetencionItbis
    {
        public int codigo { get; set; }
        public string retencion { get; set; }
        public decimal porciento_retencion { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
    }
}
