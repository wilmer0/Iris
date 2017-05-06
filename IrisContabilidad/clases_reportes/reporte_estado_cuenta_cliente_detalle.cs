using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_estado_cuenta_cliente_detalle
    {
        public int idCliente { get; set; }
        public string cliente { get; set; }
        public string cedula { get; set; }
        public string rnc { get; set; }
        public string telefonos { get; set; }
        public decimal montoFacturado { get; set; }
        public decimal montoCobrado { get; set; }
        public decimal montoPendiente { get; set; }
        public decimal montoNotasCredito { get; set; }
        public decimal montoNotasDebito { get; set; }
        

        public reporte_estado_cuenta_cliente_detalle()
        {
            
        }

        public reporte_estado_cuenta_cliente_detalle(cliente cliente)
        {
            try
            {
                this.idCliente = cliente.codigo;
                this.cliente = cliente.nombre;
                this.cedula = cliente.cedula;
                this.rnc = cliente.rnc;
                this.telefonos = cliente.telefono1 + " - " + cliente.telefono2;
                this.montoFacturado = new modeloVenta().getMontoFacturadoByClienteId(cliente.codigo);
                this.montoPendiente = new modeloVenta().getMontoPendienteByClienteId(cliente.codigo);
                this.montoCobrado = new modeloVenta().getMontoCobradoByClienteId(cliente.codigo);
                this.montoNotasCredito = new modeloVenta().getMontoNotasCreditoByClienteId(cliente.codigo);
                this.montoNotasDebito = new modeloVenta().getMontoNotasDebitoByClienteId(cliente.codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reporte_estado_cuenta_cliente_detalle.:"+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);   
            }
        }
    }
}
