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
    
    public partial class egresos_caja
    {
        public int codigo { get; set; }
        public int cod_concepto { get; set; }
        public System.DateTime fecha { get; set; }
        public int cod_cajero { get; set; }
        public decimal monto { get; set; }
        public string detalles { get; set; }
        public sbyte afecta_cuadre { get; set; }
        public Nullable<sbyte> activo { get; set; }
        public Nullable<int> cuadrado { get; set; }
    }
}
