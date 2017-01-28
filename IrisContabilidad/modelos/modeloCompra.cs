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
                
                string sql = "insert into compra(codigo,num_factura,cod_suplidor,fecha,fecha_limite,ncf,tipo_compra,activo,pagada,cod_sucursal,codigo_empleado,codigo_empleado_anular,motivo_anulado,detalle,suplidor_informal) values('" + compra.codigo + "','" + compra.numero_factura + "','" + compra.cod_suplidor + "','" + compra.fecha + "','" + compra.fecha_limite + "','" + compra.ncf + "','" + compra.tipo_compra + "','" + activo + "','"+pagada+"','" + compra.codigo_sucursal + "','" + compra.codigo_empleado + "','0','','" + compra.detalle + "','" + suplidorInformal + "')";
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
                    sql = "insert into inventario(codigo,codigo_producto,codigo_unidad,cantidad,fecha_entrada,fecha_vencimiento) values('" + x.codigo + "','" + x.cod_producto + "','" + x.cod_unidad + "','" + x.cantidad + "','" + fechaHoy.ToString("dd-MM-yyyy") + "','" + fechaHoy.AddDays(365).ToString("dd-MM-yyyy")+ "')";
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
                sql = "update compra set num_factura='" + compra.numero_factura + "',cod_suplidor='" + compra.cod_suplidor + "',fecha='" + compra.fecha + "',fecha_limite='" + compra.fecha_limite + "',ncf='" + compra.ncf + "',tipo_compra='" + compra.tipo_compra + "',activo'" + activo + "',pagada='" + pagada + "',cod_sucursal='" + compra.codigo_sucursal + "',codigo_empleado='" + compra.codigo_empleado + "',codigo_empleado_anular='" + compra.codigo_empleado_anular + "',motivo_anulado='" + compra.motivo_anulada + "',detalle='" + compra.detalle + "',suplidor_informal='"+suplidorInformal+"' where codigo='" + compra.codigo + "'";
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

        //get objeto
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
                    compra.activo=Convert.ToBoolean(ds.Tables[0].Rows[0][7].ToString());
                    compra.pagada=Convert.ToBoolean(ds.Tables[0].Rows[0][8].ToString());
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


        //get lista compra detalle
        public List<compra_detalle> getListaCompraDetalle(int id, bool incluirTodos = false)
        {
            try
            {

                List<compra_detalle> lista = new List<compra_detalle>();
                string sql = "";
                sql = "select codigo,cod_compra,cod_producto,cod_unidad,precio,cantidad,monto,descuento,activo from compra_detalle where cod_compra='"+id+"'";
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
                MessageBox.Show("Error getListaCompraDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa de compras
        public List<compra> getListaCompra(int id)
        {
            try
            {
                List<compra>lista=new List<compra>();
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
                    lista.Add(compra);
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
