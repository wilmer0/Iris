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
    
    public partial class permiso
    {
        public permiso()
        {
            this.grupo_usuarios = new HashSet<grupo_usuarios>();
        }
    
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
    
        public virtual ICollection<grupo_usuarios> grupo_usuarios { get; set; }
    }
}