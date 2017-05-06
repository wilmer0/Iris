namespace IrisContabilidad.clases_reportes
{
    public class reporte_venta_cobro_detalle
    {
        public int codigo { get; set; }
        public int codigo_cobro { get; set; }
        public string numero_venta { get; set; }
        public int codigo_venta { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal monto_cobrado { get; set; }
        public string fecha_venta { get; set; }
        public int codigo_metodo_cobro { get; set; }
        public string metodo_cobro { get; set; }
        public bool activo { get; set; }
    }
}
