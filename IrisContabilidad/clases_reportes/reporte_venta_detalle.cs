using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_venta_detalle
    {
        public string producto { get; set; }
        public string unidad { get; set; }
        public string unidad_abreviada { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal itbis { get; set; }
        public decimal descuento { get; set; }
        public decimal importe { get; set; }

        public reporte_venta_detalle()
        {
            
        }

        public reporte_venta_detalle(venta_detalle ventaDetalle)
        {
            producto producto = new modeloProducto().getProductoById(ventaDetalle.codigo_producto);
            unidad   unidad = new modeloUnidad().getUnidadById(ventaDetalle.codigo_unidad);
            this.producto = producto.nombre;
            this.unidad = unidad.nombre;
            this.unidad_abreviada = unidad.unidad_abreviada;
            this.cantidad = ventaDetalle.cantidad;
            this.precio = ventaDetalle.precio;
            this.itbis = ventaDetalle.monto_itebis;
            this.descuento = ventaDetalle.monto_descuento;
            this.importe = ventaDetalle.monto_total;
        }
    }
}
