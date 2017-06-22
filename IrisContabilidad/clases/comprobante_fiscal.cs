using System;

namespace IrisContabilidad.clases
{
    public class comprobante_fiscal
    {
        public int codigo { get; set; }
        public string serie { get; set; }
        public int codigo_caja { get; set; }
        public int codigo_tipo { get; set; }
        public double numero_desde { get; set; }
        public double numero_hasta { get; set; }
        public double contador { get; set; }
        public DateTime fecha { get; set; }
        public double avisar { get; set; }
    }
}
