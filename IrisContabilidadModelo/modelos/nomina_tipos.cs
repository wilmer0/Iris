//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IrisContabilidadModelo.modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class nomina_tipos
    {
        public nomina_tipos()
        {
            this.empleado = new HashSet<empleado>();
            this.nomina = new HashSet<nomina>();
            this.empleado_historial_datos = new HashSet<empleado_historial_datos>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
    
        public virtual ICollection<empleado> empleado { get; set; }
        public virtual ICollection<nomina> nomina { get; set; }
        public virtual ICollection<empleado_historial_datos> empleado_historial_datos { get; set; }
    }
}
