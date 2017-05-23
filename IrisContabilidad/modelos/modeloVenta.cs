using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloVenta
    {
        //objetos
        utilidades utilidades = new utilidades();
        private producto producto;


        private string sqlGeneral = "select codigo,num_factura,codigo_cliente,fecha,fecha_limite,ncf,tipo_venta,activo,pagada,cod_sucursal,codigo_empleado,cod_empleado_anular,motivo_anulada,detalles,cuadrado,monto_impuesto,pedido,codigo_tipo_venta from venta where codigo>0 ";


        //agregar con lista de venta detalle
        public bool agregarVenta(venta venta, List<venta_detalle> listaDetalle)
        {
            try
            {
                int activo = 0;
                int pagada = 0;
                int despachado = 0;
                int autorizarPedido = 0;
                int cuadrado = 0;
                int pedido = 0;

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
                if (venta.pedido == true)
                {
                    pedido = 1;
                }

                venta.numero_factura = utilidades.getRellenar(venta.codigo.ToString(), '0', 9);
                string sql = "insert into venta(codigo,num_factura,fecha,fecha_limite,codigo_empleado,codigo_cliente,ncf,tipo_venta,cod_sucursal,activo,pagada,cod_empleado_anular,motivo_anulada,cod_vendedor,despachado,autorizar_pedido,cuadrado,detalles,cod_tipo_comprobante,pedido,monto_impuesto) values('" + venta.codigo + "','" + venta.numero_factura + "','" + utilidades.getFechayyyyMMdd(venta.fecha) + "','" + utilidades.getFechayyyyMMdd(venta.fecha_limite) + "','" + venta.codigo_empleado + "','" + venta.codigo_cliente + "','" + venta.ncf + "','" + venta.tipo_venta + "','" + venta.codigo_sucursal + "','" + activo + "','" + pagada + "','" + venta.codigo_empelado_anular + "','" + venta.motivo_anulada + "','" + venta.codigo_vendedor + "','" + despachado + "','" + autorizarPedido + "','" + cuadrado + "','" + venta.detalle + "','" + venta.codigo_tipo_comprobante + "','"+pedido+"','"+venta.monto_impuesto+"')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                //insertar venta detalle
                listaDetalle.ForEach(x =>
                {
                    x.codigo = getNextVentaDetalle();
                    decimal itebisUnitario = 0;
                    decimal descuentoUnitario = 0;
                    if (x.monto_itebis > 0)
                    {
                        itebisUnitario = x.monto_itebis/x.cantidad;
                    }
                    if (x.monto_descuento > 0)
                    {
                        descuentoUnitario = x.monto_descuento/x.cantidad;
                    }
                    sql = "insert into venta_detalle(codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo,itebis_unitario,descuento_unitario) values('" + x.codigo + "','" + venta.codigo + "','" + x.codigo_producto + "','" + x.codigo_unidad + "','" + x.cantidad + "','" + x.precio + "','" + x.monto_total + "','" + x.monto_itebis + "','"+x.monto_descuento+"','1','"+itebisUnitario+"','"+descuentoUnitario+"')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                //sacar de inventario
                foreach(var x in listaDetalle)
                {
                    decimal cantidad = x.cantidad;
                    decimal existencia = 0;
                    int codigoInventario = 1;
                    while (cantidad > 0)
                    {
                        //sacando la equivalencia cantidad x unidad de conversion
                        sql = "select cantidad from producto_unidad_conversion where cod_producto='" + x.codigo_producto + "' and cod_unidad='" + x.codigo_unidad + "'";
                        ds = utilidades.ejecutarcomando_mysql(sql);
                        decimal cantidadSacar = 1;//para sacar cantidad producto requisito equivalentemente de la unidad
                        cantidadSacar = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
                        //revisar si ese producto tiene productos requisitos
                        
                        //si, tiene que sacar los requisitos de inventario
                        producto = new modeloProducto().getProductoById(x.codigo_producto);
                        if (producto.producto_titular == true)
                        {
                            sql = "SELECT codpro_titular,codpro_requisito,cod_unidad,cantidad FROM producto_productos_requisitos where codpro_titular='" + x.codigo_producto + "'";
                            ds = utilidades.ejecutarcomando_mysql(sql);

                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                cantidadSacar = cantidadSacar * Convert.ToDecimal(row[3].ToString());
                                setSalidaInventarioByProductoUnidad(Convert.ToInt16(row[1].ToString()), Convert.ToInt16(row[2].ToString()), cantidadSacar);
                            }
                        }
                        
                        sql = "select codigo,codigo_producto,codigo_unidad,cantidad,fecha_entrada,fecha_vencimiento from inventario where codigo_producto='" + x.codigo_producto + "' and codigo_unidad='" + x.codigo_unidad + "' ";
                        if (producto.controla_inventario == true)
                        {
                            //controla inventario
                            sql += " and cantidad > '0' ";
                        }
                        sql += " limit 1";
                        ds=utilidades.ejecutarcomando_mysql(sql);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            codigoInventario = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                            existencia = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                            //si la cantidad que quiero vender < existencia
                            if (cantidad <= existencia)
                            {
                                existencia = existencia - cantidad;
                                cantidad = 0;
                            }
                            else
                            {
                                cantidad = cantidad - existencia;
                                existencia = 0;
                            }
                            sql = "update inventario set cantidad='" + existencia + "' where codigo='" +codigoInventario + "'";
                            utilidades.ejecutarcomando_mysql(sql);
                        }
                        else
                        {
                            cantidad--;
                            sql = "update inventario set cantidad='" + existencia + "' where codigo='" + codigoInventario + "'";
                            utilidades.ejecutarcomando_mysql(sql);
                            unidad unidad= new unidad();
                            unidad = new modeloUnidad().getUnidadById(x.codigo_unidad);
                            MessageBox.Show("El producto: " + producto.nombre +" y la unidad: "+unidad.nombre+" no tiene inventario disponible, favor revisar y dar entrada al inventario","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                     } 
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //agregar venta con lista de venta detalle lista
        public bool agregarVenta(venta venta, List<venta_detalle_lista> listaDetalle)
        {
            try
            {
                int activo = 0;
                int pagada = 0;
                int despachado = 0;
                int autorizarPedido = 0;
                int cuadrado = 0;
                int pedido = 0;

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
                if (venta.pedido == true)
                {
                    pedido = 1;
                }

                venta.numero_factura = utilidades.getRellenar(venta.codigo.ToString(), '0', 9);
                string sql = "insert into venta(codigo,num_factura,fecha,fecha_limite,codigo_empleado,codigo_cliente,ncf,tipo_venta,cod_sucursal,activo,pagada,cod_empleado_anular,motivo_anulada,cod_vendedor,despachado,autorizar_pedido,cuadrado,detalles,cod_tipo_comprobante,pedido,monto_impuesto,codigo_tipo_venta) values('" + venta.codigo + "','" + venta.numero_factura + "','" + utilidades.getFechayyyyMMdd(venta.fecha) + "','" + utilidades.getFechayyyyMMdd(venta.fecha_limite) + "','" + venta.codigo_empleado + "','" + venta.codigo_cliente + "','" + venta.ncf + "','" + venta.tipo_venta + "','" + venta.codigo_sucursal + "','" + activo + "','" + pagada + "','" + venta.codigo_empelado_anular + "','" + venta.motivo_anulada + "','" + venta.codigo_vendedor + "','" + despachado + "','" + autorizarPedido + "','" + cuadrado + "','" + venta.detalle + "','" + venta.codigo_tipo_comprobante + "','" + pedido + "','" + venta.monto_impuesto + "','"+venta.codigo_tipo_venta+"')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);

                //insertar venta detalle lista
                //listaDetalle.ForEach(x =>
                foreach(var x in listaDetalle)
                {
                    x.codigo = getNextVentaDetalle();
                    decimal itebisUnitario = 0;
                    decimal descuentoUnitario = 0;
                    if (x.itbis > 0)
                    {
                        itebisUnitario = x.itbis / x.cantidad;
                    }
                    if (x.descuento > 0)
                    {
                        descuentoUnitario = x.descuento / x.cantidad;
                    }
                    sql = "insert into venta_detalle(codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo,itebis_unitario,descuento_unitario) values('" + x.codigo + "','" + venta.codigo + "','" + x.codigoProducto + "','" + x.codigoUnidad + "','" + x.cantidad + "','" + x.precio + "','" + x.total + "','" + x.itbis + "','" + x.descuento + "','1','" + itebisUnitario + "','" + descuentoUnitario + "')";
                    utilidades.ejecutarcomando_mysql(sql);
                }

                //sacar de inventario
                foreach (var x in listaDetalle)
                {
                    decimal cantidad = x.cantidad;
                    decimal existencia = 0;
                    int codigoInventario = 1;
                    while (cantidad > 0)
                    {
                        //sacando la equivalencia cantidad x unidad de conversion
                        sql = "select cantidad from producto_unidad_conversion where cod_producto='" + x.codigoProducto + "' and cod_unidad='" + x.codigoUnidad + "'";
                        ds = utilidades.ejecutarcomando_mysql(sql);
                        decimal cantidadSacar = 1;//para sacar cantidad producto requisito equivalentemente de la unidad
                        cantidadSacar = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
                        //revisar si ese producto tiene productos requisitos

                        //si, tiene que sacar los requisitos de inventario
                        producto = new modeloProducto().getProductoById(x.codigoProducto);
                        if (producto.producto_titular == true)
                        {
                            sql = "SELECT codpro_titular,codpro_requisito,cod_unidad,cantidad FROM producto_productos_requisitos where codpro_titular='" + x.codigoProducto + "'";
                            ds = utilidades.ejecutarcomando_mysql(sql);

                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                cantidadSacar = cantidadSacar * Convert.ToDecimal(row[3].ToString());
                                setSalidaInventarioByProductoUnidad(Convert.ToInt16(row[1].ToString()), Convert.ToInt16(row[2].ToString()), cantidadSacar);
                            }
                        }

                        sql = "select codigo,codigo_producto,codigo_unidad,cantidad,fecha_entrada,fecha_vencimiento from inventario where codigo_producto='" + x.codigoProducto + "' and codigo_unidad='" + x.codigoUnidad + "' ";
                        if (producto.controla_inventario == true)
                        {
                            //controla inventario
                            sql += " and cantidad > '0' ";
                        }
                        sql += " limit 1";
                        ds = utilidades.ejecutarcomando_mysql(sql);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            codigoInventario = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                            existencia = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                            //si la cantidad que quiero vender < existencia
                            if (cantidad <= existencia)
                            {
                                existencia = existencia - cantidad;
                                cantidad = 0;
                            }
                            else
                            {
                                cantidad = cantidad - existencia;
                                existencia = 0;
                            }
                            sql = "update inventario set cantidad='" + existencia + "' where codigo='" + codigoInventario + "'";
                            utilidades.ejecutarcomando_mysql(sql);
                        }
                        else
                        {
                            cantidad--;
                            sql = "update inventario set cantidad='" + existencia + "' where codigo='" + codigoInventario + "'";
                            utilidades.ejecutarcomando_mysql(sql);
                            unidad unidad = new unidad();
                            unidad = new modeloUnidad().getUnidadById(x.codigoUnidad);
                            MessageBox.Show("El producto: " + producto.nombre + " y la unidad: " + unidad.nombre + " no tiene inventario disponible, favor revisar y dar entrada al inventario", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

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

        //obtener el codigo siguiente cobro detalle
        public int getNextCobroDetalle()
        {
            try
            {
                string sql = "select max(codigo)from venta_vs_cobros_detalles";
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
                MessageBox.Show("Error getNextCobroDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //get objeto
        public venta getVentaById(int id)
        {
            try
            {
                venta venta = new venta();
                string sql = sqlGeneral + " and codigo='"+id+"'";
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
                    venta.cuadrado = Convert.ToBoolean(ds.Tables[0].Rows[0][14]);
                    venta.detalle = ds.Tables[0].Rows[0][13].ToString();
                    venta.monto_impuesto = Convert.ToDecimal(ds.Tables[0].Rows[0][15]);
                    venta.pedido = Convert.ToBoolean(ds.Tables[0].Rows[0][16]);
                    venta.codigo_tipo_venta = Convert.ToInt16(ds.Tables[0].Rows[0][17]);
                }
                return venta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista venta detalle
        public List<venta_detalle> getListaVentaDetalle(Int64 id, bool incluirTodos = false)
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
                        ventaDetalle.codigo_producto = Convert.ToInt16(row[2].ToString());
                        ventaDetalle.codigo_unidad = Convert.ToInt16(row[3].ToString());
                        ventaDetalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        ventaDetalle.precio = Convert.ToDecimal(row[5].ToString());
                        ventaDetalle.monto_total = Convert.ToDecimal(row[6].ToString());
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

        //get lista venta detalle
        public List<venta_detalle_lista> getListaVentaDetalle(Int64 id)
        {
            try
            {

                List<venta_detalle_lista> lista = new List<venta_detalle_lista>();
                string sql = "";
                sql = "select codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo from venta_detalle where cod_venta='" + id + "' and activo='1'";
                
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta_detalle_lista ventaDetalle = new venta_detalle_lista();
                        ventaDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        ventaDetalle.codigoVenta = Convert.ToInt16(row[1].ToString());
                        ventaDetalle.codigoProducto = Convert.ToInt16(row[2].ToString());
                        ventaDetalle.codigoUnidad = Convert.ToInt16(row[3].ToString());
                        ventaDetalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        ventaDetalle.precio = Convert.ToDecimal(row[5].ToString());
                        ventaDetalle.total = Convert.ToDecimal(row[6].ToString());
                        ventaDetalle.itbis = Convert.ToDecimal(row[7].ToString());
                        ventaDetalle.descuento = Convert.ToDecimal(row[8].ToString());
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
                string sql = sqlGeneral;
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta=new venta();
                        venta.codigo = Convert.ToInt16(row[0]);
                        venta.numero_factura = row[1].ToString();
                        venta.codigo_cliente = Convert.ToInt16(row[2]);
                        venta.fecha = Convert.ToDateTime(row[3]);
                        venta.fecha_limite = Convert.ToDateTime(row[4]);
                        venta.ncf = row[5].ToString();
                        venta.tipo_venta = row[6].ToString();
                        venta.activo = Convert.ToBoolean(row[7]);
                        venta.pagada = Convert.ToBoolean(row[8]);
                        venta.codigo_sucursal = Convert.ToInt16(row[9]);
                        venta.codigo_empleado = Convert.ToInt16(row[10]);
                        venta.codigo_empelado_anular = Convert.ToInt16(row[11]);
                        venta.motivo_anulada = row[12].ToString();
                        venta.detalle = row[13].ToString();
                        venta.cuadrado = Convert.ToBoolean(row[14]);
                        venta.monto_impuesto = Convert.ToDecimal(row[15]);
                        venta.pedido = Convert.ToBoolean(row[16]);
                        venta.codigo_tipo_venta = Convert.ToInt16(row[17]);
                        lista.Add(venta);
                    }
                }
                lista = lista.OrderByDescending(x => x.codigo).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista venta by cliente id
        public List<venta> getListaVentasByClienteId(int id)
        {
            try
            {
                List<venta> lista=new List<venta>();
                venta venta = new venta();
                string sql =sqlGeneral + " and codigo_cliente='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta = new venta();
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
                        venta.cuadrado = Convert.ToBoolean(row[14]);
                        venta.monto_impuesto = Convert.ToDecimal(row[15]);
                        venta.pedido = Convert.ToBoolean(row[16]);
                        venta.codigo_tipo_venta = Convert.ToInt16(row[17]);
                        lista.Add(venta);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentasByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista venta by cliente id y fechaFinal
        public List<venta> getListaVentasByClienteIdandFechaFinal(int id,DateTime fechaFinal)
        {
            try
            {
                List<venta> lista = new List<venta>();
                venta venta = new venta();
                string sql = sqlGeneral + " and fecha<='"+utilidades.getFechayyyyMMdd(fechaFinal)+"' and codigo_cliente='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta = new venta();
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
                        venta.cuadrado = Convert.ToBoolean(row[14]);
                        venta.monto_impuesto = Convert.ToDecimal(row[15]);
                        venta.pedido = Convert.ToBoolean(row[16]);
                        venta.codigo_tipo_venta = Convert.ToInt16(row[17]);
                        lista.Add(venta);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentasByClienteIdAndFechaFinal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
       
        //get venta pago by id
        public venta_vs_cobros getVentaCobroById(int codigoVentaPago)
        {
            try
            {
                venta_vs_cobros CobroDetalle = new venta_vs_cobros();
                string sql = "select codigo,fecha,detalle,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado from venta_vs_cobros where codigo='" + codigoVentaPago + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CobroDetalle = new venta_vs_cobros();
                    CobroDetalle.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    CobroDetalle.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][1].ToString());
                    CobroDetalle.detalle = ds.Tables[0].Rows[0][2].ToString();
                    CobroDetalle.cod_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    CobroDetalle.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    CobroDetalle.cod_empleado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][5].ToString());
                    CobroDetalle.motivo_anulado = ds.Tables[0].Rows[0][6].ToString();
                    CobroDetalle.cuadrado = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                }
                return CobroDetalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentaCobroById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista venta cobro detalle by codigo compra pago
        public List<venta_vs_cobros_detalles> getListaVentaCobroDetalleByIdVentaCobro(int codigoCobro, bool SoloActivo = true)
        {
            try
            {
                List<venta_vs_cobros_detalles> lista = new List<venta_vs_cobros_detalles>();
                string sql = "";
                sql = "select codigo,cod_cobro,cod_venta,cod_metodo_cobro,monto_cobrado,monto_descontado,activo from venta_vs_cobros_detalles where cod_cobro='" + codigoCobro + "'";
                if (SoloActivo == true)
                {
                    //se traen solo los activo
                    sql += " and activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta_vs_cobros_detalles ventaCobroDetalle = new venta_vs_cobros_detalles();
                        ventaCobroDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        ventaCobroDetalle.codigo_cobro = Convert.ToInt16(row[1].ToString());
                        ventaCobroDetalle.codigo_venta = Convert.ToInt16(row[2].ToString());
                        ventaCobroDetalle.codigo_metodo_cobro = Convert.ToInt16(row[3].ToString());
                        ventaCobroDetalle.monto_cobrado = Convert.ToDecimal(row[4].ToString());
                        ventaCobroDetalle.monto_descontado = Convert.ToDecimal(row[5].ToString());
                        ventaCobroDetalle.activo = Convert.ToBoolean(row[6]);
                        lista.Add(ventaCobroDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaCobroDetalleByIdVentaCobro.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
       
        //hacer cobros a 
        public bool setVentaCobro(venta venta, venta_vs_cobros cobro, List<venta_vs_cobros_detalles> listaCobroDetalle)
        {
            //hacer pagos a compra
            try
            {
                //si la venta es a credito entonces no debe hacer ningun cobro
                if (venta.codigo_tipo_venta != 1)
                {
                    return true;
                }

                //venta vs cobros
                int activo = 0;
                int cuadrado = 0;
                if (cobro.activo == true)
                {
                    activo = 1;
                }
                if (cobro.cuadrado == true)
                {
                    cuadrado = 1;
                }
                
                //cobro encabezado
                string sql = "insert into venta_vs_cobros(codigo,fecha,detalle,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado) values('" + cobro.codigo + "'," + utilidades.getFechayyyyMMdd(cobro.fecha) + ",'" + cobro.detalle + "','" + cobro.cod_empleado + "','" + activo + "','" + cobro.cod_empleado_anular + "','" + cobro.motivo_anulado + "','" + cuadrado + "')";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                
                //cobro detalles
                listaCobroDetalle.ForEach(x =>
                {
                    x.codigo = getNextCobroDetalle();
                    x.codigo_cobro = cobro.codigo;
                    activo = 0;
                    if (x.activo == true)
                    {
                        activo = 1;
                    }
                    x.codigo_venta = venta.codigo;
                    sql = "insert into venta_vs_cobros_detalles(codigo,cod_cobro,cod_venta,cod_metodo_cobro,monto_cobrado,monto_descontado,activo,monto_devuelta) values('" + x.codigo + "','" + x.codigo_cobro + "','" + x.codigo_venta + "','" + x.codigo_metodo_cobro + "','" + x.monto_cobrado + "','" + x.monto_descontado + "','" + activo + "','" + x.monto_devuelta + "')";
                    utilidades.ejecutarcomando_mysql(sql);
                    
                });
                if (venta.tipo_venta == "CON")
                {
                    sql = "update venta set pagada='1' where codigo='" + venta.codigo + "'";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setVentaPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        //hacer cobros abono a venta
        public bool setVentaCobro(venta_vs_cobros cobro, List<venta_vs_cobros_detalles> listaCobroDetalles)
        {
            try
            {
                //si la compra es a credito entonces no debe hacer ningun pago
                if (cobro == null)
                {
                    return false;
                }
                if (listaCobroDetalles == null)
                {
                    return false;
                }

                //compra vs pagos
                //insert into compra_vs_pagos(codigo,fecha,detalle,cod_empleado,activo,cod_empleado,motivo_anulado,cuadrdo) values('','','','','','','','');
                int activo = 0;
                int cuadrado = 0;
                if (cobro.activo == true)
                {
                    activo = 1;
                }
                if (cobro.cuadrado == true)
                {
                    cuadrado = 1;
                }

                //cobro encabezado
                string sql = "insert into venta_vs_cobros(codigo,fecha,detalle,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado) values('" + cobro.codigo + "'," + utilidades.getFechayyyyMMdd(cobro.fecha) + ",'" + cobro.detalle + "','" + cobro.cod_empleado + "','" + activo + "','" + cobro.cod_empleado_anular + "','" + cobro.motivo_anulado + "','" + cuadrado + "')";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);

                //pago detalles
                listaCobroDetalles.ForEach(x =>
                {
                    x.codigo = getNextCobroDetalle();
                    x.codigo_cobro = cobro.codigo;
                    activo = 0;
                    if (x.activo == true)
                    {
                        activo = 1;
                    }
                    sql = "insert into venta_vs_cobros_detalles(codigo,cod_cobro,cod_venta,cod_metodo_cobro,monto_cobrado,monto_descontado,monto_subtotal,activo) values('" + x.codigo + "','" + x.codigo_cobro + "','" + x.codigo_venta + "','" + x.codigo_metodo_cobro + "','" + x.monto_cobrado + "','" + x.monto_descontado +"','"+x.monto_subtotal+ "','" + activo + "')";
                    utilidades.ejecutarcomando_mysql(sql);

                });

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setVentaCobro.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int getNextCobro()
        {
            try
            {
                string sql = "select max(codigo)from venta_vs_cobros";
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
                MessageBox.Show("Error getNextPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //get lista venta detalle by venta id
        public List<venta_detalle> getListaVentaDetalleByVentaId(int ventaId)
        {
            try
            {
                List<venta_detalle> lista = new List<venta_detalle>();
                venta_detalle ventaDetalle = new venta_detalle();
                string sql = "select codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo from venta_detalle where cod_venta='" + ventaId + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventaDetalle = new venta_detalle();
                        ventaDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        ventaDetalle.cod_venta = Convert.ToInt16(row[1].ToString());
                        ventaDetalle.codigo_producto = Convert.ToInt16(row[2].ToString());
                        ventaDetalle.codigo_unidad = Convert.ToInt16(row[3].ToString());
                        ventaDetalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        ventaDetalle.precio = Convert.ToDecimal(row[5].ToString());
                        ventaDetalle.monto_total = Convert.ToDecimal(row[6].ToString());
                        ventaDetalle.monto_itebis = Convert.ToDecimal(row[7].ToString());
                        ventaDetalle.monto_descuento = Convert.ToDecimal(row[8].ToString());
                        ventaDetalle.activo = Convert.ToBoolean(row[9]);
                        lista.Add(ventaDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaDetalleByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        //get lista venta detalle by cliente
        public List<venta_detalle> getListaVentaDetalleByClienteId(int id)
        {
            try
            {
                List<venta_detalle> lista = new List<venta_detalle>();
                venta_detalle ventaDetalle = new venta_detalle();
                string sql = "select vd.codigo,vd.cod_venta,vd.cod_producto,vd.cod_unidad,vd.cantidad,vd.precio,vd.monto,vd.itebis,vd.descuento,vd.activo from venta_detalle vd join venta v on vd.cod_venta=v.codigo join cliente c on c.codigo=v.codigo_cliente where vd.activo='1' and c.codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventaDetalle = new venta_detalle();
                        ventaDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        ventaDetalle.cod_venta = Convert.ToInt16(row[1].ToString());
                        ventaDetalle.codigo_producto = Convert.ToInt16(row[2].ToString());
                        ventaDetalle.codigo_unidad = Convert.ToInt16(row[3].ToString());
                        ventaDetalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        ventaDetalle.precio = Convert.ToDecimal(row[5].ToString());
                        ventaDetalle.monto_total = Convert.ToDecimal(row[6].ToString());
                        ventaDetalle.monto_itebis = Convert.ToDecimal(row[7].ToString());
                        ventaDetalle.monto_descuento = Convert.ToDecimal(row[8].ToString());
                        ventaDetalle.activo = Convert.ToBoolean(row[9]);
                        lista.Add(ventaDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaDetalleByCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
       
        public List<venta_detalle> getListaVentaDetalleByClienteIdAndRangoFechaFinal(int id,DateTime fechaFinal)
        {
            try
            {
                List<venta_detalle> lista = new List<venta_detalle>();
                venta_detalle ventaDetalle = new venta_detalle();
                string sql = "select vd.codigo,vd.cod_venta,vd.cod_producto,vd.cod_unidad,vd.cantidad,vd.precio,vd.monto,vd.itebis,vd.descuento,vd.activo from venta_detalle vd join venta v on vd.cod_venta=v.codigo join cliente c on c.codigo=v.codigo_cliente where v.fecha<='"+utilidades.getFechayyyyMMdd(fechaFinal)+"' and c.codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventaDetalle = new venta_detalle();
                        ventaDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        ventaDetalle.cod_venta = Convert.ToInt16(row[1].ToString());
                        ventaDetalle.codigo_producto = Convert.ToInt16(row[2].ToString());
                        ventaDetalle.codigo_unidad = Convert.ToInt16(row[3].ToString());
                        ventaDetalle.cantidad = Convert.ToDecimal(row[4].ToString());
                        ventaDetalle.precio = Convert.ToDecimal(row[5].ToString());
                        ventaDetalle.monto_total = Convert.ToDecimal(row[6].ToString());
                        ventaDetalle.monto_itebis = Convert.ToDecimal(row[7].ToString());
                        ventaDetalle.monto_descuento = Convert.ToDecimal(row[8].ToString());
                        ventaDetalle.activo = Convert.ToBoolean(row[9]);
                        lista.Add(ventaDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaDetalleByClienteIdAndRangoFechaFinal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista cobros by venta
        public List<venta_vs_cobros> getListaCobrosByVenta(int ventaId)
        {
            try
            {
                List<venta_vs_cobros> lista = new List<venta_vs_cobros>();
                venta_vs_cobros cobro = new venta_vs_cobros();
                string sql = "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from venta_vs_cobros where codigo='"+ventaId+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobro = new venta_vs_cobros();
                        cobro.codigo = Convert.ToInt16(row[0].ToString());
                        cobro.fecha = Convert.ToDateTime(row[1].ToString());
                        cobro.cod_empleado = Convert.ToInt16(row[2].ToString());
                        cobro.activo = Convert.ToBoolean(row[3]);
                        cobro.cod_empleado_anular = Convert.ToInt16(row[4].ToString());
                        cobro.motivo_anulado = row[5].ToString();
                        cobro.cuadrado = Convert.ToBoolean(row[6]);
                        cobro.detalle = row[7].ToString();
                        lista.Add(cobro);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCobrosByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista cobros detalle by venta
        public List<venta_vs_cobros_detalles> getListaCobrosDetallesByVenta(int ventaId)
        {
            try
            {
                List<venta_vs_cobros_detalles> lista = new List<venta_vs_cobros_detalles>();
                venta_vs_cobros_detalles cobroDetalle = new venta_vs_cobros_detalles();
                string sql = "select codigo,cod_cobro,cod_metodo_cobro,monto_cobrado,monto_descontado,activo,cod_venta from venta_vs_cobros_detalles where activo='1' and cod_venta='" + ventaId + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        cobroDetalle.codigo_cobro = Convert.ToInt16(row[1].ToString());
                        cobroDetalle.codigo_metodo_cobro = Convert.ToInt16(row[2].ToString());
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(row[3]);
                        cobroDetalle.monto_descontado = Convert.ToDecimal(row[4].ToString());
                        cobroDetalle.activo = Convert.ToBoolean(row[5]);
                        cobroDetalle.codigo_venta = Convert.ToInt16(row[6]);
                        lista.Add(cobroDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCobrosDetallesByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


        }

        //get lista cobros detalle by cliente
        public List<venta_vs_cobros_detalles> getListaCobrosDetallesByClienteId(int id)
        {
            try
            {
                List<venta_vs_cobros_detalles> lista = new List<venta_vs_cobros_detalles>();
                venta_vs_cobros_detalles cobroDetalle = new venta_vs_cobros_detalles();
                string sql =
                    "select vcd.codigo,vcd.cod_cobro,vcd.cod_metodo_cobro,vcd.monto_cobrado,vcd.monto_descontado,vcd.activo,vcd.cod_venta from venta_vs_cobros_detalles vcd join venta v on v.codigo=vcd.cod_venta join cliente c on v.codigo_cliente=c.codigo where vcd.activo='1' and v.activo='1' and c.codigo='" +id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        cobroDetalle.codigo_cobro = Convert.ToInt16(row[1].ToString());
                        cobroDetalle.codigo_metodo_cobro = Convert.ToInt16(row[2].ToString());
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(row[3]);
                        cobroDetalle.monto_descontado = Convert.ToDecimal(row[4].ToString());
                        cobroDetalle.activo = Convert.ToBoolean(row[5]);
                        cobroDetalle.codigo_venta = Convert.ToInt16(row[6]);
                        lista.Add(cobroDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCobrosDetallesByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        public List<venta_vs_cobros_detalles> getListaCobrosDetallesByClienteIdAndRangoFechaFinal(int id, DateTime fechaFinal)
        {
            try
            {
                List<venta_vs_cobros_detalles> lista = new List<venta_vs_cobros_detalles>();
                venta_vs_cobros_detalles cobroDetalle = new venta_vs_cobros_detalles();
                string sql =
                    "select vcd.codigo,vcd.cod_cobro,vcd.cod_metodo_cobro,vcd.monto_cobrado,vcd.monto_descontado,vcd.activo,vcd.cod_venta from venta_vs_cobros_detalles vcd join venta v on v.codigo=vcd.cod_venta join cliente c on v.codigo_cliente=c.codigo where vcd.activo='1' and v.activo='1' and c.codigo='" +id + "' and v.fecha<='"+utilidades.getFechayyyyMMdd(fechaFinal)+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        cobroDetalle.codigo_cobro = Convert.ToInt16(row[1].ToString());
                        cobroDetalle.codigo_metodo_cobro = Convert.ToInt16(row[2].ToString());
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(row[3]);
                        cobroDetalle.monto_descontado = Convert.ToDecimal(row[4].ToString());
                        cobroDetalle.activo = Convert.ToBoolean(row[5]);
                        cobroDetalle.codigo_venta = Convert.ToInt16(row[6]);
                        lista.Add(cobroDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCobrosDetallesByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get monto pendiente by venta
        public decimal getMontoPendienteByVenta(int ventaID)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoDescuento = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasDebito = 0;
                decimal montoNotasCredito = 0;

                List<cxc_nota_debito> listaNotasDebito=new List<cxc_nota_debito>();
                List<cxc_nota_credito> listaNotasCredito=new List<cxc_nota_credito>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();

                listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(ventaID);
                listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(ventaID);
                listaVentaDetalle = getListaVentaDetalleByVentaId(ventaID);
                listaCobrosDetalle = getListaCobrosDetallesByVenta(ventaID);

                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos 
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //montos de cobros
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado;
                    });
                }

                //monto notas debito
                listaNotasDebito.ForEach(x =>
                {
                    montoNotasDebito += x.monto;
                });

                //montos notas credito
                listaNotasCredito.ForEach(x =>
                {
                    montoNotasCredito += x.monto;
                });

                //pendiente = (monto venta + cargos a la venta) - (monto cobrado + descuento a la venta)
                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return montoPendiente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoPendienteByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
        }

        public bool setSalidaInventarioByProductoUnidad(int codigoProducto, int codigoUnidad,decimal cantidad)
        {
            try
            {
                
                //sacar de inventario
                producto producto = new modeloProducto().getProductoById(codigoProducto);
                unidad unidad = new modeloUnidad().getUnidadById(codigoUnidad);
                string sql = "";
                DataSet ds=new DataSet();
                decimal existencia = 0;
                int codigoInventario = 1;
                while (cantidad > 0)
                {
                    //revisar si ese producto tiene productos requisitos
                    producto = new modeloProducto().getProductoById(codigoProducto);
                    sql = "select codigo,codigo_producto,codigo_unidad,cantidad,fecha_entrada,fecha_vencimiento from inventario where codigo_producto='" + codigoProducto + "' and codigo_unidad='" + codigoUnidad + "' ";
                    if (producto.controla_inventario == true)
                    {
                        //controla inventario
                        sql += " and cantidad > '0' ";
                    }
                    sql += " limit 1";
                    ds = utilidades.ejecutarcomando_mysql(sql);

                    if (ds.Tables[0].Rows[0][0] != "")
                    {
                        codigoInventario = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                        existencia = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                        //si la cantidad que quiero vender < existencia
                        if (cantidad <= existencia)
                        {
                            existencia = existencia - cantidad;
                            cantidad = 0;
                        }
                        else
                        {
                            cantidad = cantidad - existencia;
                            existencia = 0;
                        }
                        sql = "update inventario set cantidad='" + existencia + "' where codigo='" + codigoInventario +"'";
                        utilidades.ejecutarcomando_mysql(sql);
                    }
                    else
                    {
                        MessageBox.Show("Debe insertar al inventario el producto.: "+producto.nombre+" y la unidad.: "+unidad.nombre+" no se encuentra inventario disponible","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setSalidaInventarioByProductoUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //hacer que esta venta se pague automaticamente 
        public bool setVentapagada(int idVenta)
        {
            //hacer pagos a compra
            try
            {
                string sql = "update venta set pagada='1' where codigo='"+idVenta+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setVentapagada.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //get monto factura by venta
        public decimal getMontoFacturaByVenta(int ventaID)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasCredito = 0;
                decimal montoNotasDebito = 0;

                List<cxc_nota_credito> listaNotasCredito=new List<cxc_nota_credito>();
                List<cxc_nota_debito>listaNotasDebito=new List<cxc_nota_debito>();
                List<venta> listaVenta = new List<venta>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();

                

                listaVentaDetalle = getListaVentaDetalleByVentaId(ventaID);
                listaCobrosDetalle = getListaCobrosDetallesByVenta(ventaID);

                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //sumando los monto cobrados
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }


                //sumando las notas de credito
                //que son los descuentos a la factura del cliente
                montoNotasCredito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasCredito = new List<cxc_nota_credito>();
                    listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(x.codigo);
                    montoNotasCredito += listaNotasCredito.Sum(s => s.monto);
                }

                //sumando las notas de debito
                //que son los cargos a la factura del cliente
                montoNotasDebito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasDebito = new List<cxc_nota_debito>();
                    listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(x.codigo);
                    montoNotasDebito += listaNotasDebito.Sum(s => s.monto);
                }

                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return montoVenta+montoNotasDebito;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoFacturaByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
        }

        //get monto cobrado by venta
        public decimal getMontoCobradoByVenta(int ventaID)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasCredito = 0;
                decimal montoNotasDebito = 0;

                List<cxc_nota_credito> listaNotasCredito = new List<cxc_nota_credito>();
                List<cxc_nota_debito> listaNotasDebito = new List<cxc_nota_debito>();
                List<venta> listaVenta = new List<venta>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();



                listaVentaDetalle = getListaVentaDetalleByVentaId(ventaID);
                listaCobrosDetalle = getListaCobrosDetallesByVenta(ventaID);

                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //sumando los monto cobrados
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }


                //sumando las notas de credito
                //que son los descuentos a la factura del cliente
                montoNotasCredito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasCredito = new List<cxc_nota_credito>();
                    listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(x.codigo);
                    montoNotasCredito += listaNotasCredito.Sum(s => s.monto);
                }

                //sumando las notas de debito
                //que son los cargos a la factura del cliente
                montoNotasDebito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasDebito = new List<cxc_nota_debito>();
                    listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(x.codigo);
                    montoNotasDebito += listaNotasDebito.Sum(s => s.monto);
                }

                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return  montoCobrado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoCobradoByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
        }
        
        //get monto cobrado by cliente id
        public decimal getMontoCobradoByClienteId(int id)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasDebito = 0;
                decimal montoNotasCredito = 0;

                List<venta> listaVenta = new List<venta>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();
                List<cxc_nota_debito> listaNotasDebito = new List<cxc_nota_debito>();
                List<cxc_nota_credito> listaNotasCredito = new List<cxc_nota_credito>();


                listaVenta = getListaVentasByClienteId(id);
                listaVentaDetalle = getListaVentaDetalleByClienteId(id);
                listaCobrosDetalle = getListaCobrosDetallesByClienteId(id);



                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos de venta + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //sumando los monto cobrados
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }

                //sumando las notas de debito
                //que son los cargos a la factura del cliente
                montoNotasDebito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasDebito = new List<cxc_nota_debito>();
                    listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(x.codigo);
                    montoNotasDebito += listaNotasDebito.Sum(s => s.monto);
                }

                //sumando las notas de credito
                //que son los descuentos a la factura del cliente
                montoNotasCredito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasCredito = new List<cxc_nota_credito>();
                    listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(x.codigo);
                    montoNotasCredito += listaNotasCredito.Sum(s => s.monto);
                }

                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return montoCobrado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoCobradoByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        //get monto notacredito by cliente id
        public decimal getMontoNotasCreditoByClienteId(int id)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasDebito = 0;
                decimal montoNotasCredito = 0;

                List<venta> listaVenta = new List<venta>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();
                List<cxc_nota_debito> listaNotasDebito = new List<cxc_nota_debito>();
                List<cxc_nota_credito> listaNotasCredito = new List<cxc_nota_credito>();


                listaVenta = getListaVentasByClienteId(id);
                listaVentaDetalle = getListaVentaDetalleByClienteId(id);
                listaCobrosDetalle = getListaCobrosDetallesByClienteId(id);



                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos de venta + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //sumando los monto cobrados
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }

                //sumando las notas de debito
                //que son los cargos a la factura del cliente
                montoNotasDebito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasDebito = new List<cxc_nota_debito>();
                    listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(x.codigo);
                    montoNotasDebito += listaNotasDebito.Sum(s => s.monto);
                }

                //sumando las notas de credito
                //que son los descuentos a la factura del cliente
                montoNotasCredito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasCredito = new List<cxc_nota_credito>();
                    listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(x.codigo);
                    montoNotasCredito += listaNotasCredito.Sum(s => s.monto);
                }

                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return montoNotasCredito;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoNotasCreditoByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        //get monto notacredito by cliente id
        public decimal getMontoNotasDebitoByClienteId(int id)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasDebito = 0;
                decimal montoNotasCredito = 0;

                List<venta> listaVenta = new List<venta>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();
                List<cxc_nota_debito> listaNotasDebito = new List<cxc_nota_debito>();
                List<cxc_nota_credito> listaNotasCredito = new List<cxc_nota_credito>();


                listaVenta = getListaVentasByClienteId(id);
                listaVentaDetalle = getListaVentaDetalleByClienteId(id);
                listaCobrosDetalle = getListaCobrosDetallesByClienteId(id);



                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos de venta + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //sumando los monto cobrados
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }

                //sumando las notas de debito
                //que son los cargos a la factura del cliente
                montoNotasDebito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasDebito = new List<cxc_nota_debito>();
                    listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(x.codigo);
                    montoNotasDebito += listaNotasDebito.Sum(s => s.monto);
                }

                //sumando las notas de credito
                //que son los descuentos a la factura del cliente
                montoNotasCredito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasCredito = new List<cxc_nota_credito>();
                    listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(x.codigo);
                    montoNotasCredito += listaNotasCredito.Sum(s => s.monto);
                }

                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return montoNotasDebito;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoNotasDebitoByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        //get monto pendiente by cliente id
        public decimal getMontoPendienteByClienteId(int id)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasDebito = 0;
                decimal montoNotasCredito = 0;

                List<venta> listaVenta = new List<venta>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();
                List<cxc_nota_debito> listaNotasDebito = new List<cxc_nota_debito>();
                List<cxc_nota_credito> listaNotasCredito = new List<cxc_nota_credito>();


                listaVenta = getListaVentasByClienteId(id);
                listaVentaDetalle = getListaVentaDetalleByClienteId(id);
                listaCobrosDetalle = getListaCobrosDetallesByClienteId(id);



                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos de venta + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //sumando los monto cobrados
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }

                //sumando las notas de debito
                //que son los cargos a la factura del cliente
                montoNotasDebito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasDebito = new List<cxc_nota_debito>();
                    listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(x.codigo);
                    montoNotasDebito += listaNotasDebito.Sum(s => s.monto);
                }

                //sumando las notas de credito
                //que son los descuentos a la factura del cliente
                montoNotasCredito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasCredito = new List<cxc_nota_credito>();
                    listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(x.codigo);
                    montoNotasCredito += listaNotasCredito.Sum(s => s.monto);
                }

                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return montoPendiente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoPendienteByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        //get monto facturado by cliente id
        public decimal getMontoFacturadoByClienteId(int id)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;
                decimal montoNotasDebito = 0;
                decimal montoNotasCredito = 0;

                List<venta> listaVenta = new List<venta>();
                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();
                List<cxc_nota_debito> listaNotasDebito = new List<cxc_nota_debito>();
                List<cxc_nota_credito> listaNotasCredito = new List<cxc_nota_credito>();


                listaVenta = getListaVentasByClienteId(id);
                listaVentaDetalle = getListaVentaDetalleByClienteId(id);
                listaCobrosDetalle = getListaCobrosDetallesByClienteId(id);



                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos de venta + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto_total + x.monto_descuento;
                    });
                }

                //sumando los monto cobrados
                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }

                //sumando las notas de debito
                //que son los cargos a la factura del cliente
                montoNotasDebito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasDebito = new List<cxc_nota_debito>();
                    listaNotasDebito = new modeloCxcNotaDebito().getListaByVentaActivo(x.codigo);
                    montoNotasDebito += listaNotasDebito.Sum(s => s.monto);
                }

                //sumando las notas de credito
                //que son los descuentos a la factura del cliente
                montoNotasCredito = 0;
                foreach (var x in listaVenta)
                {
                    listaNotasCredito = new List<cxc_nota_credito>();
                    listaNotasCredito = new modeloCxcNotaCredito().getListaByVentaActivo(x.codigo);
                    montoNotasCredito += listaNotasCredito.Sum(s => s.monto);
                }

                montoPendiente = (montoVenta + montoNotasDebito) - (montoCobrado + montoNotasCredito);

                return montoVenta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoFacturadoByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        //get lista completa de venta by rango de anos
        public List<venta> getListaCompletaByRangoAnos(int anioInicial,int anioFinal)
        {
            try
            {
                List<venta> lista = new List<venta>();
                venta venta = new venta();
                string sql = sqlGeneral + " and year(fecha)>="+anioInicial+" and year(fecha)<="+anioFinal+"";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta = new venta();
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
                        venta.cuadrado = Convert.ToBoolean(row[14]);
                        venta.monto_impuesto = Convert.ToDecimal(row[15]);
                        venta.pedido = Convert.ToBoolean(row[16]);
                        venta.codigo_tipo_venta = Convert.ToInt16(row[17]);
                        lista.Add(venta);
                    }
                }
                lista = lista.OrderByDescending(x => x.codigo).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa de venta by rango de meses
        public List<venta> getListaCompletaByRangoMes(int mesInicial, int MesFinal)
        {
            try
            {
                List<venta> lista = new List<venta>();
                venta venta = new venta();
                string sql = sqlGeneral + " and month(fecha)>='" + mesInicial + "' and month()fecha<='" + MesFinal + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        venta = new venta();
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
                        venta.cuadrado = Convert.ToBoolean(row[14]);
                        venta.monto_impuesto = Convert.ToDecimal(row[15]);
                        venta.pedido = Convert.ToBoolean(row[16]);
                        venta.codigo_tipo_venta = Convert.ToInt16(row[17]);
                        lista.Add(venta);
                    }
                }
                lista = lista.OrderByDescending(x => x.codigo).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista al completa de venta detalle by cuadre caja
        public List<venta_detalle> getListaVentaDetallesCompletaSinCuadradaBycuadreCaja(cuadre_caja cuadre)
        {
            try
            {
                List<venta_detalle> lista = new List<venta_detalle>();
                venta_detalle detalle = new venta_detalle();
                empleado empleado = new modeloEmpleado().getEmpleadoByCajeroId(cuadre.codigo_cajero);
                string sql = "select vd.codigo,vd.cod_venta,vd.cod_producto,vd.cod_unidad,vd.cantidad,vd.precio,vd.monto,vd.itebis,vd.descuento,vd.activo,vd.itebis_unitario,vd.descuento_unitario from venta_detalle vd join venta v on v.codigo=vd.cod_venta where cuadrado='0' and v.activo='1' and vd.activo='1' and v.fecha>='" + utilidades.getFechayyyyMMdd(cuadre.fecha) + "' and v.fecha<='" + utilidades.getFechayyyyMMdd(cuadre.fecha) + "' and v.codigo_empleado='" + empleado.codigo + "' and cod_sucursal='" + cuadre.codigo_sucursal + "' ";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        detalle = new venta_detalle();
                        detalle.codigo = Convert.ToInt16(row[0]);
                        detalle.cod_venta = Convert.ToInt16(row[1]);
                        detalle.codigo_producto = Convert.ToInt16(row[2]);
                        detalle.codigo_unidad = Convert.ToInt16(row[3]);
                        detalle.cantidad = Convert.ToDecimal(row[4]);
                        detalle.precio = Convert.ToDecimal(row[5]);
                        detalle.monto_total = Convert.ToDecimal(row[6]);
                        detalle.monto_itebis = Convert.ToDecimal(row[7]);
                        detalle.monto_descuento = Convert.ToDecimal(row[8]);
                        detalle.activo = Convert.ToBoolean(row[9]);
                        detalle.itbis_unitario = Convert.ToDecimal(row[10]);
                        detalle.monto_descuento = Convert.ToDecimal(row[11]);
                        lista.Add(detalle);
                    }
                }
                lista = lista.OrderByDescending(x => x.codigo).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaDetallesCompletaSinCuadradaBycuadreCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



    }
}
