using System;

namespace IrisContabilidad.clases
{
    public class cliente
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public decimal limite_credito { get; set; }
        public int codigo_categoria { get; set; }
        public bool activo { get; set; }
        public DateTime fecha_creado { get; set; }
        public bool abrir_credito { get; set; }
        public int codigo_sucursal_creado { get; set; }
        public bool cliente_contado { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string cedula { get; set; }
        public string rnc { get; set; }
        public int codigo_tipo_comprobante_fiscal { get; set; }
        public string direccion1 { get; set; }
        public string direccion2 { get; set; }


    }
}
