using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_pago_encabezado
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
        public string suplidor { get; set; }
        public string numero_pago { get; set; }
        public string fecha_pago { get; set; }


        public reporte_compra_pago_encabezado()
        {
            
        }

        public reporte_compra_pago_encabezado(int codigoPago)
        {
            compra_vs_pagos compraPago=new compra_vs_pagos();
            compraPago = new modeloCompra().getCompraPagoById(codigoPago);
            if (compraPago == null)
            {
                return;
            }

            empleado empleado = new modeloEmpleado().getEmpleadoById(compraPago.cod_empleado);
            sucursal sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);
            empresa empresa = new modeloEmpresa().getEmpresaBySucursalId(sucursal.codigo);
            suplidor suplidor = new modeloSuplidor().getSuplidorByCompraPago(compraPago.codigo);
            singleton singleton=new singleton();
            
            this.empleado_impresion = singleton.getEmpleado().nombre;
            this.empresa = empresa.nombre;
            this.direccion = sucursal.direccion;
            this.empresa_rnc = empresa.rnc;
            this.telefonos = sucursal.telefono1 + "-" + sucursal.telefono2;
            this.fecha_impresion = utilidades.getFechaddMMyyyyhhmmsstt(DateTime.Now);
            this.suplidor = suplidor.nombre;
            this.numero_pago = utilidades.getRellenar(compraPago.codigo.ToString(),'0',9);
            this.fecha_pago = utilidades.getFechaddMMyyyy(compraPago.fecha);
            
        }
    }
}
