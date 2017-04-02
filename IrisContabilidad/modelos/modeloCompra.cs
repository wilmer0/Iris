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
    public class modeloCompra
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCompra(compra compra, List<compra_detalle> listaDetalle )
        {
            try
            {
                int suplidorInformal = 0;
                int activo = 0;
                int pagada = 0;


                if (compra.suplidor_informal == true)
                {
                    suplidorInformal = 1;
                }
                if (compra.activo == true)
                {
                    activo = 1;
                }
                if (compra.pagada == true)
                {
                    pagada = 1;
                }
                string sql = "insert into compra(codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal) values('" + compra.codigo + "','" + compra.numero_factura + "','" + compra.cod_suplidor + "'," + utilidades.getFechayyyyMMdd(compra.fecha) + "," + utilidades.getFechayyyyMMdd(compra.fecha_limite.AddDays(120)) + ",'" + compra.ncf + "','" + compra.tipo_compra + "','" + activo + "','" + pagada + "','" + compra.codigo_sucursal + "','" + compra.codigo_empleado + "','0','','" + compra.detalle + "','" + suplidorInformal + "')";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                //insertar compra detalle
                listaDetalle.ForEach(x =>
                {
                    x.codigo = getNextCompraDetalle();
                    sql = "insert into compra_detalle(codigo,cod_compra,cod_producto,cod_unidad,precio,cantidad,monto,descuento,activo) values('"+x.codigo+"','"+compra.codigo+"','"+x.cod_producto+"','"+x.cod_unidad+"','"+x.precio+"','"+x.cantidad+"','"+x.monto+"','"+x.monto_descuento+"','1')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                //insertar compra en inventario
                listaDetalle.ForEach(x =>
                {
                    x.codigo = getNextInventario();
                    DateTime fechaHoy=DateTime.Today;
                    sql = "insert into inventario(codigo,codigo_producto,codigo_unidad,cantidad,fecha_entrada,fecha_vencimiento) values('" + x.codigo + "','" + x.cod_producto + "','" + x.cod_unidad + "','" + x.cantidad + "'," + utilidades.getFechayyyyMMdd(fechaHoy) + "," + utilidades.getFechayyyyMMdd(fechaHoy.AddDays(120)) + ")";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCompra(compra compra)
        {
            try
            {
                int suplidorInformal = 0;
                int activo = 0;
                int pagada = 0;
                //validar comprobante fiscal
                string sql = "select *from compra where ncf='" + compra.ncf + "' and codigo!='" + compra.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una compra con el mismo numero de comprobante fiscal", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                if (compra.suplidor_informal == true)
                {
                    suplidorInformal = 1;
                }
                if (compra.activo == true)
                {
                    activo = 1;
                }
                if (compra.pagada == true)
                {
                    pagada = 1;
                }
                sql = "update compra set num_factura='" + compra.numero_factura + "',cod_suplidor='" + compra.cod_suplidor + "',fecha=" + utilidades.getFechaddMMyyyy(compra.fecha) + ",fecha_limite=" + utilidades.getFechaddMMyyyy(compra.fecha_limite) + ",ncf='" + compra.ncf + "',tipo_compra='" + compra.tipo_compra + "',activo'" + activo + "',pagada='" + pagada + "',cod_sucursal='" + compra.codigo_sucursal + "',codigo_empleado='" + compra.codigo_empleado + "',codigo_empleado_anular='" + compra.codigo_empleado_anular + "',motivo_anulado='" + compra.motivo_anulada + "',detalle='" + compra.detalle + "',suplidor_informal='"+suplidorInformal+"' where codigo='" + compra.codigo + "'";
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
                string sql = "select max(codigo)from compra";
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
        public int getNextCompraDetalle()
        {
            try
            {
                string sql = "select max(codigo)from compra_detalle";
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
        
        //obtener el codigo siguiente pago
        public int getNextPago()
        {
            try
            {
                string sql = "select max(codigo)from compra_vs_pagos";
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
        
        //obtener el codigo siguiente pago detalle
        public int getNextPagoDetalle()
        {
            try
            {
                string sql = "select max(codigo)from compra_vs_pagos_detalles";
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

        //get compra by id
        public compra getCompraById(int id)
        {
            try
            {
                compra compra=new compra();
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
                    compra.tipo_compra=ds.Tables[0].Rows[0][6].ToString();
                    compra.activo=Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    compra.pagada=Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    compra.codigo_sucursal=Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    compra.codigo_empleado=Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    compra.codigo_empleado_anular=Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                    compra.motivo_anulada=ds.Tables[0].Rows[0][12].ToString();
                    compra.detalle=ds.Tables[0].Rows[0][13].ToString();
                    compra.suplidor_informal=Convert.ToBoolean(ds.Tables[0].Rows[0][14].ToString());
                    
                }
                return compra;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCompraById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        //get compra by id
        public compra getCompraBySuplidorNumeroCompra(suplidor suplidor,string numeroCompra)
        {
            try
            {
                compra compra = new compra();
                string sql = "select codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal from compra where num_factura='" + numeroCompra + "' and cod_suplidor='"+suplidor.codigo+"'";
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
                    compra.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    compra.pagada = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    compra.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    compra.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    compra.codigo_empleado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                    compra.motivo_anulada = ds.Tables[0].Rows[0][12].ToString();
                    compra.detalle = ds.Tables[0].Rows[0][13].ToString();
                    compra.suplidor_informal = Convert.ToBoolean(ds.Tables[0].Rows[0][14]);

                }
                return compra;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCompraBySuplidorNumeroCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista compra detalle
        public List<compra_detalle> getListaCompraDetalleByCompra(int id, bool SoloActivo = true)
        {
            try
            {

                List<compra_detalle> lista = new List<compra_detalle>();
                string sql = "";
                sql = "select codigo,cod_compra,cod_producto,cod_unidad,precio,cantidad,monto,descuento,activo from compra_detalle where cod_compra='"+id+"'";
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
                        compra_detalle compraDetalle=new compra_detalle();
                        compraDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        compraDetalle.cod_compra = Convert.ToInt16(row[1].ToString());
                        compraDetalle.cod_producto=Convert.ToInt16(row[2].ToString());
                        compraDetalle.cod_unidad=Convert.ToInt16(row[3].ToString());
                        compraDetalle.precio=Convert.ToDecimal(row[4].ToString());
                        compraDetalle.cantidad=Convert.ToDecimal(row[5].ToString());
                        compraDetalle.monto=Convert.ToDecimal(row[6].ToString());
                        compraDetalle.monto_descuento=Convert.ToDecimal(row[7].ToString());
                        compraDetalle.activo = Convert.ToBoolean(row[8].ToString());
                        lista.Add(compraDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraDetalleByCompra.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        
        //get lista completa de compras
        public List<compra> getListaCompra()
        {
            try
            {
                List<compra>lista=new List<compra>();
                compra compra = new compra();
                string sql = "select codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal from compra";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        compra = new compra();
                        compra.codigo = Convert.ToInt16(row[0].ToString());
                        compra.numero_factura = row[1].ToString();
                        compra.cod_suplidor = Convert.ToInt16(row[2].ToString());
                        compra.fecha = Convert.ToDateTime(row[3].ToString());
                        compra.fecha_limite = Convert.ToDateTime(row[4].ToString());
                        compra.ncf = row[5].ToString();
                        compra.tipo_compra = row[6].ToString();
                        compra.activo = Convert.ToBoolean(row[7]);
                        compra.pagada = Convert.ToBoolean(row[8]);
                        compra.codigo_sucursal = Convert.ToInt16(row[9].ToString());
                        compra.codigo_empleado = Convert.ToInt16(row[10].ToString());
                        compra.codigo_empleado_anular = Convert.ToInt16(row[11].ToString());
                        compra.motivo_anulada = row[12].ToString();
                        compra.detalle = row[13].ToString();
                        compra.suplidor_informal = Convert.ToBoolean(row[14]);
                        lista.Add(compra);
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
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        compra = new compra();
                        compra.codigo = Convert.ToInt16(row[0].ToString());
                        compra.numero_factura = row[1].ToString();
                        compra.cod_suplidor = Convert.ToInt16(row[2].ToString());
                        compra.fecha = Convert.ToDateTime(row[3].ToString());
                        compra.fecha_limite = Convert.ToDateTime(row[4].ToString());
                        compra.ncf = row[5].ToString();
                        compra.tipo_compra = row[6].ToString();
                        compra.activo = Convert.ToBoolean(row[7]);
                        compra.pagada = Convert.ToBoolean(row[8]);
                        compra.codigo_sucursal = Convert.ToInt16(row[9].ToString());
                        compra.codigo_empleado = Convert.ToInt16(row[10].ToString());
                        compra.codigo_empleado_anular = Convert.ToInt16(row[11].ToString());
                        compra.motivo_anulada = row[12].ToString();
                        compra.detalle = row[13].ToString();
                        compra.suplidor_informal = Convert.ToBoolean(row[14]);
                        lista.Add(compra);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraBySuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        //hacer pagos a compra a contado
        public bool setCompraPago(compra compra,compra_vs_pagos pago,List<compra_vs_pagos_detalles> listaPagoDetalle)
        {
            try
            {
                //si la compra es a credito entonces no debe hacer ningun pago
                if (compra.tipo_compra != "CON")
                {
                    return true;
                }

                //compra vs pagos
                //insert into compra_vs_pagos(codigo,fecha,detalle,cod_empleado,activo,cod_empleado,motivo_anulado,cuadrdo) values('','','','','','','','');
                int activo = 0;
                int cuadrado = 0;
                if (pago.activo == true)
                {
                    activo = 1;
                }
                if (pago.cuadrado == true)
                {
                    cuadrado = 1;
                }
                
                //pago encabezado
                string sql = "insert into compra_vs_pagos(codigo,fecha,detalle,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado) values('"+pago.codigo+"',"+utilidades.getFechayyyyMMdd(pago.fecha)+",'"+pago.detalle+"','"+pago.cod_empleado+"','"+activo+"','"+pago.cod_empleado_anular+"','"+pago.motivo_anulado+"','"+cuadrado+"')";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                
                //pago detalles
                listaPagoDetalle.ForEach(x =>
                {
                    x.codigo = getNextPagoDetalle();
                    x.codigo_pago = pago.codigo;
                    activo = 0;
                    if (x.activo == true)
                    {
                        activo = 1;
                    }
                    x.codigo_compra = compra.codigo;
                    sql = "insert into compra_vs_pagos_detalles(codigo,cod_pago,cod_compra,cod_metodo_pago,monto_pagado,monto_descontado,activo,monto_subtotal) values('"+x.codigo+"','"+x.codigo_pago+"','"+x.codigo_compra+"','"+x.codigo_metodo_pago+"','"+x.monto_pagado+"','"+x.monto_descontado+"','"+activo+"','"+x.monto_sub_total+"')";
                    utilidades.ejecutarcomando_mysql(sql);
                    
                });
                if (compra.tipo_compra == "CON")
                {
                    sql = "update compra set pagada='1' where codigo='" + compra.codigo + "'";
                    utilidades.ejecutarcomando_mysql(sql);
                    
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCompraPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //hacer pagos abono a compra
        public bool setCompraPago(compra_vs_pagos compraPago,List<compra_vs_pagos_detalles>listaPagoDetalles )
        {
            try
            {
                //si la compra es a credito entonces no debe hacer ningun pago
                if (compraPago==null)
                {
                    return false;
                }
                if (listaPagoDetalles == null)
                {
                    return false;
                }

                //compra vs pagos
                //insert into compra_vs_pagos(codigo,fecha,detalle,cod_empleado,activo,cod_empleado,motivo_anulado,cuadrdo) values('','','','','','','','');
                int activo = 0;
                int cuadrado = 0;
                if (compraPago.activo == true)
                {
                    activo = 1;
                }
                if (compraPago.cuadrado == true)
                {
                    cuadrado = 1;
                }

                //pago encabezado
                string sql = "insert into compra_vs_pagos(codigo,fecha,detalle,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado) values('" + compraPago.codigo + "'," + utilidades.getFechayyyyMMdd(compraPago.fecha) + ",'" + compraPago.detalle + "','" + compraPago.cod_empleado + "','" + activo + "','" + compraPago.cod_empleado_anular + "','" + compraPago.motivo_anulado + "','" + cuadrado + "')";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);

                //pago detalles
                listaPagoDetalles.ForEach(x =>
                {
                    x.codigo = getNextPagoDetalle();
                    x.codigo_pago = compraPago.codigo;
                    activo = 0;
                    if (x.activo == true)
                    {
                        activo = 1;
                    }
                    sql = "insert into compra_vs_pagos_detalles(codigo,cod_pago,cod_compra,cod_metodo_pago,monto_pagado,monto_descontado,monto_subtotal,activo) values('" + x.codigo + "','" + x.codigo_pago + "','" + x.codigo_compra + "','" + x.codigo_metodo_pago + "','" + x.monto_pagado + "','" + x.monto_descontado +"','"+x.monto_sub_total+"','" + activo + "')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setCompraPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //get monto pendiente compra by compra
        public List<compra_vs_pagos_detalles> getListaPagosByCompra(int id, bool SoloActivo = true)
        {
            try
            {
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                compra_vs_pagos_detalles pagoDetalle = new compra_vs_pagos_detalles();
                string sql = "select codigo,cod_pago,cod_compra,cod_metodo_pago,monto_pagado,monto_descontado,activo from compra_vs_pagos_detalles where cod_compra='" + id + "'";
                if (SoloActivo == true)
                {
                    sql += " and activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        pagoDetalle = new compra_vs_pagos_detalles();
                        pagoDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        pagoDetalle.codigo_pago = Convert.ToInt16(row[1].ToString());
                        pagoDetalle.codigo_compra = Convert.ToInt16(row[2].ToString());
                        pagoDetalle.codigo_metodo_pago = Convert.ToInt16(row[3].ToString());
                        pagoDetalle.monto_pagado = Convert.ToDecimal(row[4].ToString());
                        pagoDetalle.monto_descontado = Convert.ToDecimal(row[5].ToString());
                        pagoDetalle.activo = Convert.ToBoolean(row[6]);
                        lista.Add(pagoDetalle);   
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaPagosByCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        //get monto pendiente by compra
        public decimal getMontoPendienteBycompra(int id)
        {
            try
            {
                decimal montoCompra = 0;
                decimal montoPendiente = 0;
                decimal montoDescuento = 0;
                decimal montoPagado = 0;
                decimal montoNotasDebito = 0;
                decimal montoNotasCredito = 0;

                List<cxp_nota_debito> listaNotasDebito = new List<cxp_nota_debito>();
                List<cxp_nota_credito> listaNotasCredito = new List<cxp_nota_credito>();
                List<compra_detalle> listaCompraDetalle = new List<compra_detalle>();
                List<compra_vs_pagos_detalles> listaPagos = new List<compra_vs_pagos_detalles>();

                listaNotasDebito = new modeloCxpNotaDebito().getListaByCompraActivo(id);
                listaNotasCredito = new modeloCxpNotaCredito().getListaByCompraActivo(id);
                listaCompraDetalle = getListaCompraDetalleByCompra(id);
                listaPagos = getListaPagosByCompra(id);

                if (listaCompraDetalle.Count > 0)
                {
                    //sumar los montos
                    listaCompraDetalle.ForEach(x =>
                    {
                        montoCompra += x.monto;
                        montoDescuento += x.monto_descuento;
                    });
                }
                //montos de pagos
                if (listaPagos.Count > 0)
                {
                    listaPagos.ForEach(x =>
                    {
                        montoPagado += x.monto_pagado ;
                    });
                }

                //monto nota debitos
                listaNotasDebito.ForEach(x =>
                {
                    montoNotasDebito += x.monto;
                });
                
                //monto nota credito
                listaNotasCredito.ForEach(x =>
                {
                    montoNotasCredito += x.monto;
                });

                //pendiente = (monto compra + cargos a mi compra) - (monto pagado + monto descontado a mi compra)
                montoPendiente = (montoCompra +montoNotasDebito) - (montoPagado + montoNotasCredito);
                
                return montoPendiente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMontoPendienteBycompra.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
        }

        //get compra pago by id
        public compra_vs_pagos getCompraPagoById(int id)
        {
            try
            {
                compra_vs_pagos pagoDetalle = new compra_vs_pagos();
                string sql = "select codigo,fecha,detalle,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado from compra_vs_pagos where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pagoDetalle = new compra_vs_pagos();
                    pagoDetalle.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    pagoDetalle.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][1].ToString());
                    pagoDetalle.detalle = ds.Tables[0].Rows[0][2].ToString();
                    pagoDetalle.cod_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    pagoDetalle.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    pagoDetalle.cod_empleado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][5].ToString());
                    pagoDetalle.motivo_anulado =ds.Tables[0].Rows[0][6].ToString();
                    pagoDetalle.cuadrado = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);

                }
                return pagoDetalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCompraPagoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista compra pago detalle by codigo compra pago
        public List<compra_vs_pagos_detalles> getListaCompraPagoDetalleByIdCompraPago(int codigoPago, bool SoloActivo = true)
        {
            try
            {
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                string sql = "";
                sql = "select codigo,cod_pago,cod_compra,cod_metodo_pago,monto_pagado,monto_descontado,activo from compra_vs_pagos_detalles where cod_pago='" + codigoPago + "'";
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
                        compra_vs_pagos_detalles compraPagoDetalle = new compra_vs_pagos_detalles();
                        compraPagoDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        compraPagoDetalle.codigo_pago = Convert.ToInt16(row[1].ToString());
                        compraPagoDetalle.codigo_compra = Convert.ToInt16(row[2].ToString());
                        compraPagoDetalle.codigo_metodo_pago = Convert.ToInt16(row[3].ToString());
                        compraPagoDetalle.monto_pagado = Convert.ToDecimal(row[4].ToString());
                        compraPagoDetalle.monto_descontado = Convert.ToDecimal(row[5].ToString());
                        compraPagoDetalle.activo = Convert.ToBoolean(row[6]);
                        lista.Add(compraPagoDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraPagoDetalleByIdCompraPago.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        
        //get lista compra pago detalle completa
        public List<compra_vs_pagos_detalles> getListaCompraPagoDetalleCompleta(bool SoloActivo = true)
        {
            try
            {
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                string sql = "";
                sql = "select codigo,cod_pago,cod_compra,cod_metodo_pago,monto_pagado,monto_descontado,activo from compra_vs_pagos_detalles where codigo>0 ";
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
                        compra_vs_pagos_detalles compraPagoDetalle = new compra_vs_pagos_detalles();
                        compraPagoDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        compraPagoDetalle.codigo_pago = Convert.ToInt16(row[1].ToString());
                        compraPagoDetalle.codigo_compra = Convert.ToInt16(row[2].ToString());
                        compraPagoDetalle.codigo_metodo_pago = Convert.ToInt16(row[3].ToString());
                        compraPagoDetalle.monto_pagado = Convert.ToDecimal(row[4].ToString());
                        compraPagoDetalle.monto_descontado = Convert.ToDecimal(row[5].ToString());
                        compraPagoDetalle.activo = Convert.ToBoolean(row[6]);
                        lista.Add(compraPagoDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraPagoDetalleCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        //set compra pagada
        public bool setCompraPagada(int idCompra)
        {
            try
            {
                string sql = "update compra set pagada='0' where codigo='"+idCompra+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setCompraPagada.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //get lista completa de compras no cuadrada by fecha final
        public List<compra> getListaCompraNoCuadradoByFechaFinalAndCajeroId(DateTime fechaFinal,int cajeroId)
        {
            try
            {
                List<compra> lista = new List<compra>();
                compra compra = new compra();
                string sql = "select codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal from compra";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        compra = new compra();
                        compra.codigo = Convert.ToInt16(row[0].ToString());
                        compra.numero_factura = row[1].ToString();
                        compra.cod_suplidor = Convert.ToInt16(row[2].ToString());
                        compra.fecha = Convert.ToDateTime(row[3].ToString());
                        compra.fecha_limite = Convert.ToDateTime(row[4].ToString());
                        compra.ncf = row[5].ToString();
                        compra.tipo_compra = row[6].ToString();
                        compra.activo = Convert.ToBoolean(row[7]);
                        compra.pagada = Convert.ToBoolean(row[8]);
                        compra.codigo_sucursal = Convert.ToInt16(row[9].ToString());
                        compra.codigo_empleado = Convert.ToInt16(row[10].ToString());
                        compra.codigo_empleado_anular = Convert.ToInt16(row[11].ToString());
                        compra.motivo_anulada = row[12].ToString();
                        compra.detalle = row[13].ToString();
                        compra.suplidor_informal = Convert.ToBoolean(row[14]);
                        lista.Add(compra);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraNoCuadradoByFechaFinalAndCajeroId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista compra pago detalle by compra
        public List<compra_vs_pagos_detalles> getListaCompraPagoDetalleByCompraId(int compraId)
        {
            try
            {
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                string sql = "";
                sql = "select codigo,cod_pago,cod_compra,cod_metodo_pago,monto_pagado,monto_descontado,activo from compra_vs_pagos_detalles where cod_metodo_pago='1' and cod_compra='" + compraId + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        compra_vs_pagos_detalles compraPagoDetalle = new compra_vs_pagos_detalles();
                        compraPagoDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        compraPagoDetalle.codigo_pago = Convert.ToInt16(row[1].ToString());
                        compraPagoDetalle.codigo_compra = Convert.ToInt16(row[2].ToString());
                        compraPagoDetalle.codigo_metodo_pago = Convert.ToInt16(row[3].ToString());
                        compraPagoDetalle.monto_pagado = Convert.ToDecimal(row[4].ToString());
                        compraPagoDetalle.monto_descontado = Convert.ToDecimal(row[5].ToString());
                        compraPagoDetalle.activo = Convert.ToBoolean(row[6]);
                        lista.Add(compraPagoDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraPagoDetalleByCompraId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista compra pago detalle completa by cuadre caja
        public List<compra_vs_pagos_detalles> getListaCompraPagoDetalleCompletaByCuadreCaja(cuadre_caja cuadre)
        {
            try
            {
                empleado empleado = new modeloEmpleado().getEmpleadoByCajeroId(cuadre.codigo_cajero);
                if (empleado == null)
                {
                    MessageBox.Show("Error no se puede obtener el empleado en base al cajero .: getListaCompraPagoDetalleCompletaByCuadreCaja","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return null;
                }
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                string sql = "";
                sql = "select cd.codigo,cd.cod_pago,cd.cod_compra,cd.cod_metodo_pago,cd.monto_pagado,cd.monto_descontado,cd.activo from compra_vs_pagos_detalles cd join compra_vs_pagos p on p.codigo=cd.cod_pago where p.activo='1' and p.cuadrado='0' and p.cod_empleado='"+empleado.codigo+"' and p.fecha>='" + utilidades.getFechayyyyMMdd(cuadre.fecha) + "' and p.fecha<='" + utilidades.getFechayyyyMMdd(cuadre.fecha_cierre_cuadre) + "' ";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        compra_vs_pagos_detalles compraPagoDetalle = new compra_vs_pagos_detalles();
                        compraPagoDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        compraPagoDetalle.codigo_pago = Convert.ToInt16(row[1].ToString());
                        compraPagoDetalle.codigo_compra = Convert.ToInt16(row[2].ToString());
                        compraPagoDetalle.codigo_metodo_pago = Convert.ToInt16(row[3].ToString());
                        compraPagoDetalle.monto_pagado = Convert.ToDecimal(row[4].ToString());
                        compraPagoDetalle.monto_descontado = Convert.ToDecimal(row[5].ToString());
                        compraPagoDetalle.activo = Convert.ToBoolean(row[6]);
                        lista.Add(compraPagoDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraPagoDetalleCompletaByCuadreCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}