using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;

namespace IrisContabilidad.modelos
{
    public class modeloVenta
    {
        //objetos
        utilidades utilidades = new utilidades();
        private producto producto;





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

                venta.numero_factura = utilidades.getRellenar(venta.codigo.ToString(), '0', 9);
                string sql = "insert into venta(codigo,num_factura,fecha,fecha_limite,codigo_empleado,codigo_cliente,ncf,tipo_venta,cod_sucursal,activo,pagada,cod_empleado_anular,motivo_anulada,cod_vendedor,despachado,autorizar_pedido,cuadrado,detalles,cod_tipo_comprobante) values('" + venta.codigo + "','" + venta.numero_factura + "','" + utilidades.getFechayyyyMMdd(venta.fecha) + "','" + utilidades.getFechayyyyMMdd(venta.fecha_limite) + "','" + venta.codigo_empleado + "','" + venta.codigo_cliente + "','" + venta.ncf + "','" + venta.tipo_venta + "','" + venta.codigo_sucursal + "','" + activo + "','" + pagada + "','" + venta.codigo_empelado_anular + "','" + venta.motivo_anulada + "','" + venta.codigo_vendedor + "','" + despachado + "','" + autorizarPedido + "','" + cuadrado + "','" + venta.detalle + "','" + venta.codigo_tipo_comprobante + "')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                //insertar venta detalle
                listaDetalle.ForEach(x =>
                {
                    x.codigo = getNextVentaDetalle();
                    sql = "insert into venta_detalle(codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo) values('" + x.codigo + "','" + venta.codigo + "','" + x.codigo_producto + "','" + x.codigo_unidad + "','" + x.cantidad + "','" + x.precio + "','" + x.monto + "','" + x.monto_itebis + "','"+x.monto_descuento+"','1')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                //sacar de inventario
                listaDetalle.ForEach(x =>
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
                        sql = "SELECT codpro_titular,codpro_requisito,cod_unidad,cantidad FROM producto_productos_requisitos where codpro_titular='"+x.codigo_producto+"'";
                        ds = utilidades.ejecutarcomando_mysql(sql);
                        if (ds.Tables[0].Rows[0][0].ToString()!="")
                        {
                           //si, tiene que sacar los requisitos de inventario
                            
                           if (ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    cantidadSacar = cantidadSacar*Convert.ToDecimal(row[3].ToString());
                                    setSalidaInventarioByProductoUnidad(Convert.ToInt16(row[1].ToString()), Convert.ToInt16(row[2].ToString()), cantidadSacar);
                                }
                            }
                        }


                        producto = new modeloProducto().getProductoById(x.codigo_producto);
                        sql ="select codigo,codigo_producto,codigo_unidad,cantidad,fecha_entrada,fecha_vencimiento from inventario where codigo_producto='" +x.codigo_producto + "' and codigo_unidad='" + x.codigo_unidad +"' ";
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
                string sql = "select codigo,num_factura,codigo_cliente,fecha,fecha_limite,ncf,tipo_venta,activo,pagada,cod_sucursal,codigo_empleado,cod_empleado_anular,motivo_anulada,detalles from venta where codigo='"+id+"'";
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
        public List<venta> getListaVenta(int id)
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
                MessageBox.Show("Error getListaCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string sql = "select codigo,num_factura,codigo_cliente,fecha,fecha_limite,ncf,tipo_venta,activo,pagada,cod_sucursal,codigo_empleado,cod_empleado_anular,motivo_anulada,detalles from venta where codigo_cliente='" + id + "'";
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
                MessageBox.Show("Error getListaVentasByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //si la compra es a credito entonces no debe hacer ningun pago
                if (venta.tipo_venta != "CON")
                {
                    return true;
                }

                //venta vs pagos
                //insert into venta_vs_pagos(codigo,fecha,detalle,cod_empleado,activo,cod_empleado,motivo_anulado,cuadradado) values('','','','','','','','');
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
                    sql = "insert into venta_vs_cobros_detalles(codigo,cod_cobro,cod_venta,cod_metodo_cobro,monto_cobrado,monto_descontado,activo) values('" + x.codigo + "','" + x.codigo_cobro + "','" + x.codigo_venta + "','" + x.codigo_metodo_cobro + "','" + x.monto_cobrado + "','" + x.monto_descontado + "','" + activo + "')";
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
                    sql = "insert into venta_vs_cobros_detalles(codigo,cod_cobro,cod_venta,cod_metodo_cobro,monto_cobrado,monto_descontado,activo) values('" + x.codigo + "','" + x.codigo_cobro + "','" + x.codigo_venta + "','" + x.codigo_metodo_cobro + "','" + x.monto_cobrado + "','" + x.monto_descontado + "','" + activo + "')";
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
        //get lista venta detalle by venta
        public List<venta_detalle> getListaVentaDetalleByVenta(int id)
        {
            try
            {
                List<venta_detalle> lista = new List<venta_detalle>();
                venta_detalle ventaDetalle = new venta_detalle();
                string sql = "select codigo,cod_venta,cod_producto,cod_unidad,cantidad,precio,monto,itebis,descuento,activo from venta_detalle where cod_venta='" + id + "'";
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
                        ventaDetalle.monto = Convert.ToDecimal(row[6].ToString());
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
        //get lista cobros by venta
        public List<venta_vs_cobros> getListaCobrosByVenta(int id)
        {
            try
            {
                List<venta_vs_cobros> lista = new List<venta_vs_cobros>();
                venta_vs_cobros cobro = new venta_vs_cobros();
                string sql = "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from venta_vs_cobros where codigo='"+id+"'";
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
        public List<venta_vs_cobros_detalles> getListaCobrosDetallesByVenta(int id)
        {
            try
            {
                List<venta_vs_cobros_detalles> lista = new List<venta_vs_cobros_detalles>();
                venta_vs_cobros_detalles cobroDetalle = new venta_vs_cobros_detalles();
                string sql = "select codigo,cod_cobro,cod_metodo_cobro,monto_cobrado,monto_descontado,activo,cod_venta from venta_vs_cobros_detalles where cod_cobro='" + id + "'";
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

        //get monto pendiente by venta
        public decimal getMontoPendienteByVenta(int id)
        {
            try
            {
                decimal montoVenta = 0;
                decimal montoPendiente = 0;
                decimal montoCobrado = 0;


                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaCobrosDetalle = new List<venta_vs_cobros_detalles>();

                listaVentaDetalle = getListaVentaDetalleByVenta(id);
                listaCobrosDetalle = getListaCobrosDetallesByVenta(id);

                if (listaVentaDetalle.Count > 0)
                {
                    //sumar los montos + descuento
                    listaVentaDetalle.ForEach(x =>
                    {
                        montoVenta += x.monto + x.monto_descuento;
                    });
                }

                if (listaCobrosDetalle.Count > 0)
                {
                    listaCobrosDetalle.ForEach(x =>
                    {
                        montoCobrado += x.monto_cobrado + x.monto_descontado;
                    });
                }

                montoPendiente = montoVenta - montoCobrado;

                return montoPendiente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoPendienteByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
        }

        //get lista venta by cliente
        public List<venta> getListaVentaByClienteId(int id)
        {
            try
            {
                List<venta> lista = new List<venta>();
                venta venta = new venta();
                string sql = "select codigo,num_factura,codigo_cliente,fecha,fecha_limite,ncf,tipo_venta,activo,pagada,cod_sucursal,codigo_empleado,cod_empleado_anular,motivo_anulada,detalles from venta where codigo_cliente='"+id+"'";
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
                        lista.Add(venta);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaVentaByClienteId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool setSalidaInventarioByProductoUnidad(int codigoProducto, int codigoUnidad,decimal cantidad)
        {
            try
            {
                
                //sacar de inventario
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
                        sql = "update inventario set cantidad='" + existencia + "' where codigo='" + codigoInventario + "'";
                        utilidades.ejecutarcomando_mysql(sql);
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
    }
}
