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

        /*
         `empresa` int(11) NOT NULL DEFAULT '0',
  `anticipo_cliente` int(11) DEFAULT NULL,
  `descuento_pronto_pago` int(11) DEFAULT NULL,
  `itbis_adelanto_compras` int(11) DEFAULT NULL,
  `itbis_adelento_compra_bienes_servicios` int(11) DEFAULT NULL,
  `itbis_ventas` int(11) DEFAULT NULL,
  `itbis_retenido_servicio` int(11) DEFAULT NULL,
  `isr_retenido_servicio` int(11) DEFAULT NULL,
  `flete_pago_compras` int(11) DEFAULT NULL,
  `descuento_compras` int(11) DEFAULT NULL,
  `flete_ventas` int(11) DEFAULT NULL,
  `otras_ventas` int(11) DEFAULT NULL,
  `ventas` int(11) DEFAULT NULL,
  `compras` int(11) DEFAULT NULL,
  `suplidores` int(11) DEFAULT NULL,
  `caja` int(11) DEFAULT NULL,
  `compras_fanegas` int(11) DEFAULT NULL,
         */
    }
}
