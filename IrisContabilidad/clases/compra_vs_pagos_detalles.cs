using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class compra_vs_pagos_detalles
    {
        public int codigo { get; set; }
        public int codigo_pago { get; set; }
        public int codigo_compra { get; set; }
        public int codigo_metodo_pago { get; set; }
        public decimal monto_pagado { get; set; }
        public decimal monto_descontado { get; set; }
        public bool activo { get; set; }

        public compra_vs_pagos_detalles()
        {
            
        }

        public compra_vs_pagos_detalles(int codigoCompraPago)
        {
            compra_vs_pagos compraPago = new modeloCompra().getCompraPagoById(codigoCompraPago);
            if (compraPago == null)
            {
                return;
            }

            compra_vs_pagos_detalles listaCompraPagoDetalle = new modeloCompra().getListaCompraPagoDetalleByIdCompraPago(codigoCompraPago).FirstOrDefault();
            this.codigo = listaCompraPagoDetalle.codigo;
            this.codigo_pago = listaCompraPagoDetalle.codigo_pago;
            this.codigo_compra = listaCompraPagoDetalle.codigo_compra;
            this.codigo_metodo_pago = listaCompraPagoDetalle.codigo_metodo_pago;
            this.monto_pagado = listaCompraPagoDetalle.monto_pagado;
            this.monto_descontado = listaCompraPagoDetalle.monto_descontado;
            this.activo = listaCompraPagoDetalle.activo;
        }
    }
}
