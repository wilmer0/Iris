using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class venta_detalle
    {
        public int codigo { get; set; }
        public int cod_venta { get; set; }
        public int codigo_producto { get; set; }
        public int codigo_unidad { get; set; }
        public decimal precio { get; set; }
        public decimal monto_itebis { get; set; }
        public decimal cantidad { get; set; }
        public decimal monto_total { get; set; }
        public decimal monto_descuento { get; set; }
        public bool activo { get; set; }
        public decimal itbis_unitario { get; set; }
        public decimal descuento_unitario { get; set; }

        public venta_detalle()
        {
            
        }

        public venta_detalle(venta_detalle detalle)
        {
            this.codigo = detalle.codigo;
            this.cod_venta = detalle.cod_venta;
            this.codigo_producto = detalle.codigo_producto;
            this.codigo_unidad = detalle.codigo_unidad;
            this.precio = detalle.precio;
            this.monto_itebis = detalle.monto_itebis;
            this.cantidad = detalle.cantidad;
            this.monto_total = detalle.monto_total;
            this.monto_descuento = detalle.monto_descuento;
            this.activo = detalle.activo;
        } 
    }
}
