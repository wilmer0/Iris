using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using IrisContabilidad.modelos;
using  System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IrisContabilidad.clases_reportes_modelos
{
    public class modelo_reporte_cobros
    {
        public reporte_cobros_encabezado getReporteCobrosEncabezado(empleado empleado,cliente cliente,venta venta,string tipoVenta,
            Boolean incluirRangoFechaVenta,DateTime fechaInicialVenta,DateTime fechaFinalVenta,bool soloVentasPagadas)
        {
            try
            {
                reporte_cobros_encabezado reporteEncabezado = new reporte_cobros_encabezado();
                reporte_cobros_detalle reporteCobroDetalle;
                
                reporteEncabezado.listaDetalle = new List<reporte_cobros_detalle>();

                empresa empresa=new empresa();
                empresa = new modeloEmpresa().getEmpresaByEmpleadoId(empleado.codigo);
                
                sucursal sucursal=new sucursal();
                sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);

                List<cliente> listaCliente=new List<cliente>();
                listaCliente = new modeloCliente().getListaCompleta();

                List<venta> listaVenta=new List<venta>();
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
                    listaVenta = listaVenta.FindAll(x => x.codigo_cliente==cliente.codigo);    
                }
                //filtrando por venta
                if (venta != null)
                {
                    listaVenta = listaVenta.FindAll(x => x.codigo == venta.codigo);
                }
                //filtrando por tipo venta
                if (tipoVenta != "")
                {
                    listaVenta = listaVenta.FindAll(x => tipoVenta.ToLower().Contains(x.tipo_venta.ToLower()));
                }
                
                //rango fechas ventas
                if (incluirRangoFechaVenta == true)
                {
                    listaVenta = listaVenta.FindAll(x => x.fecha>=fechaInicialVenta.Date && x.fecha<=fechaFinalVenta.Date);
                }

                //si solo son ventas pagadas
                if (soloVentasPagadas == true)
                {
                    listaVenta = listaVenta.FindAll(x => x.pagada == true);
                }

                foreach(var clienteActual in listaCliente)
                {
                    foreach (var ventaActual in listaVenta)
                    {
                        if (clienteActual.codigo == ventaActual.codigo_cliente)
                        {
                            reporteCobroDetalle = new reporte_cobros_detalle(ventaActual.codigo);
                            reporteEncabezado.listaDetalle.Add(reporteCobroDetalle);
                        }
                    }
                }

                reporteEncabezado.listaDetalle = reporteEncabezado.listaDetalle.OrderByDescending(x => x.idVenta).ToList();

                return reporteEncabezado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getReporteCobrosEncabezado"+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
