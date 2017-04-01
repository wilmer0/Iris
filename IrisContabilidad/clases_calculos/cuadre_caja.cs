using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;

namespace IrisContabilidad.clases_calculos
{
    public class cuadre_caja
    {
        //variables del cuadre de caja
        public decimal montoEfectivoInicial { get; set; }
        public decimal montoFacturaEfectivo { get; set; }
        public decimal montoCobrosEfectivo { get; set; }
        public decimal montoIngresosCaja { get; set; }
        public decimal montoNotascredito { get; set; }
        public decimal montoNotasDebito { get; set; }
        public decimal montoTarjeta { get; set; }
        public decimal montoCheque { get; set; }
        public decimal montoDeposito { get; set; }
        public decimal montoSobradnte { get; set; }
        public decimal montoFaltante { get; set; }
        public decimal montoPagosCompraEfectivo { get; set; }
        public decimal montoEgresosCajaEfectivo { get; set; }
        public decimal montoGastosEfectivo { get; set; }
        public List<cuadre_caja_detalle> listaCuadreCajaDetalle { get; set; }
    }
}
