using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class cuadre_caja_detalle
    {
        public int codigo_cuadre_caja { get; set; }
        public decimal monto_efectivo { get; set; }
        public decimal monto_tarjeta { get; set; }
        public decimal monto_cheque { get; set; }
        public decimal monto_deposito { get; set; }
        public decimal monto_egreso { get; set; }
        public decimal monto_ingreso { get; set; }
        public decimal monto_sobrante { get; set; }
        public decimal monto_faltante { get; set; }
        public decimal monto_efectivo_inicial { get; set; }
        public decimal monto_credito { get; set; }
        public decimal monto_cotizacion { get; set; }
        public decimal monto_pedido { get; set; }

        //facturado
        public decimal montoFacturaContado { get; set; }
        public decimal montoFacturaCotizacion { get; set; }
        public decimal montoFacturaPedido { get; set; }
        public decimal montoFacturaCredito { get; set; }

        //cobros de ventas
        public decimal montoCobrosEfectivo { get; set; }
        public decimal montoCobrosDeposito { get; set; }
        public decimal montoCobrosCheque { get; set; }


        //montos de pagos
        public decimal montoPagoEfectivo { get; set; }
        public decimal montoPagoDeposito { get; set; }
        public decimal montoPagoCheque { get; set; }

        //gasto
        public decimal montoGasto { get; set; }

        //notas credito y debito
        public decimal montoNotasDebito { get; set; }
        public decimal montoNotasCredito { get; set; }

        //devolucion
        public decimal montoVentaDevolucion { get; set; }


        public cuadre_caja_detalle()
        {

        }
    }
}
