using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_cobros_detalle
    {
        public int idCliente { get; set; }
        public string cliente { get; set; }
        public string clienteIdentificacion { get; set; }
        public int idVenta { get; set; }
        public string NCF { get; set; }
        public string tipoVenta { get; set; }
        public string fechaVenta { get; set; }
        public decimal montoFactura { get; set; }
        public decimal montoCobrado { get; set; }
        public decimal montoPendiente { get; set; }

        public reporte_cobros_detalle()
        {
            
        }

        public reporte_cobros_detalle(int idVenta)
        {
            venta venta = new venta();
            venta_vs_cobros_detalles cobroDetalle=new venta_vs_cobros_detalles();
            cliente cliente=new cliente();
            venta = new modeloVenta().getVentaById(idVenta);
            if (venta == null)
            {
                return;
            }

            cliente = new modeloCliente().getClienteById(venta.codigo_cliente);
            //llenando datos
            this.idCliente = venta.codigo_cliente;
            this.cliente = cliente.nombre;
            this.clienteIdentificacion = "";
            if (cliente.rnc != null)
            {
                this.clienteIdentificacion = cliente.rnc;
            }
            else if(cliente.cedula!=null)
            {
                this.clienteIdentificacion = cliente.cedula;
            }
            this.idVenta = venta.codigo;
            this.NCF = venta.ncf;
            this.tipoVenta = venta.tipo_venta;
            this.fechaVenta = new utilidades().getFechaddMMyyyy(venta.fecha);
            this.montoPendiente = new modeloVenta().getMontoPendienteByVenta(venta.codigo);
            this.montoFactura = new modeloVenta().getMontoFacturaByVenta(venta.codigo);
            this.montoCobrado = new modeloVenta().getMontoCobradoByVenta(venta.codigo);
        }
    }
}
