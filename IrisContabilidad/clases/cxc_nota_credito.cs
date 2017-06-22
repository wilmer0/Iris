using System;

namespace IrisContabilidad.clases
{
    public class cxc_nota_credito
    {
        public int codigo { get; set; }
        public int codigoCliente { get; set; }
        public DateTime fecha;
        public bool activo { get; set; }
        public int codigoEmpleado { get; set; }
        public decimal monto { get; set; }
        public string detalle { get; set; }
        public int codigoVenta { get; set; }
        public int codigoConcepto { get; set; }
        public int codigoDevolucion { get; set; }
    }
}
