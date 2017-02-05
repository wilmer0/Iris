using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_detalle
    {
        public string producto { get; set; }
        public string unidad { get; set; }
        public string unidad_abreviada { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal monto_itebis { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal monto_total { get; set; }

        public reporte_compra_detalle()
        {
            
        }

        public reporte_compra_detalle(compra_detalle compraDetalle)
        {
            producto producto = new modeloProducto().getProductoById(compraDetalle.cod_producto);
            unidad unidad = new modeloUnidad().getUnidadById(compraDetalle.cod_unidad);

            this.producto = producto.nombre;
            this.unidad = unidad.nombre;
            this.unidad_abreviada = unidad.unidad_abreviada;
            this.cantidad = compraDetalle.cantidad;
            this.precio = compraDetalle.precio;
            this.monto_itebis = compraDetalle.monto_itebis;
            this.monto_descuento = compraDetalle.monto_descuento;
            this.monto_total = compraDetalle.monto;
        }

    }
}
