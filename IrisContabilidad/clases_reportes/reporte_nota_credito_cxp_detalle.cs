using System.Collections.Generic;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_nota_credito_cxp_detalle
    {
         public int codigo { get; set; }
        public int codigoSuplidor { get; set; }
        public string nombreSuplidor { get; set; }
        public decimal monto { get; set; }
        public int codigoCompra { get; set; }
        public string numeroCompra { get; set; }
        public string tipoCompra { get; set; }
        public string fechaCompra { get; set; }
        public int codigoConcepto { get; set; }
        public string concepto { get; set; }
        public string detalle { get; set; }
        public int codigoEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public List<compraDevolucionDetalle> listaDevolucionDetalle { get; set; }


        //objetos
        utilidades utilidades=new utilidades();


        public reporte_nota_credito_cxp_detalle()
        {
            
        }

        public reporte_nota_credito_cxp_detalle(cxp_nota_credito nota)
        {
            suplidor suplidor = new modeloSuplidor().getSuplidorById(nota.codigoSuplidor);
            compra compra = new modeloCompra().getCompraById(nota.codigoCompra);
            nota_credito_debito_concepto concepto = new modeloNotaCreditoDebitoConcepto().getConceptoById(nota.codigoConcepto);
            empleado empleado = new modeloEmpleado().getEmpleadoById(nota.codigoEmpleado);

            this.codigo = nota.codigo;
            this.codigoSuplidor = nota.codigoSuplidor;
            this.nombreSuplidor = suplidor.nombre;
            this.monto = nota.monto;
            this.codigoCompra = compra.codigo;
            this.numeroCompra =compra.numero_factura;
            this.tipoCompra = compra.tipo_compra;
            this.fechaCompra = utilidades.getFechaddMMyyyy(compra.fecha);
            this.codigoConcepto = concepto.codigo;
            this.concepto = concepto.concepto;
            this.detalle = nota.detalle;
            this.codigoEmpleado = empleado.codigo;
            this.nombreEmpleado = empleado.nombre;
            this.listaDevolucionDetalle =new modeloCompraDevolucion().getListaCompraDevolucionDetalleByDevolucionId(nota.codigoDevolucion);
        }
    }
}
