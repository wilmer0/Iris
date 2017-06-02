namespace IrisContabilidad.clases
{
    public class compra_detalle
    {
        public int codigo { get; set; }
        public int cod_compra { get; set; }
        public int cod_producto { get; set; }
        public int cod_unidad { get; set; }
        public decimal precio { get; set; }
        public decimal monto_itebis { get; set; }
        public decimal cantidad { get; set; }
        public decimal monto { get; set; }
        public decimal monto_descuento { get; set; }
        public bool activo { get; set; }
        public decimal itebis_unitario { get; set; }
        public decimal descuento_unitario { get; set; }
        public decimal monto_total { get; set; }

        public compra_detalle()
        {
            
        }

    }
}
