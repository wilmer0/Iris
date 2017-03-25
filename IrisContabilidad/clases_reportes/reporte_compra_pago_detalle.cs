using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_pago_detalle
    {
        
        public string numero_compra { get; set; }
        public int codigoCompra { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal monto_pagado { get; set; }
        public string fecha_compra { get; set; }
        public int codigo_metodo_pago { get; set; }
        public string metodo_pago { get; set; }

        public reporte_compra_pago_detalle()
        {
            
        }

        public reporte_compra_pago_detalle(compra_vs_pagos_detalles pago)
        {
            compra compra = new modeloCompra().getCompraById(pago.codigo_compra);
            clases.metodo_pago metodoPago = new modeloMetodoPago().getMetodoPagoById(pago.codigo_metodo_pago);
            this.numero_compra = compra.numero_factura;
            this.codigoCompra = compra.codigo;
            this.monto_descuento = pago.monto_descontado;
            this.monto_pagado = pago.monto_pagado;
            this.fecha_compra = compra.fecha.ToString("dd/MM/yyyy");
            this.codigo_metodo_pago = metodoPago.codigo;
            this.metodo_pago = metodoPago.metodo;
        }

        public List<reporte_compra_pago_detalle> getListaCompraVsPagosDetallesByCompraId(int id)
        {
            try
            {
                List<reporte_compra_pago_detalle> ListaReporteCompraPagoDetalle = new List<reporte_compra_pago_detalle>();
                reporte_compra_pago_detalle reporteCompraPagoDetalle = new reporte_compra_pago_detalle();
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                lista = new modeloCompra().getListaPagosByCompra(id);

                foreach (var x in lista)
                {
                    reporteCompraPagoDetalle = new reporte_compra_pago_detalle(x);
                    ListaReporteCompraPagoDetalle.Add(reporteCompraPagoDetalle);
                }
                return ListaReporteCompraPagoDetalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraVsPagosDetallesByCompraId.:" + ex.ToString(), "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
