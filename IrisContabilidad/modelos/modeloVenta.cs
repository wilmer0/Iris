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
    public class modeloVenta
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarVenta(venta venta, List<venta_detalle> listaDetalle)
        {
            try
            {
                int activo = 0;
                int pagada = 0;
                int despachado = 0;
                int autorizarPedido = 0;
                int cuadrado = 0;

                if (venta.activo == true)
                {
                    activo = 1;
                }
                if (venta.pagada == true)
                {
                    pagada = 1;
                }
                if (venta.despachado == true)
                {
                    despachado = 1;
                }
                if (venta.autorizar_pedido == true)
                {
                    autorizarPedido = 1;
                }
                if (venta.cuadrado == true)
                {
                    cuadrado = 1;
                }

                string sql = "insert into venta(codigo,num_factura,fecha,fecha_limite,codigo_empleado,codigo_cliente,ncf,tipo_venta,cod_sucursal,activo,pagada,cod_empleado_anular,motivo_anulada,cod_vendedor,despachado,autorizar_pedido,cuadrado,detalles) values('','','','','','','','','','','','','','','','','','','')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                //insertar venta detalle
                listaDetalle.ForEach(x =>
                {
                    x.codigo = getNextVentaDetalle();
                    sql = "insert into venta_detalle(codigo,cod_venta,cod_producto,cod_unidad,cantiad,precio,monto,itebis,descuento,activo) values('','','','','','','','','','')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                //sacar de inventario
                listaDetalle.ForEach(x =>
                {
                    x.codigo = getNextInventario();
                    DateTime fechaHoy = DateTime.Today;
                    sql = "insert into inventario(codigo,codigo_producto,codigo_unidad,cantidad,fecha_entrada,fecha_vencimiento) values('" + x.codigo + "','" + x.cod_producto + "','" + x.cod_unidad + "','" + x.cantidad + "'," + utilidades.getFechayyyyMMdd(fechaHoy) + "," + utilidades.getFechayyyyMMdd(fechaHoy.AddDays(120)) + ")";
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

        //modificar
        public bool modificarVenta(venta venta)
        {
            try
            {
                int activo = 0;
                int pagada = 0;
                int despachado = 0;
                int autorizarPedido = 0;
                int cuadrado = 0;

                if (venta.activo == true)
                {
                    activo = 1;
                }
                if (venta.pagada == true)
                {
                    pagada = 1;
                }
                if (venta.despachado == true)
                {
                    despachado = 1;
                }
                if (venta.autorizar_pedido == true)
                {
                    autorizarPedido = 1;
                }
                if (venta.cuadrado == true)
                {
                    cuadrado = 1;
                }

                //validar comprobante fiscal
                string sql = "select *from compra where ncf='" + venta.ncf + "' and codigo!='" + venta.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una compra con el mismo numero de comprobante fiscal", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


               
                //sql = "update compra set num_factura='" + venta.numero_factura + "',cod_suplidor='" + venta.cod_suplidor + "',fecha='" + venta.fecha + "',fecha_limite='" + venta.fecha_limite + "',ncf='" + venta.ncf + "',tipo_compra='" + venta.tipo_compra + "',activo'" + activo + "',pagada='" + pagada + "',cod_sucursal='" + venta.codigo_sucursal + "',codigo_empleado='" + venta.codigo_empleado + "',codigo_empleado_anular='" + venta.codigo_empleado_anular + "',motivo_anulado='" + venta.motivo_anulada + "',detalle='" + venta.detalle + "',suplidor_informal='" + suplidorInformal + "' where codigo='" + venta.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from venta";
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


        //obtener el codigo siguiente de compra detalle
        public int getNextVentaDetalle()
        {
            try
            {
                string sql = "select max(codigo)from venta_detalle";
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
                MessageBox.Show("Error getNextVentaDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //obtener el codigo siguiente inventario
        public int getNextInventario()
        {
            try
            {
                string sql = "select max(codigo)from inventario";
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
                MessageBox.Show("Error getNextCompraDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //get objeto
        public compra getVentaById(int id)
        {
            try
            {
                compra compra = new compra();
                string sql = "select codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal from compra where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    compra.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    compra.numero_factura = ds.Tables[0].Rows[0][1].ToString();
                    compra.cod_suplidor = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    compra.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
                    compra.fecha_limite = Convert.ToDateTime(ds.Tables[0].Rows[0][4].ToString());
                    compra.ncf = ds.Tables[0].Rows[0][5].ToString();
                    compra.tipo_compra = ds.Tables[0].Rows[0][6].ToString();
                    compra.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][7].ToString());
                    compra.pagada = Convert.ToBoolean(ds.Tables[0].Rows[0][8].ToString());
                    compra.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    compra.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    compra.codigo_empleado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                    compra.motivo_anulada = ds.Tables[0].Rows[0][12].ToString();
                    compra.detalle = ds.Tables[0].Rows[0][13].ToString();
                    compra.suplidor_informal = Convert.ToBoolean(ds.Tables[0].Rows[0][14].ToString());

                }
                return compra;
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
                sql = "select codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo from venta_detalle where cod_venta='"+id+"'";
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
                        ventaDetalle.cod_producto = Convert.ToInt16(row[2].ToString());
                        ventaDetalle.cod_unidad = Convert.ToInt16(row[3].ToString());
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
        //get lista completa de compras
        public List<venta> getListaVenta(int id)
        {
            try
            {
                List<venta> lista = new List<venta>();
                venta venta = new venta();
                string sql = "select codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal from compra where codigo='" + id + "'";
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
                    venta.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][7].ToString());
                    venta.pagada = Convert.ToBoolean(ds.Tables[0].Rows[0][8].ToString());
                    venta.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    venta.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    venta.codigo_empelado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                    venta.motivo_anulada = ds.Tables[0].Rows[0][12].ToString();
                    venta.detalle = ds.Tables[0].Rows[0][13].ToString();
                    lista.Add(venta);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista compra by suplidor
        public List<compra> getListaCompraBySuplidor(int id)
        {
            try
            {
                List<compra> lista = new List<compra>();
                compra compra = new compra();
                string sql = "select codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal from compra where cod_suplidor='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    compra = new compra();
                    compra.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    compra.numero_factura = ds.Tables[0].Rows[0][1].ToString();
                    compra.cod_suplidor = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    compra.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
                    compra.fecha_limite = Convert.ToDateTime(ds.Tables[0].Rows[0][4].ToString());
                    compra.ncf = ds.Tables[0].Rows[0][5].ToString();
                    compra.tipo_compra = ds.Tables[0].Rows[0][6].ToString();
                    compra.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    compra.pagada = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    compra.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    compra.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    compra.codigo_empleado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                    compra.motivo_anulada = ds.Tables[0].Rows[0][12].ToString();
                    compra.detalle = ds.Tables[0].Rows[0][13].ToString();
                    compra.suplidor_informal = Convert.ToBoolean(ds.Tables[0].Rows[0][14]);
                    lista.Add(compra);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraBySuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
