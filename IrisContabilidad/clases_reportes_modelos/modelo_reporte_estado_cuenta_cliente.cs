using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes_modelos
{
    public class modelo_reporte_estado_cuenta_cliente
    {
        public modelo_reporte_estado_cuenta_cliente()
        {
            
        }

        public reporte_estado_cuenta_cliente_encabezado getReporteEstadoCuentaEncabezado(cliente cliente,empleado empleado,DateTime fechaFinal)
        {
            try
            {
                reporte_estado_cuenta_cliente_encabezado reporteEncabezado = new reporte_estado_cuenta_cliente_encabezado();
                reporte_estado_cuenta_cliente_detalle reporteDetalle;

                reporteEncabezado.listaDetalle=new List<reporte_estado_cuenta_cliente_detalle>();

                empresa empresa = new empresa();
                empresa = new modeloEmpresa().getEmpresaByEmpleadoId(empleado.codigo);

                sucursal sucursal = new sucursal();
                sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);

                List<cliente> listaCliente = new List<cliente>();
                listaCliente = new modeloCliente().getListaCompleta();

                List<venta> listaVenta = new List<venta>();
                listaVenta = new modeloVenta().getListaCompleta();

                //llenando el encabezado
                reporteEncabezado.empleadoImpresion = empleado.nombre;
                reporteEncabezado.fecha_impresion = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                reporteEncabezado.empresa = empresa.nombre;
                reporteEncabezado.direccion = sucursal.direccion;
                reporteEncabezado.rnc = empresa.rnc;
                reporteEncabezado.telefonos = sucursal.telefono1 + " - " + sucursal.telefono2;

                //filtrando por cliente
                if (cliente != null)
                {
                    listaVenta = listaVenta.FindAll(x => x.codigo_cliente == cliente.codigo);
                    listaCliente = listaCliente.FindAll(x => x.codigo == cliente.codigo);
                }
               
                //filtrando por fecha final
                if (fechaFinal != null)
                {
                    listaVenta = listaVenta.FindAll(x => x.fecha <= fechaFinal.Date);
                }

                foreach (var clienteActual in listaCliente)
                {
                    reporteDetalle = new reporte_estado_cuenta_cliente_detalle(clienteActual);
                    reporteEncabezado.listaDetalle.Add(reporteDetalle);
                }
                 

                return reporteEncabezado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getReporteEstadoCuentaEncabezado" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
