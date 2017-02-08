using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_venta_encabezado
    {
        public string empresa { get; set; }
        public string direccion { get; set; }
        public string rnc { get; set; }
        public string telefonos { get; set; }
        public string fax { get; set; }
        public string fecha_venta { get; set; }
        public string fecha_impresion { get; set; }
        public string usuarioImpresion { get; set; }
        public string tipo_comprobante_fiscal { get; set; }
        public string numero_comprobante_fiscal { get; set; }
        public string numero_impresion_fiscal { get; set; }
        public string cajero { get; set; }
        public string cliente { get; set; }
        public string clienteIdentificacion { get; set; }
        public string vendedor { get; set; }
        public string caja { get;set;}
        public int codigo_venta { get; set; }
        public string numero_venta { get; set; }
        public int codigo_cliente { get; set; }
        public string empleado { get; set; }
        public string tipo_venta { get; set; }
        public List<reporte_venta_detalle> listaDetalles { get; set; }
        utilidades utilidades=new utilidades();
        public reporte_venta_encabezado()
        {
            
        }

        public reporte_venta_encabezado(venta venta )
        {
            singleton singleton=new singleton();
            empleado empleadoSingleton = singleton.getEmpleado();
            empleado empleado = new modeloEmpleado().getEmpleadoById(venta.codigo_empleado);
            empresa empresa = new modeloEmpresa().getEmpresaBySucursalId(empleado.codigo_sucursal);
            sucursal sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);
            cliente cliente = new modeloCliente().getClienteById(venta.codigo_cliente);

            listaDetalles = new List<reporte_venta_detalle>();
            List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();


            this.empresa = empresa.nombre;
            this.telefonos = sucursal.telefono1 + "-" + sucursal.telefono2;
            this.rnc = empresa.rnc;
            this.telefonos = "Tel.: "+sucursal.telefono1 + " / " + sucursal.telefono2;
            this.direccion = sucursal.direccion;
            this.usuarioImpresion = empleadoSingleton.nombre;
            this.fecha_impresion = utilidades.getFechaddMMyyyyhhmmsstt(DateTime.Now);
            this.fecha_venta = utilidades.getFechaddMMyyyy(venta.fecha);
            this.codigo_venta = venta.codigo;
            this.numero_venta = utilidades.getRellenar(venta.codigo.ToString(), '0', 9);
            this.codigo_cliente = venta.codigo_cliente;
            this.cliente = cliente.nombre;
            this.clienteIdentificacion = cliente.rnc;
            this.empleado = empleado.nombre;
            this.tipo_venta = venta.tipo_venta;


            listaVentaDetalle = new modeloVenta().getListaVentaDetalle(venta.codigo);
            listaVentaDetalle.ForEach(x =>
            {
                reporte_venta_detalle reporteVentaDetalle = new reporte_venta_detalle(x);
                listaDetalles.Add(reporteVentaDetalle);

            });
        }

    }
}
