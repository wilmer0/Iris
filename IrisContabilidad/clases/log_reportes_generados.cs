using System;

namespace IrisContabilidad.clases
{
    public class log_reportes_generados
    {
        public int codigo { get; set; }
        public string reporteGenerado { get; set; }
        public int codigoEmpleado { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaHora { get; set; }

    }
}
