using System;
using System.Collections.Generic;
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
       

        //rango de valores
        public string fechaInicial { get; set; }
        public string fechaFinal { get; set; }
        public int anioInicial { get; set; }
        public int anioFinal { get; set; }
        public int codigoClienteInicial { get; set; }
        public int codigoClienteFinal { get; set; }


        //valores unitarios
        public string fecha { get; set; }
        public int anio { get; set; }
        public int codigoCliente { get; set; }
        public string cliente { get; set; }
        public int codigoSuplidor { get; set; }
        public string suplidor { get; set; }
        public int codigoCajero { get; set; }
        public string cajero { get; set; }
        public int codigoVendedor { get; set; }
        public string vendedor { get; set; }


        //booleanas
        public bool soloPagado { get; set; }
        public bool soloCobrado { get; set; }
        public bool todos { get; set; }


        //tipos
        public string tipoVenta { get; set; }
        public string tipoCompra { get; set; }
        public string tipoCliente { get; set; }
        public string tipoSuplidor { get; set; }


        //promedios
        public decimal promedioMontoVenta { get; set; }
        public decimal promedioMontoCompra { get; set; }
        


        //listas
        public List<reporte_venta_devolucion_detalle> listaReporteVentaDevolucionDetalle { get; set; }
        public List<reporte_compra_devolucion_detalle> listaReporteCompraDevolucionDetalle { get; set; }
        public List<reporte_estado_cuenta_cliente_detalle> listaReporteEstadoCuentaClienteDetalle { get; set; }
        public List<reporte_estado_cuenta_suplidor_detalle> listaReporteEstadoCuentaSuplidorDetalle { get; set; }






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