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
    }
}
