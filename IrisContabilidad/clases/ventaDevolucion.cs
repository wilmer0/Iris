﻿using System;

namespace IrisContabilidad.clases
{
    public class ventaDevolucion
    {
        public int codigo { get; set; }
        public int codigo_venta { get; set; }
        public DateTime fecha { get; set; }
        public bool activo { get; set; }
        public int codigo_empleado { get; set; }
        public string descripcion { get; set; }
        public string ncf { get; set; }
    }
}
