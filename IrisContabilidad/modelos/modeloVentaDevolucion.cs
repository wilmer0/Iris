using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IrisContabilidad.modelos
{
    public class modeloVentaDevolucion
    {
        //objetos
        utilidades utilidades = new utilidades();
        private producto producto;


        //agregar 
        public bool agregarDevolucion(ventaDevolucion devolucion, List<ventaDevolucionDetalle> listaDevolucionDetalle,egreso_caja egresoCaja=null)
        {
            try
            {
                int activo = 0;

                if (devolucion.activo == true)
                {
                    activo = 1;
                }

                string sql = "insert into venta_devolucion(codigo,codigo_venta,fecha,activo,codigo_empleado,descripcion,ncf) values('" + devolucion.codigo + "','" + devolucion.codigo_venta + "'," + utilidades.getFechayyyyMMdd(devolucion.fecha) + ",'" + activo + "','" + devolucion.codigo_empleado + "','" + devolucion.descripcion + "','" + devolucion.ncf + "')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                //insertar venta devolucion detalle
                listaDevolucionDetalle.ForEach(x =>
                {
                    x.codigo = getNextDevolucionDetalle();
                    x.monto_total = x.cantidad*x.precio;
                    x.codigo_devolucion = devolucion.codigo;
                    sql = "insert into venta_devolucion_detalles(codigo,codigo_devolucion,codigo_producto,codigo_unidad,cantidad,precio,monto_total) values('"+x.codigo+"','"+x.codigo_devolucion+"','"+x.codigo_producto+"','"+x.codigo_unidad+"','"+x.cantidad+"','"+x.precio+"','"+x.monto_total+"')";
                    utilidades.ejecutarcomando_mysql(sql);
                });
                
                //si ya paso 30 dias desde que se efectuo la venta no se devuelve el itbis
                //para devolver el itbis debe estar menos de 30 dias porque en 30 dias maximo se reporta a la dgii
                venta venta = new modeloVenta().getVentaById(devolucion.codigo_venta);
                DateTime fechaHoy = DateTime.Today;
                int dias=Convert.ToInt16(utilidades.getFechaDiferenciaDias(venta.fecha, fechaHoy));
                decimal descuentoPorUnidad = 0;
                decimal itebisPorUnidad = 0;
                if (dias < 30)
                {
                    listaDevolucionDetalle.ForEach(x =>
                    {
                        //restando cantidad
                        sql = "update venta_detalle set cantidad=cantidad-" + x.cantidad + " where cod_producto='"+x.codigo_producto+"' and cod_unidad='"+x.codigo_unidad+"' and cod_venta='" + devolucion.codigo_venta + "'";
                        utilidades.ejecutarcomando_mysql(sql);

                        //modificando el monto, itebis y descuento
                        sql = "update venta_detalle set monto=cantidad*precio,itebis=cantidad*itebis_unitario,descuento=cantidad*descuento_unitario where cod_producto='" + x.codigo_producto + "' and cod_unidad='" + x.codigo_unidad + "' and cod_venta='" + devolucion.codigo_venta + "'";
                        utilidades.ejecutarcomando_mysql(sql);
                    });
                }

                if (egresoCaja != null)
                {
                    modeloEgresoCaja modeloEgreso = new modeloEgresoCaja();
                    if (modeloEgreso.agregarEgreso(egresoCaja)==false)
                    {
                        MessageBox.Show("Error no se pudo agregar el egreso de caja automaticamente", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarDevolucion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //obtener el codigo siguiente devolucion
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from venta_devolucion";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //int id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                int id = 0;
                if (ds.Tables[0].Rows[0][0].ToString() == null || ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    id = 0;
                }
                else
                {
                    id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                }
                id += 1;
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNext.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        //obtener el codigo siguiente devolucion detalle
        public int getNextDevolucionDetalle()
        {
            try
            {
                string sql = "select max(codigo)from venta_devolucion_detalles";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //int id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                int id = 0;
                if (ds.Tables[0].Rows[0][0].ToString() == null || ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    id = 0;
                }
                else
                {
                    id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                }
                id += 1;
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNextDevolucionDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        //get objeto
        public ventaDevolucion getDevolucionById(int id)
        {
            try
            {
                ventaDevolucion devolucion = new ventaDevolucion();
                string sql = "select codigo,codigo_venta,fecha,activo,codigo_empleado,descripcion,ncf from venta_devolucion where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    devolucion.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    devolucion.codigo_venta = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    devolucion.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2].ToString());
                    devolucion.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    devolucion.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][4].ToString());
                    devolucion.descripcion = ds.Tables[0].Rows[0][5].ToString();
                    devolucion.ncf = ds.Tables[0].Rows[0][6].ToString();
                }
                return devolucion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getDevolucionById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista venta devolucion detalle
        public List<ventaDevolucionDetalle> getListaVentaDevolucionDetalleByDevolucionId(int id)
        {
            try
            {
                List<ventaDevolucionDetalle> lista = new List<ventaDevolucionDetalle>();
                string sql = "";
                sql = "select codigo,codigo_devolucion,codigo_producto,codigo_unidad,cantidad,precio,monto_total from venta_devolucion_detalles where codigo_devolucion='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventaDevolucionDetalle detalle = new ventaDevolucionDetalle();
                        detalle.codigo = Convert.ToInt16(row[0].ToString());
                        detalle.codigo_devolucion = Convert.ToInt16(row[1].ToString());
                        detalle.codigo_producto = Convert.ToInt16(row[2].ToString());
                        detalle.codigo_unidad = Convert.ToInt16(row[3].ToString());
                        detalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        detalle.precio = Convert.ToDecimal(row[5].ToString());
                        detalle.monto_total = Convert.ToDecimal(row[6].ToString());
                        lista.Add(detalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaDevolucionDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa de venta devolucion
        public List<ventaDevolucion> getListaCompleta(bool mantenimiento=false)
        {
            try
            {
                List<ventaDevolucion> lista = new List<ventaDevolucion>();
                ventaDevolucion ventaDevolucion = new ventaDevolucion();
                string sql = "select codigo,codigo_venta,fecha,activo,codigo_empleado,descripcion,ncf from venta_devolucion";
                if (mantenimiento == false)
                {
                    sql += " where activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventaDevolucion=new ventaDevolucion();
                        ventaDevolucion.codigo = Convert.ToInt16(row[0].ToString());
                        ventaDevolucion.codigo_venta = Convert.ToInt16(row[1].ToString());
                        ventaDevolucion.fecha = Convert.ToDateTime(row[2].ToString());
                        ventaDevolucion.activo = Convert.ToBoolean(row[3]);
                        ventaDevolucion.codigo_empleado = Convert.ToInt16(row[4].ToString());
                        ventaDevolucion.descripcion = row[5].ToString();
                        ventaDevolucion.ncf = row[6].ToString();
                        lista.Add(ventaDevolucion);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //obtener el codigo siguiente devolucion detalle
        public bool anularDevolucion(int id)
        {
            try
            {
                string sql = "update venta_devolucion set activo='0' where codigo='"+id+"'";
                utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error anularDevolucion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //get lista reporte venta devolucion detalle by devolucion id
        public List<reporte_venta_devolucion_detalle> getListaReporteVentaDevolucionDetalleByDevolucionId(int id)
        {
            try
            {
                ventaDevolucionDetalle ventaDevolucionDetalle=new ventaDevolucionDetalle();
                List<ventaDevolucionDetalle> listaVentaDevolucionDetalle=new List<ventaDevolucionDetalle>();

                reporte_venta_devolucion_detalle reporteVentaDevolucionDetalle=new reporte_venta_devolucion_detalle();
                List<reporte_venta_devolucion_detalle> lista=new List<reporte_venta_devolucion_detalle>();

                listaVentaDevolucionDetalle = getListaVentaDevolucionDetalleByDevolucionId(id);
                if (listaVentaDevolucionDetalle == null)
                {
                    return null;
                }

                listaVentaDevolucionDetalle.ForEach(x =>
                {
                    reporteVentaDevolucionDetalle=new reporte_venta_devolucion_detalle(x);
                    lista.Add(reporteVentaDevolucionDetalle);
                });

                return lista;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error getListaReporteVentaDevolucionDetalleByDevolucionId.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }


        //get lista venta devolucion by cuadre caja
        public List<ventaDevolucionDetalle> getListaVentaDevolucionDetalleByCuadreCaja(cuadre_caja cuadre)
        {
            try
            {
                empleado empleado = new modeloEmpleado().getEmpleadoByCajeroId(cuadre.codigo_cajero);
                if (empleado == null)
                {
                    MessageBox.Show("Error empleado nulo en base al cajero .:getListaVentaDevolucionDetalleByCuadreCaja", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                List<ventaDevolucionDetalle> lista = new List<ventaDevolucionDetalle>();
                string sql = "";
                sql = "select dd.codigo,dd.codigo_devolucion,dd.codigo_producto,dd.codigo_unidad,dd.cantidad,dd.precio,dd.monto_total from venta_devolucion_detalles dd join venta_devolucion d on d.codigo=dd.codigo_devolucion where d.activo='1' and d.fecha>='" + utilidades.getFechayyyyMMdd(cuadre.fecha) + "' and d.fecha<='" + utilidades.getFechayyyyMMdd(cuadre.fecha_cierre_cuadre) + "' and d.codigo_empleado='"+empleado.codigo+"' ";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventaDevolucionDetalle detalle = new ventaDevolucionDetalle();
                        detalle.codigo = Convert.ToInt16(row[0].ToString());
                        detalle.codigo_devolucion = Convert.ToInt16(row[1].ToString());
                        detalle.codigo_producto = Convert.ToInt16(row[2].ToString());
                        detalle.codigo_unidad = Convert.ToInt16(row[3].ToString());
                        detalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        detalle.precio = Convert.ToDecimal(row[5].ToString());
                        detalle.monto_total = Convert.ToDecimal(row[6].ToString());
                        lista.Add(detalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaDevolucionDetalleByCuadreCaja.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
