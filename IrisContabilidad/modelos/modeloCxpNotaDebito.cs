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
    public class modeloCxpNotaDebito
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarNotaDebito(cxp_nota_debito notaDebito)
        {
            try
            {
                int activo = 0;
                string sql = "";
                DataSet ds = new DataSet();

                if (notaDebito.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into cxp_nota_debito(codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto) values('" + notaDebito.codigo + "','" + notaDebito.codigoSuplidor + "'," + utilidades.getFechayyyyMMdd(notaDebito.fecha) + ",'" + activo.ToString() + "','" + notaDebito.codigoEmpleado + "','" + notaDebito.monto + "','" + notaDebito.detalle + "','" + notaDebito.codigoCompra + "','" + notaDebito.codigoConcepto + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarNotaDebito.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarNotaDebito(cxp_nota_debito notaDebito)
        {
            try
            {
                int activo = 0;

                string sql = "";
                DataSet ds = new DataSet();



                if (notaDebito.activo == true)
                {
                    activo = 1;
                }
                sql = "update cxp_nota_debito set codigo_suplidor='" + notaDebito.codigoSuplidor + "',fecha='" + utilidades.getFechayyyyMMdd(notaDebito.fecha) + "',activo='" + activo.ToString() + "',codigo_empleado='" + notaDebito.codigoEmpleado + "',monto='" + notaDebito.monto + "',detalle='" + notaDebito.detalle + "',codigo_compra='" + notaDebito.codigoCompra + "',codigo_concepto='" + notaDebito.codigoConcepto + "' where codigo='" + notaDebito.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarNotaDebito.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from cxp_nota_debito";
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
        public cxp_nota_debito getNotaDebitoById(int id)
        {
            try
            {
                cxp_nota_debito notaDebito = new cxp_nota_debito();
                string sql = "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto from cxp_nota_debito where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    notaDebito.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    notaDebito.codigoSuplidor = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    notaDebito.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                    notaDebito.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    notaDebito.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                    notaDebito.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][5]);
                    notaDebito.detalle = ds.Tables[0].Rows[0][6].ToString();
                    notaDebito.codigoCompra = Convert.ToInt16(ds.Tables[0].Rows[0][7]);
                    notaDebito.codigoConcepto = Convert.ToInt16(ds.Tables[0].Rows[0][8]);
                }
                return notaDebito;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNotaDebitoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<cxp_nota_debito> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<cxp_nota_debito> lista = new List<cxp_nota_debito>();
                string sql = "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto from cxp_nota_debito ";

                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_debito notaDebito = new cxp_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoCompra = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa by venta
        public List<cxp_nota_debito> getListaByCompraActivo(int id)
        {
            try
            {

                List<cxp_nota_debito> lista = new List<cxp_nota_debito>();
                string sql = "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto from cxp_nota_debito where codigo_compra='" + id + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_debito notaDebito = new cxp_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoCompra = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByCompraActivo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa by cliente
        public List<cxp_nota_debito> getListaBySuplidor(int id)
        {
            try
            {

                List<cxp_nota_debito> lista = new List<cxp_nota_debito>();
                string sql = "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto from cxp_nota_debito where codigo_suplidor='" + id + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_debito notaDebito = new cxp_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoCompra = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaBySuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa by fechas
        public List<cxp_nota_debito> getListaByRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                List<cxp_nota_debito> lista = new List<cxp_nota_debito>();
                string sql = "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto from cxp_nota_debito where fecha>='" + utilidades.getFechayyyyMMdd(fechaInicial.Date) + "' and fecha<='" + utilidades.getFechayyyyMMdd(fechaFinal.Date) + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_debito notaDebito = new cxp_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoCompra = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByRangoFecha.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
