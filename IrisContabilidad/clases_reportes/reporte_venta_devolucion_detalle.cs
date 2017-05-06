using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_venta_devolucion_detalle
    {
        public int codigo { get; set; }
        public int codigoDevolucion { get; set; }
        public int codigoProducto { get; set; }
        public string producto { get; set; }
        public int codigoUnidad { get; set; }
        public string unidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal montoTotal { get; set; }

        public reporte_venta_devolucion_detalle()
        {
            
        }
        public reporte_venta_devolucion_detalle(ventaDevolucionDetalle devolucionDetalle)
        {
            producto producto=new producto();
            unidad unidad=new unidad();

            this.codigo = devolucionDetalle.codigo;
            this.codigoDevolucion = devolucionDetalle.codigo_devolucion;
            this.codigoProducto = devolucionDetalle.codigo_producto;
            producto = new modeloProducto().getProductoById(devolucionDetalle.codigo_producto);
            unidad = new modeloUnidad().getUnidadById(devolucionDetalle.codigo_unidad);
            this.producto = producto.nombre;
            this.unidad = unidad.nombre;
            this.cantidad = devolucionDetalle.cantidad;
            this.precio = devolucionDetalle.precio;
            this.montoTotal = devolucionDetalle.monto_total;
        }
    }
}
