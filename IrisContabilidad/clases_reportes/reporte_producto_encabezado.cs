using System;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_producto_encabezado
    {
        public string producto { get; set; }
        public string referencia { get; set; }
        public string unidad_minima { get; set; }
        public string itebis { get; set; }
        public string categoria { get; set; }
        public string subcategoria { get; set; }
        public string almacen { get; set; }
        public DateTime fecha_impresion { get; set; }
        public string empleado { get; set; }
        public string empresa { get; set; }
        public string direccion { get; set; }

    }
}
