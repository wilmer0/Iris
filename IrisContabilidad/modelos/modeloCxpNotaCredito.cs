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
    public class modeloCxpNotaCredito
    {
        //objetos
        private utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarNotaCredito(cxp_nota_credito notaCredito)
        {
            try
            {
                int activo = 0;
                string sql = "";
                DataSet ds = new DataSet();

                if (notaCredito.activo == true)
                {
                    activo = 1;
                }

                sql =
                    "insert into cxp_nota_credito(codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion) values('" +
                    notaCredito.codigo + "','" + notaCredito.codigoSuplidor + "'," +
                    utilidades.getFechayyyyMMdd(notaCredito.fecha) + ",'" + activo.ToString() + "','" +
                    notaCredito.codigoEmpleado + "','" + notaCredito.monto + "','" + notaCredito.detalle + "','" +
                    notaCredito.codigoCompra + "','" + notaCredito.codigoConcepto + "','" + notaCredito.codigoDevolucion +
                    "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarNotaCredito.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarNotaCredito(cxp_nota_credito notaCredito)
        {
            try
            {
                int activo = 0;

                string sql = "";
                DataSet ds = new DataSet();



                if (notaCredito.activo == true)
                {
                    activo = 1;
                }
                sql = "update cxp_nota_credito set codigo_suplidor='" + notaCredito.codigoSuplidor + "',fecha='" +
                      utilidades.getFechayyyyMMdd(notaCredito.fecha) + "',activo='" + activo.ToString() +
                      "',codigo_empleado='" + notaCredito.codigoEmpleado + "',monto='" + notaCredito.monto +
                      "',detalle='" + notaCredito.detalle + "',codigo_compra='" + notaCredito.codigoCompra +
                      "',codigo_concepto='" + notaCredito.codigoConcepto + "',codigo_devolucion='" +
                      notaCredito.codigoDevolucion + "' where codigo='" + notaCredito.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarNotaCredito.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from cxp_nota_credito";
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
        public cxp_nota_credito getNotaCreditoById(int id)
        {
            try
            {
                cxp_nota_credito notaCredito = new cxp_nota_credito();
                string sql =
                    "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion from cxp_nota_credito where codigo='" +
                    id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    notaCredito.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    notaCredito.codigoSuplidor = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    notaCredito.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                    notaCredito.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    notaCredito.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                    notaCredito.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][5]);
                    notaCredito.detalle = ds.Tables[0].Rows[0][6].ToString();
                    notaCredito.codigoCompra = Convert.ToInt16(ds.Tables[0].Rows[0][7]);
                    notaCredito.codigoConcepto = Convert.ToInt16(ds.Tables[0].Rows[0][8]);
                    notaCredito.codigoDevolucion = Convert.ToInt16(ds.Tables[0].Rows[0][9]);
                }
                return notaCredito;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNotaCreditoById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<cxp_nota_credito> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<cxp_nota_credito> lista = new List<cxp_nota_credito>();
                string sql =
                    "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion from cxp_nota_credito ";

                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_credito notaCredito = new cxp_nota_credito();
                        notaCredito.codigo = Convert.ToInt16(row[0]);
                        notaCredito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaCredito.fecha = Convert.ToDateTime(row[2]);
                        notaCredito.activo = Convert.ToBoolean(row[3]);
                        notaCredito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaCredito.monto = Convert.ToDecimal(row[5]);
                        notaCredito.detalle = row[6].ToString();
                        notaCredito.codigoCompra = Convert.ToInt16(row[7]);
                        notaCredito.codigoConcepto = Convert.ToInt16(row[8]);
                        notaCredito.codigoDevolucion = Convert.ToInt16(row[9]);
                        lista.Add(notaCredito);
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

        //get lista completa by compra
        public List<cxp_nota_credito> getListaByCompraActivo(int id)
        {
            try
            {

                List<cxp_nota_credito> lista = new List<cxp_nota_credito>();
                string sql ="select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion from cxp_nota_credito where codigo_compra='"+id + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_credito notaCredito = new cxp_nota_credito();
                        notaCredito.codigo = Convert.ToInt16(row[0]);
                        notaCredito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaCredito.fecha = Convert.ToDateTime(row[2]);
                        notaCredito.activo = Convert.ToBoolean(row[3]);
                        notaCredito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaCredito.monto = Convert.ToDecimal(row[5]);
                        notaCredito.detalle = row[6].ToString();
                        notaCredito.codigoCompra = Convert.ToInt16(row[7]);
                        notaCredito.codigoConcepto = Convert.ToInt16(row[8]);
                        notaCredito.codigoDevolucion = Convert.ToInt16(row[9]);
                        lista.Add(notaCredito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByCompraActivo.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        public List<cxp_nota_credito> getListaByVentaActivoAndRangoFechaFinal(int id, DateTime fechaFinal)
        {
            try
            {

                List<cxp_nota_credito> lista = new List<cxp_nota_credito>();
                string sql =
                    "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion from cxp_nota_credito where fecha<='" +
                    utilidades.getFechayyyyMMdd(fechaFinal) + "' and codigo_compra='" + id + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_credito notaCredito = new cxp_nota_credito();
                        notaCredito.codigo = Convert.ToInt16(row[0]);
                        notaCredito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaCredito.fecha = Convert.ToDateTime(row[2]);
                        notaCredito.activo = Convert.ToBoolean(row[3]);
                        notaCredito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaCredito.monto = Convert.ToDecimal(row[5]);
                        notaCredito.detalle = row[6].ToString();
                        notaCredito.codigoCompra = Convert.ToInt16(row[7]);
                        notaCredito.codigoConcepto = Convert.ToInt16(row[8]);
                        notaCredito.codigoDevolucion = Convert.ToInt16(row[9]);
                        lista.Add(notaCredito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByVentaActivo.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa by cliente
        public List<cxp_nota_credito> getListaBySuplidor(int id)
        {
            try
            {

                List<cxp_nota_credito> lista = new List<cxp_nota_credito>();
                string sql =
                    "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion from cxp_nota_credito where codigo_suplidor='" +
                    id + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_credito notaCredito = new cxp_nota_credito();
                        notaCredito.codigo = Convert.ToInt16(row[0]);
                        notaCredito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaCredito.fecha = Convert.ToDateTime(row[2]);
                        notaCredito.activo = Convert.ToBoolean(row[3]);
                        notaCredito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaCredito.monto = Convert.ToDecimal(row[5]);
                        notaCredito.detalle = row[6].ToString();
                        notaCredito.codigoCompra = Convert.ToInt16(row[7]);
                        notaCredito.codigoConcepto = Convert.ToInt16(row[8]);
                        notaCredito.codigoDevolucion = Convert.ToInt16(row[9]);
                        lista.Add(notaCredito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaBySuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa by fechas
        public List<cxp_nota_credito> getListaByRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                List<cxp_nota_credito> lista = new List<cxp_nota_credito>();
                string sql =
                    "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion from cxp_nota_credito where fecha>='" +
                    utilidades.getFechayyyyMMdd(fechaInicial.Date) + "' and fecha<='" +
                    utilidades.getFechayyyyMMdd(fechaFinal.Date) + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxp_nota_credito notaCredito = new cxp_nota_credito();
                        notaCredito.codigo = Convert.ToInt16(row[0]);
                        notaCredito.codigoSuplidor = Convert.ToInt16(row[1]);
                        notaCredito.fecha = Convert.ToDateTime(row[2]);
                        notaCredito.activo = Convert.ToBoolean(row[3]);
                        notaCredito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaCredito.monto = Convert.ToDecimal(row[5]);
                        notaCredito.detalle = row[6].ToString();
                        notaCredito.codigoCompra = Convert.ToInt16(row[7]);
                        notaCredito.codigoConcepto = Convert.ToInt16(row[8]);
                        notaCredito.codigoDevolucion = Convert.ToInt16(row[9]);
                        lista.Add(notaCredito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByRangoFecha.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        public cxp_nota_credito getNotaCreditoByDevolucionId(int id)
        {
            try
            {
                cxp_nota_credito notaCredito;
                string sql =
                    "select codigo,codigo_suplidor,fecha,activo,codigo_empleado,monto,detalle,codigo_compra,codigo_concepto,codigo_devolucion from cxp_nota_credito where codigo_devolucion='" +
                    id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    notaCredito = new cxp_nota_credito();
                    notaCredito.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    notaCredito.codigoSuplidor = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    notaCredito.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                    notaCredito.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    notaCredito.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                    notaCredito.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][5]);
                    notaCredito.detalle = ds.Tables[0].Rows[0][6].ToString();
                    notaCredito.codigoCompra = Convert.ToInt16(ds.Tables[0].Rows[0][7]);
                    notaCredito.codigoConcepto = Convert.ToInt16(ds.Tables[0].Rows[0][8]);
                    notaCredito.codigoDevolucion = Convert.ToInt16(ds.Tables[0].Rows[0][9]);

                    return notaCredito;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNotaCreditoByDevolucionId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
