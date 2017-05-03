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
    public class modeloCxcNotaDebito
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarNotaDebito(cxc_nota_debito notaDebito)
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

                sql = "insert into cxc_nota_debito(codigo,codigo_cliente,fecha,activo,codigo_empleado,monto,detalle,codigo_venta,codigo_concepto) values('" + notaDebito.codigo + "','" + notaDebito.codigoCliente + "'," + utilidades.getFechayyyyMMdd(notaDebito.fecha) + ",'" + activo.ToString() + "','" + notaDebito.codigoEmpleado + "','" + notaDebito.monto + "','" + notaDebito.detalle + "','" + notaDebito.codigoVenta + "','" + notaDebito.codigoConcepto + "')";
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
        public bool modificarNotaDebito(cxc_nota_debito notaDebito)
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
                sql = "update cxc_nota_debito set codigo_cliente='" + notaDebito.codigoCliente + "',fecha='" + utilidades.getFechayyyyMMdd(notaDebito.fecha) + "',activo='" + activo.ToString() + "',codigo_empleado='" + notaDebito.codigoEmpleado + "',monto='" + notaDebito.monto + "',detalle='" + notaDebito.detalle + "',codigo_venta='" + notaDebito.codigoVenta + "',codigo_concepto='" + notaDebito.codigoConcepto + "' where codigo='" + notaDebito.codigo + "'";
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
                string sql = "select max(codigo)from cxc_nota_debito";
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
        public cxc_nota_debito getNotaDebitoById(int id)
        {
            try
            {
                cxc_nota_debito notaDebito = new cxc_nota_debito();
                string sql = "select codigo,codigo_cliente,fecha,activo,codigo_empleado,monto,detalle,codigo_venta,codigo_concepto from cxc_nota_debito where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    notaDebito.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    notaDebito.codigoCliente = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    notaDebito.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                    notaDebito.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    notaDebito.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                    notaDebito.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][5]);
                    notaDebito.detalle = ds.Tables[0].Rows[0][6].ToString();
                    notaDebito.codigoVenta = Convert.ToInt16(ds.Tables[0].Rows[0][7]);
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
        public List<cxc_nota_debito> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<cxc_nota_debito> lista = new List<cxc_nota_debito>();
                string sql = "select codigo,codigo_cliente,fecha,activo,codigo_empleado,monto,detalle,codigo_venta,codigo_concepto from cxc_nota_debito ";

                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxc_nota_debito notaDebito = new cxc_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoCliente = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoVenta = Convert.ToInt16(row[7]);
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
        public List<cxc_nota_debito> getListaByVentaActivo(int id)
        {
            try
            {

                List<cxc_nota_debito> lista = new List<cxc_nota_debito>();
                string sql = "select codigo,codigo_cliente,fecha,activo,codigo_empleado,monto,detalle,codigo_venta,codigo_concepto from cxc_nota_debito where codigo_venta='" + id + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxc_nota_debito notaDebito = new cxc_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoCliente = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoVenta = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByVentaActivo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
       
        //get lista completa by cliente
        public List<cxc_nota_debito> getListaByCliente(int id)
        {
            try
            {

                List<cxc_nota_debito> lista = new List<cxc_nota_debito>();
                string sql = "select codigo,codigo_cliente,fecha,activo,codigo_empleado,monto,detalle,codigo_venta,codigo_concepto from cxc_nota_debito where codigo_cliente='" + id + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxc_nota_debito notaDebito = new cxc_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoCliente = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoVenta = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        //get lista completa by fechas
        public List<cxc_nota_debito> getListaByRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                List<cxc_nota_debito> lista = new List<cxc_nota_debito>();
                string sql = "select codigo,codigo_cliente,fecha,activo,codigo_empleado,monto,detalle,codigo_venta,codigo_concepto from cxc_nota_debito where fecha>='" + utilidades.getFechayyyyMMdd(fechaInicial.Date) + "' and fecha<='" + utilidades.getFechayyyyMMdd(fechaFinal.Date) + "' and activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxc_nota_debito notaDebito = new cxc_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoCliente = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoVenta = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa byc uadre caja 
        public List<cxc_nota_debito> getListaCompletaByCuadreCaja(cuadre_caja cuadre)
        {
            try
            {
                empleado empleado = new modeloEmpleado().getEmpleadoByCajeroId(cuadre.codigo_cajero);
                if (empleado == null)
                {
                    MessageBox.Show("Error empleado nulo en base al cajero .:getListaCompletaByCuadreCaja ", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                List<cxc_nota_debito> lista = new List<cxc_nota_debito>();
                string sql = "select codigo,codigo_cliente,fecha,activo,codigo_empleado,monto,detalle,codigo_venta,codigo_concepto,cuadrado,contabilizado from cxc_nota_debito where  activo='1' and cuadrado='0' and fecha>='" + utilidades.getFechayyyyMMdd(cuadre.fecha) + "' and fecha<='" + utilidades.getFechayyyyMMdd(cuadre.fecha_cierre_cuadre) + "' and codigo_empleado='"+cuadre.codigo_cajero+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cxc_nota_debito notaDebito = new cxc_nota_debito();
                        notaDebito.codigo = Convert.ToInt16(row[0]);
                        notaDebito.codigoCliente = Convert.ToInt16(row[1]);
                        notaDebito.fecha = Convert.ToDateTime(row[2]);
                        notaDebito.activo = Convert.ToBoolean(row[3]);
                        notaDebito.codigoEmpleado = Convert.ToInt16(row[4]);
                        notaDebito.monto = Convert.ToDecimal(row[5]);
                        notaDebito.detalle = row[6].ToString();
                        notaDebito.codigoVenta = Convert.ToInt16(row[7]);
                        notaDebito.codigoConcepto = Convert.ToInt16(row[8]);
                        notaDebito.cuadrado = Convert.ToBoolean(row[9]);
                        notaDebito.contabilizado = Convert.ToBoolean(row[10]);
                        lista.Add(notaDebito);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaByCuadreCaja.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    
    }
}
