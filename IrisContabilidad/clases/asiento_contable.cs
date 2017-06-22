using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class asiento_contable
    {
        public Int64 codigo { get; set; }
        public Int64 codigoAsiento { get; set; }
        public DateTime fechaSistema { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public int codigoCuenta { get; set; }
        public bool debito { get; set; }
        public bool credito { get; set; }
        public bool activo { get; set; }
    
    
    
    
    
    }
}
