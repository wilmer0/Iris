﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_encabezado
    {
        public string empresa{ get; set; }
        public string telefonos { get; set; }
        public string rnc{ get; set; }
        public string direccion{ get; set; }
        public string fecha_impresion { get; set; }
        public string fecha_compa { get; set; }
        public string fecha_limite { get; set; }
        public int codigo_compra { get; set; }
        public string numero_compra{ get; set; }
        public string tipo_compra { get; set; }
        public string empleado { get; set; }
        public int codigo_suplidor { get; set; }
        public string suplidor { get; set; }
        public string suplidor_rnc { get; set; }
        public  List<reporte_compra_detalle> listaDetalles;
        utilidades utilidades=new utilidades();


        public reporte_compra_encabezado()
        {
            
        }


        public reporte_compra_encabezado(compra compra)
        {

            empleado empleado=new modeloEmpleado().getEmpleadoById(compra.codigo_empleado);
            empresa empresa = new modeloEmpresa().getEmpresaBySucursalId(empleado.codigo_sucursal);
            sucursal sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);
            suplidor suplidor = new modeloSuplidor().getSuplidorById(compra.cod_suplidor);

            listaDetalles = new List<reporte_compra_detalle>();
            List<compra_detalle> listaCompraDetalle = new List<compra_detalle>();


            this.empresa = empresa.nombre;
            this.telefonos = sucursal.telefono1+"-"+sucursal.telefono2;
            this.rnc = empresa.rnc;
            this.direccion = sucursal.direccion;
            this.fecha_impresion = utilidades.getFechaddMMyyyyhhmmsstt(DateTime.Now);
            this.fecha_compa = utilidades.getFechaddMMyyyy(compra.fecha);
            this.fecha_limite=utilidades.getFechaddMMyyyy(compra.fecha_limite);
            this.codigo_compra = compra.codigo;
            this.numero_compra = utilidades.getRellenar(compra.codigo.ToString(),'0',9);
            this.codigo_suplidor = compra.cod_suplidor;
            this.suplidor = suplidor.nombre;
            this.suplidor_rnc = suplidor.rnc;
            this.empleado = empleado.nombre;
            this.tipo_compra = compra.tipo_compra;


            listaCompraDetalle = new modeloCompra().getListaCompraDetalleByCompra(compra.codigo);
            listaCompraDetalle.ForEach(x =>
            {
                reporte_compra_detalle reporteCompraDetalle = new reporte_compra_detalle(x);
                listaDetalles.Add(reporteCompraDetalle);

            });
        }
    }
}
