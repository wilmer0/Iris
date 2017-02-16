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
    public class modeloGasto
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarGasto(gasto gasto)
        {
            try
            {
                int activo = 0;
                int contabilizado = 0;
                //validar que el ncf no se repita de ese mismo suplidor
                string sql = "select *from gastos where ncf='" + gasto.ncf+"' and cod_suplidor='"+gasto.codigo_suplidor+"' and codigo!='" + gasto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un gasto de este suplidor con el mismo NCF", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (gasto.activo == true)
                {
                    activo = 1;
                }
                if (gasto.contabilizado == true)
                {
                    contabilizado = 1;
                }
                sql = "insert into gastos(codigo,cod_empleado,cod_tipo_gasto,cod_suplidor,numero_factura,ncf,fecha,monto_subtotal,monto_itebis,monto_isr,monto_total,cod_tipo_isr,cod_tipo_itebis,detalles,detalle_anulado,contabilizado,activo) values ('" + gasto.codigo + "','" + gasto.codigo_empleado + "','" + gasto.codigo_tipo_gasto + "','" + gasto.codigo_suplidor + "','" + gasto.numero_factura + "','" + gasto.ncf + "','" + utilidades.getFechayyyyMMdd(gasto.fecha) + "','" + gasto.monto_subtotal + "','" + gasto.monto_itebis + "','" + gasto.monto_isr + "','" + gasto.monto_total + "','" + gasto.codigo_tipo_isr + "','" + gasto.codigo_tipo_itebis + "','" + gasto.detalles + "','" + gasto.detalle_anulado + "','" + contabilizado + "','" + activo + "') ";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarGasto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarGasto(gasto gasto)
        {
            try
            {
                int activo = 0;
                int contabilizado = 0;
                string sql = "select *from gastos where ncf='" + gasto.ncf + "' and cod_suplidor='" + gasto.codigo_suplidor + "' and codigo!='" + gasto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un gasto de este suplidor con el mismo NCF", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (gasto.activo == true)
                {
                    activo = 1;
                }
                if (gasto.contabilizado == true)
                {
                    contabilizado = 1;
                }
                sql = "update gastos set cod_empleado='" + gasto.codigo_empleado + "',cod_tipo_gasto='" + gasto.codigo_tipo_gasto + "',cod_suplidor='" + gasto.codigo_suplidor + "',numero_factura='" + gasto.numero_factura + "',ncf='" + gasto.ncf + "',fecha='" + utilidades.getFechayyyyMMdd(gasto.fecha) + "',monto_subtotal='" + gasto.monto_subtotal + "',monto_itebis='" + gasto.monto_itebis + "',monto_isr='" + gasto.monto_isr + "',monto_total='" + gasto.monto_total + "',cod_tipo_isr='" + gasto.codigo_tipo_isr + "',cod_tipo_itebis='" + gasto.codigo_tipo_itebis + "',detalles='" + gasto.detalles + "',detalle_anulado='" + gasto.detalle_anulado + "',contabilizado='" + contabilizado + "',activo='" + activo + "' where codigo='" + gasto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarGasto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo) from gastos";
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


        //get objeto
        public gasto getGastoById(int id)
        {
            try
            {
                gasto gasto = new gasto();
                string sql = "SELECT codigo,cod_empleado,cod_tipo_gasto,cod_suplidor,numero_factura,ncf,fecha,monto_subtotal,monto_itebis,monto_isr,monto_total,cod_tipo_isr,cod_tipo_itebis,detalles,detalle_anulado,contabilizado,activo FROM gastos where codigo='"+id+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gasto.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    gasto.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    gasto.codigo_tipo_gasto = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    gasto.codigo_suplidor = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    gasto.numero_factura = ds.Tables[0].Rows[0][4].ToString();
                    gasto.ncf = ds.Tables[0].Rows[0][5].ToString();
                    gasto.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][6].ToString());
                    gasto.monto_subtotal = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString());
                    gasto.monto_itebis = Convert.ToDecimal(ds.Tables[0].Rows[0][8].ToString());
                    gasto.monto_isr = Convert.ToDecimal(ds.Tables[0].Rows[0][9].ToString());
                    gasto.monto_total = Convert.ToDecimal(ds.Tables[0].Rows[0][10].ToString());
                    gasto.codigo_tipo_isr = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                    gasto.codigo_tipo_itebis = Convert.ToInt16(ds.Tables[0].Rows[0][12].ToString());
                    gasto.detalles = ds.Tables[0].Rows[0][13].ToString();
                    gasto.detalle_anulado = ds.Tables[0].Rows[0][14].ToString();
                    gasto.contabilizado = Convert.ToBoolean(ds.Tables[0].Rows[0][15]);
                    gasto.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][16]);
                }
                return gasto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getGastoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<gasto> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<gasto> lista = new List<gasto>();
                string sql = "SELECT codigo,cod_empleado,cod_tipo_gasto,cod_suplidor,numero_factura,ncf,fecha,monto_subtotal,monto_itebis,monto_isr,monto_total,cod_tipo_isr,cod_tipo_itebis,detalles,detalle_anulado,contabilizado,activo FROM gastos";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        gasto gasto = new gasto();
                        gasto.codigo = Convert.ToInt16(row[0].ToString());
                        gasto.codigo_empleado = Convert.ToInt16(row[1].ToString());
                        gasto.codigo_tipo_gasto = Convert.ToInt16(row[2].ToString());
                        gasto.codigo_suplidor = Convert.ToInt16(row[3].ToString());
                        gasto.numero_factura = row[4].ToString();
                        gasto.ncf = row[5].ToString();
                        gasto.fecha = Convert.ToDateTime(row[6].ToString());
                        gasto.monto_subtotal = Convert.ToDecimal(row[7].ToString());
                        gasto.monto_itebis = Convert.ToDecimal(row[8].ToString());
                        gasto.monto_isr = Convert.ToDecimal(row[9].ToString());
                        gasto.monto_total = Convert.ToDecimal(row[10].ToString());
                        gasto.codigo_tipo_isr = Convert.ToInt16(row[11].ToString());
                        gasto.codigo_tipo_itebis = Convert.ToInt16(row[12].ToString());
                        gasto.detalles = row[13].ToString();
                        gasto.detalle_anulado = row[14].ToString();
                        gasto.contabilizado = Convert.ToBoolean(row[15]);
                        gasto.activo = Convert.ToBoolean(row[16]);
                        lista.Add(gasto);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
