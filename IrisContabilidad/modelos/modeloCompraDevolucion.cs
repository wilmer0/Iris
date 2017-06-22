using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;

namespace IrisContabilidad.modelos
{
    public class modeloCompraDevolucion
    {
        //objetos
        utilidades utilidades = new utilidades();
        private producto producto;


        //agregar 
        public bool agregarDevolucion(compraDevolucion devolucion, List<compraDevolucionDetalle> listaDevolucionDetalle, ingreso_caja ingresoCaja = null)
        {
            try
            {
                int activo = 0;

                if (devolucion.activo == true)
                {
                    activo = 1;
                }

                string sql = "insert into compra_devolucion(codigo,codigo_compra,fecha,activo,codigo_empleado,descripcion,ncf) values('" + devolucion.codigo + "','" + devolucion.codigo_compra + "'," + utilidades.getFechayyyyMMdd(devolucion.fecha) + ",'" + activo + "','" + devolucion.codigo_empleado + "','" + devolucion.descripcion + "','" + devolucion.ncf + "')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                //insertar compra devolucion detalle
                listaDevolucionDetalle.ForEach(x =>
                {
                    x.codigo = getNextDevolucionDetalle();
                    x.monto_total = x.cantidad * x.precio;
                    x.codigo_devolucion = devolucion.codigo;
                    sql = "insert into compra_devolucion_detalles(codigo,codigo_devolucion,codigo_producto,codigo_unidad,cantidad,precio,monto_total) values('" + x.codigo + "','" + x.codigo_devolucion + "','" + x.codigo_producto + "','" + x.codigo_unidad + "','" + x.cantidad + "','" + x.precio + "','" + x.monto_total + "')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                //si ya paso 30 dias desde que se efectuo la venta no se devuelve el itbis
                //para devolver el itbis debe estar menos de 30 dias porque en 30 dias maximo se reporta a la dgii
                compra compra = new modeloCompra().getCompraById(devolucion.codigo_compra);
                DateTime fechaHoy = DateTime.Today;
                int dias = Convert.ToInt16(utilidades.getFechaDiferenciaDias(compra.fecha, fechaHoy));
                decimal descuentoPorUnidad = 0;
                decimal itebisPorUnidad = 0;
                if (dias < 30)
                {
                    listaDevolucionDetalle.ForEach(x =>
                    {
                        //restando cantidad
                        sql = "update compra_detalle set cantidad=cantidad+" + x.cantidad + " where cod_producto='" + x.codigo_producto + "' and cod_unidad='" + x.codigo_unidad + "' and cod_compra='" + devolucion.codigo_compra + "'";
                        utilidades.ejecutarcomando_mysql(sql);

                        //modificando el monto, itebis y descuento
                        sql = "update compra_detalle set monto=cantidad*precio,itebis=cantidad*itebis_unitario,descuento=cantidad*descuento_unitario where cod_producto='" + x.codigo_producto + "' and cod_unidad='" + x.codigo_unidad + "' and cod_compra='" + devolucion.codigo_compra + "'";
                        utilidades.ejecutarcomando_mysql(sql);
                    });
                }

                if (ingresoCaja != null)
                {
                    modeloIngresoCaja modeloIngreso = new modeloIngresoCaja();
                    if (modeloIngreso.agregarIngreso(ingresoCaja) == false)
                    {
                        MessageBox.Show("Error no se pudo agregar el ingreso de caja automaticamente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string sql = "select max(codigo)from compra_devolucion";
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
                string sql = "select max(codigo)from compra_devolucion_detalles";
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
        public compraDevolucion getDevolucionById(int id)
        {
            try
            {
                compraDevolucion devolucion = new compraDevolucion();
                string sql = "select codigo,codigo_compra,fecha,activo,codigo_empleado,descripcion,ncf from compra_devolucion where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    devolucion.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    devolucion.codigo_compra = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
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
        //get lista compra devolucion detalle
        public List<compraDevolucionDetalle> getListaCompraDevolucionDetalleByDevolucionId(int id)
        {
            try
            {
                List<compraDevolucionDetalle> lista = new List<compraDevolucionDetalle>();
                string sql = "";
                sql = "select codigo,codigo_devolucion,codigo_producto,codigo_unidad,cantidad,precio,monto_total from compra_devolucion_detalles where codigo_devolucion='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        compraDevolucionDetalle detalle = new compraDevolucionDetalle();
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
                MessageBox.Show("Error getListaCompraDevolucionDetalleByDevolucionId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa de compra devolucion
        public List<compraDevolucion> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<compraDevolucion> lista = new List<compraDevolucion>();
                compraDevolucion CompraDevolucion = new compraDevolucion();
                string sql = "select codigo,codigo_compra,fecha,activo,codigo_empleado,descripcion,ncf from compra_devolucion";
                if (mantenimiento == false)
                {
                    sql += " where activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CompraDevolucion = new compraDevolucion();
                        CompraDevolucion.codigo = Convert.ToInt16(row[0].ToString());
                        CompraDevolucion.codigo_compra = Convert.ToInt16(row[1].ToString());
                        CompraDevolucion.fecha = Convert.ToDateTime(row[2].ToString());
                        CompraDevolucion.activo = Convert.ToBoolean(row[3]);
                        CompraDevolucion.codigo_empleado = Convert.ToInt16(row[4].ToString());
                        CompraDevolucion.descripcion = row[5].ToString();
                        CompraDevolucion.ncf = row[6].ToString();
                        lista.Add(CompraDevolucion);
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
                string sql = "update compra_devolucion set activo='0' where codigo='" + id + "'";
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
        public List<reporte_compra_devolucion_detalle> getListaReporteCompraDevolucionDetalleByDevolucionId(int id)
        {
            try
            {
                compraDevolucionDetalle compraDevolucionDetalle = new compraDevolucionDetalle();
                List<compraDevolucionDetalle> listaCompraDevolucionDetalle = new List<compraDevolucionDetalle>();

                reporte_compra_devolucion_detalle reporteCompraDevolucionDetalle = new reporte_compra_devolucion_detalle();
                List<reporte_compra_devolucion_detalle> lista = new List<reporte_compra_devolucion_detalle>();

                listaCompraDevolucionDetalle = getListaCompraDevolucionDetalleByDevolucionId(id);
                if (listaCompraDevolucionDetalle == null)
                {
                    return null;
                }

                listaCompraDevolucionDetalle.ForEach(x =>
                {
                    reporteCompraDevolucionDetalle = new reporte_compra_devolucion_detalle(x);
                    lista.Add(reporteCompraDevolucionDetalle);
                });

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaReporteCompraDevolucionDetalleByDevolucionId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
