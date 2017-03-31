using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_ventas_mensuales_grafico_detalles
    {
        public int anoNumero { get; set; }
        public int mesNumero { get; set; }
        public string mesNombre { get; set; }
        public decimal montoTotal { get; set; }
        public decimal montoItbis { get; set; }
        public decimal montoDescuento { get; set; }
        public decimal montoSubTotal { get; set; }
        public decimal montoNotaCredito { get; set; }
        public decimal montoNotaDebito { get; set; }

        public  reporte_ventas_mensuales_grafico_detalles()
        {
            
        }

        public  reporte_ventas_mensuales_grafico_detalles(venta venta)
        {
            try
            {
                List<cxc_nota_credito> listaNotaCredito=new List<cxc_nota_credito>();
                List<cxc_nota_debito> listaNotaDebito=new List<cxc_nota_debito>();
                List<venta_detalle> listaVentaDetalle=new List<venta_detalle>();
                listaVentaDetalle = new modeloVenta().getListaVentaDetalle(venta.codigo);
                listaNotaCredito = new modeloCxcNotaCredito().getListaByVentaActivo(venta.codigo);
                listaNotaDebito = new modeloCxcNotaDebito().getListaByVentaActivo(venta.codigo);
                this.anoNumero = venta.fecha.Year;
                this.mesNumero = venta.fecha.Month;
                this.mesNombre = venta.fecha.Month.ToString();
                this.montoTotal = listaVentaDetalle.Sum(s => s.monto_total);
                this.montoItbis = listaVentaDetalle.Sum(s => s.monto_itebis);
                this.montoDescuento = listaVentaDetalle.Sum(s => s.monto_descuento);
                this.montoSubTotal = montoTotal - montoItbis;
                this.montoNotaDebito = listaNotaDebito.Sum(s=> s.monto);
                this.montoNotaCredito = listaNotaCredito.Sum(s => s.monto);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reporte_ventas_mensuales_grafico_detalles.: " + ex.ToString(), "",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
