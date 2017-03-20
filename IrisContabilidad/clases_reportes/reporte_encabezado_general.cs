using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_encabezado_general
    {
        //encabezado comun
        public string empresa { get; set; }
        public string telefonos { get; set; }
        public string rnc { get; set; }
        public string direccion { get; set; }
        public string fecha_impresion { get; set; }
        public string empleadoImpresion { get; set; }

        //otros
        public string fecha { get; set; }
        public string fechaInicial { get; set; }
        public string fechaFinal { get; set; }




        public reporte_encabezado_general()
        {
            
        }

        public reporte_encabezado_general(empleado empleado)
        {
            empresa empresa = new empresa();
            empresa = new modeloEmpresa().getEmpresaByEmpleadoId(empleado.codigo);

            sucursal sucursal = new sucursal();
            sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);

            this.empresa = empresa.nombre;
            this.rnc = empresa.rnc;
            this.direccion = sucursal.direccion;
            this.fecha_impresion = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            this.empleadoImpresion = empleado.nombre;
        }
    }
}
