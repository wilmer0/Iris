using System.Collections.Generic;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_estado_cuenta_cliente_encabezado
    {
        //encabezado comun
        public string empresa { get; set; }
        public string telefonos { get; set; }
        public string rnc { get; set; }
        public string direccion { get; set; }
        public string fecha_impresion { get; set; }
        public string empleadoImpresion { get; set; }

        public List<reporte_estado_cuenta_cliente_detalle> listaDetalle { get; set; }
    }
}
