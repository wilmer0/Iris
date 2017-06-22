using System.Linq;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class venta_vs_cobros_detalles
    {
        public int codigo { get; set; }
        public int codigo_cobro { get; set; }
        public int codigo_venta { get; set; }
        public int codigo_metodo_cobro { get; set; }
        public decimal monto_cobrado { get; set; }
        public decimal monto_descontado { get; set; }
        public bool activo { get; set; }
        public decimal monto_subtotal { get; set; }
        public decimal monto_devuelta { get; set; }

        public venta_vs_cobros_detalles()
        {
            
        }

        public venta_vs_cobros_detalles(int codigoVentaPago)
        {
            venta_vs_cobros ventaCobro = new modeloVenta().getVentaCobroById(codigoVentaPago);
            if (ventaCobro == null)
            {
                return;
            }

            venta_vs_cobros_detalles listaCompraPagoDetalle = new modeloVenta().getListaVentaCobroDetalleByIdVentaCobro(codigoVentaPago).FirstOrDefault();
            this.codigo = listaCompraPagoDetalle.codigo;
            this.codigo_cobro = listaCompraPagoDetalle.codigo_cobro;
            this.codigo_venta = listaCompraPagoDetalle.codigo_venta;
            this.codigo_metodo_cobro = listaCompraPagoDetalle.codigo_metodo_cobro;
            this.monto_cobrado = listaCompraPagoDetalle.monto_cobrado;
            this.monto_descontado = listaCompraPagoDetalle.monto_descontado;
            this.monto_subtotal = listaCompraPagoDetalle.monto_subtotal;
            this.activo = listaCompraPagoDetalle.activo;
        }
    }
}
