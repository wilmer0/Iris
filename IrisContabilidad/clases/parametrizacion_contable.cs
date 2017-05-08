using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class parametrizacion_contable
    {
        //aqui van todas las cuentas contables por default

        //caja efectivo
        public int codigo_cuenta_caja_efectivo { get; set; }
        
        //compras mercancias
        public int codigo_cuenta_compra { get; set; }
        
        //suplidores
        public int codigo_cuenta_suplidores { get; set; }
        
        //gastos
        public int codigo_cuenta_gastos { get; set; }
        
        //ingresos cobros de ventas
        public int codigo_cuenta_ingresos_cobros_venta { get; set; }
        
        //itbis
        public int codigo_cuenta_itbis { get; set; }
        
        //flete o trasporte
        public int codigo_cuenta_flete { get; set; }


    }
}
