using System;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_venta_cobro_encabezado
    {
        //encabezado comun de reporte
        public string empresa { get; set; }
        public string direccion { get; set; }
        public string empresa_rnc { get; set; }
        public string telefonos { get; set; }//se puede agregar todos los telefonos manualmente
        public string empleado_impresion { get; set; }
        public string fecha_impresion { get; set; }
        utilidades utilidades=new utilidades();
       

        //datos del reporte
        public string cliente { get; set; }
        public string numero_cobro { get; set; }
        public string fecha_cobro { get; set; }


        public reporte_venta_cobro_encabezado()
        {
            
        }

        public reporte_venta_cobro_encabezado(int codigoCobro)
        {
            venta_vs_cobros ventaCobro = new venta_vs_cobros();
            ventaCobro = new modeloVenta().getVentaCobroById(codigoCobro);
            if (ventaCobro == null)
            {
                return;
            }
            empleado empleado = new modeloEmpleado().getEmpleadoById(ventaCobro.cod_empleado);
            sucursal sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);
            empresa empresa = new modeloEmpresa().getEmpresaBySucursalId(sucursal.codigo);
            cliente cliente = new modeloCliente().getClienteByVentaCobro(ventaCobro.codigo);
            singleton singleton=new singleton();
            
            this.empleado_impresion = singleton.getEmpleado().nombre;
            this.empresa = empresa.nombre;
            this.direccion = sucursal.direccion;
            this.empresa_rnc = empresa.rnc;
            this.telefonos = sucursal.telefono1 + "-" + sucursal.telefono2;
            this.fecha_impresion = utilidades.getFechaddMMyyyyhhmmsstt(DateTime.Now);
            this.cliente = cliente.nombre;
            this.numero_cobro = utilidades.getRellenar(ventaCobro.codigo.ToString(),'0',9);
            this.fecha_cobro = utilidades.getFechaddMMyyyy(ventaCobro.fecha);
            
        }
    }
}
