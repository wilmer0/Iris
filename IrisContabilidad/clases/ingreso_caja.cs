using System;

namespace IrisContabilidad.clases
{
    public class ingreso_caja
    {
        public int codigo { get; set; }
        public int codigo_concepto { get; set; }
        public DateTime fecha { get; set; }
        public int codigo_cajero { get; set; }
        public decimal monto { get; set; }
        public string detalle { get; set; }
        public bool afecta_cuadre { get; set; }
        public bool activo { get; set; }
        public bool cuadrado { get; set; }
        public bool modificable { get; set; }
    }
}
