namespace IrisContabilidad.clases
{
    public class desglose_dinero
    {
        public decimal efectivo { get; set; }
        public decimal tarjeta { get; set; }
        public string nombre_tarjeta { get; set; }
        public string nombre_banco { get; set; }
        public decimal deposito { get; set; }
        public string numero_cuenta_deposito { get; set; }
        public decimal cheque { get; set; }
        public string numero_cheque { get; set; }
        public decimal devuelto { get; set; }
        public decimal descuento { get; set; }
        public decimal monto_esperado { get; set; }

    }
}
