using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloVentaDevolucion
    {
        //objetos
        utilidades utilidades = new utilidades();
        private producto producto;


        //agregar 
        public bool agregarDevolucion(ventaDevolucion devolucion, List<ventaDevolucionDetalle> listaDetalle)
        {
            try
            {
                int activo = 0;

                if (devolucion.activo == true)
                {
                    activo = 1;
                }

                string sql = "insert into venta_devolucion(codigo,codigo_venta,fecha,activo,codigo_empleado,descripcion,ncf) values('" + devolucion.codigo + "','" + devolucion.codigo_venta + "','" + utilidades.getFechayyyyMMdd(devolucion.fecha) + "','" + activo + "','" + devolucion.codigo_empleado + "','" + devolucion.descripcion + "','" + devolucion.ncf + "')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                //insertar venta devolucion detalle
                listaDetalle.ForEach(x =>
                {
                    x.codigo = getNextDevolucionDetalle();
                    x.monto_total = x.cantidad*x.precio;
                    sql = "insert into venta_devolucion_detalles(codigo,codigo_devolucion,codigo_producto,codigo_unidad,cantidad,precio,monto_total) values('"+x.codigo+"','"+x.codigo_devolucion+"','"+x.codigo_producto+"','"+x.codigo_unidad+"','"+x.cantidad+"','"+x.precio+"','"+x.monto_total+"')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                //sacar cantidad devuelta de la venta detalle
                listaDetalle.ForEach(x =>
                {
                    sql = "update venta_detalle set  where cod_venta='"+devolucion.codigo_venta+"'";
                    utilidades.ejecutarcomando_mysql(sql);

                });



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public venta getVentaById(int id)
        {
            try
            {
                venta venta = new venta();
                string sql = "select codigo,num_factura,codigo_cliente,fecha,fecha_limite,ncf,tipo_venta,activo,pagada,cod_sucursal,codigo_empleado,cod_empleado_anular,motivo_anulada,detalles from venta where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    venta.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    venta.numero_factura = ds.Tables[0].Rows[0][1].ToString();
                    venta.codigo_cliente = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    venta.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
                    venta.fecha_limite = Convert.ToDateTime(ds.Tables[0].Rows[0][4].ToString());
                    venta.ncf = ds.Tables[0].Rows[0][5].ToString();
                    venta.tipo_venta = ds.Tables[0].Rows[0][6].ToString();
                    venta.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    venta.pagada = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    venta.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    venta.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    venta.codigo_empelado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                    venta.motivo_anulada = ds.Tables[0].Rows[0][12].ToString();
                    venta.detalle = ds.Tables[0].Rows[0][13].ToString();

                }
                return venta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista compra detalle
        public List<venta_detalle> getListaVentaDetalle(int id, bool incluirTodos = false)
        {
            try
            {

                List<venta_detalle> lista = new List<venta_detalle>();
                string sql = "";
                sql = "select codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo from venta_detalle where cod_venta='" + id + "'";
                if (incluirTodos == false)
                {
                    //se traen solo los activo
                    sql += " and activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta_detalle ventaDetalle = new venta_detalle();
                        ventaDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        ventaDetalle.cod_venta = Convert.ToInt16(row[1].ToString());
                        ventaDetalle.codigo_producto = Convert.ToInt16(row[2].ToString());
                        ventaDetalle.codigo_unidad = Convert.ToInt16(row[3].ToString());
                        ventaDetalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        ventaDetalle.precio = Convert.ToDecimal(row[5].ToString());
                        ventaDetalle.monto = Convert.ToDecimal(row[6].ToString());
                        ventaDetalle.monto_itebis = Convert.ToDecimal(row[7].ToString());
                        ventaDetalle.monto_descuento = Convert.ToDecimal(row[8].ToString());
                        ventaDetalle.activo = Convert.ToBoolean(row[9].ToString());
                        lista.Add(ventaDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa de venta
        public List<venta> getListaCompleta()
        {
            try
            {
                List<venta> lista = new List<venta>();
                venta venta = new venta();
                string sql = "select codigo,num_factura,codigo_cliente,fecha,fecha_limite,ncf,tipo_venta,activo,pagada,cod_sucursal,codigo_empleado,cod_empleado_anular,motivo_anulada,detalles from venta";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta.codigo = Convert.ToInt16(row[0].ToString());
                        venta.numero_factura = row[1].ToString();
                        venta.codigo_cliente = Convert.ToInt16(row[2].ToString());
                        venta.fecha = Convert.ToDateTime(row[3].ToString());
                        venta.fecha_limite = Convert.ToDateTime(row[4].ToString());
                        venta.ncf = row[5].ToString();
                        venta.tipo_venta = row[6].ToString();
                        venta.activo = Convert.ToBoolean(row[7]);
                        venta.pagada = Convert.ToBoolean(row[8]);
                        venta.codigo_sucursal = Convert.ToInt16(row[9].ToString());
                        venta.codigo_empleado = Convert.ToInt16(row[10].ToString());
                        venta.codigo_empelado_anular = Convert.ToInt16(row[11].ToString());
                        venta.motivo_anulada = row[12].ToString();
                        venta.detalle = row[13].ToString();
                        lista.Add(venta);
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
    }
}
