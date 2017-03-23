using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_nota_debito_cxc_detalle
    {
         public int codigo { get; set; }
        public int codigoCliente { get; set; }
        public string nombreCliente { get; set; }
        public decimal monto { get; set; }
        public int codigoVenta { get; set; }
        public string numeroVenta { get; set; }
        public string tipoVenta { get; set; }
        public string fechaVenta { get; set; }
        public int codigoConcepto { get; set; }
        public string concepto { get; set; }
        public string detalle { get; set; }

        //objetos
        utilidades utilidades=new utilidades();


        public reporte_nota_debito_cxc_detalle()
        {
            
        }

        public reporte_nota_debito_cxc_detalle(cxc_nota_debito nota)
        {
            cliente cliente = new modeloCliente().getClienteById(nota.codigoCliente);
            venta venta = new modeloVenta().getVentaById(nota.codigoVenta);
            nota_credito_debito_concepto concepto = new modeloNotaCreditoDebitoConcepto().getConceptoById(nota.codigoConcepto);

            this.codigo = nota.codigo;
            this.codigoCliente = nota.codigoCliente;
            this.nombreCliente = cliente.nombre;
            this.monto = nota.monto;
            this.codigoVenta = venta.codigo;
            this.numeroVenta = venta.numero_factura;
            this.tipoVenta = venta.tipo_venta;
            this.fechaVenta = utilidades.getFechaddMMyyyy(venta.fecha);
            this.codigoConcepto = concepto.codigo;
            this.concepto = concepto.concepto;
            this.detalle = nota.detalle;

        }
    }
}
