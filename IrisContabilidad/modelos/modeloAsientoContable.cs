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
    class modeloAsientoContable
    {
        //objetos
        utilidades utilidades = new utilidades();

        //sql general
        private string sqlGeneral = "select codigo,codigo_asiento,fecha_sistema,fecha,monto,codigo_cuenta,debito,credito,activo from asiento_contable where codigo>'0' ";


        //agregar 
        public bool agregarAsientoContable(asiento_contable asientoContable)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = sqlGeneral + " and codigo='" + asientoContable.codigo + "' and codigo_asiento='" + asientoContable.codigoAsiento + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un asiento con el mismo codigo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                

                if (asientoContable.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into asientoContable(codigo,codigo_asiento,fecha_sistema,fecha,monto,codigo_cuenta,debito,credito,activo) values('" + asientoContable.codigo + "','" + asientoContable.codigoAsiento + "'," + utilidades.getFechayyyyMMdd(asientoContable.fechaSistema) + ",'" + utilidades.getFechayyyyMMdd(asientoContable.fecha) + ",'" + asientoContable.monto + "','" + asientoContable.codigoCuenta + "','" + asientoContable.debito+ "','" + asientoContable.credito + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarAsientoContable.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarAsientoContable(asiento_contable asientoContable)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("Existe un almacen con ese nombre", "", MessageBoxButtons.OK,
                //        MessageBoxIcon.Warning);
                //    return false;
                //}



                if (asientoContable.activo == true)
                {
                    activo = 1;
                }
                sql = "update asiento_contable set monto='"+asientoContable.monto+"',codigo_cuenta='"+asientoContable.codigoCuenta+"',debito='"+asientoContable.debito+"',credito='"+asientoContable.credito+"',activo='"+activo.ToString()+"' where codigo='" + asientoContable.codigo + "' and codigo_asiento='"+asientoContable.codigoAsiento+"' and codigo_cuenta='"+asientoContable.codigoCuenta+"'";
                utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarAsientoContable.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar lista
        public bool modificarAsientoContable(List<asiento_contable> lista)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                
                foreach (var x in lista)
                {
                    modificarAsientoContable(x);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarAsientoContable.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from asiento_contable";
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

        //obtener el codigo asiento
        public int getNextCodigoAsiento()
        {
            try
            {
                string sql = "select max(codigo_asiento)from asiento_contable";
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
                MessageBox.Show("Error getNextCodigoAsiento.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //get objeto by codigo asiento
        public asiento_contable getAsientoContableByIdAsiento(int id)
        {
            try
            {
                //codigo,codigo_asiento,fecha_sistema,fecha,monto,codigo_cuenta,debito,credito,activo
                asiento_contable asiento = new asiento_contable();
                string sql = sqlGeneral + " and codigo_asiento='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    asiento.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    asiento.codigoAsiento = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    asiento.fechaSistema = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                    asiento.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3]);
                    asiento.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][4]);
                    asiento.codigoCuenta = Convert.ToInt16(ds.Tables[0].Rows[0][5]);
                    asiento.debito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                    asiento.credito = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    asiento.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                }
                return asiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAsientoContableByIdAsiento.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<asiento_contable> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<asiento_contable> lista = new List<asiento_contable>();
                string sql = "";
                sql = sqlGeneral;
                if (mantenimiento == false)
                {
                    sql += " and activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        asiento_contable asiento = new asiento_contable();
                        asiento.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                        asiento.codigoAsiento = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                        asiento.fechaSistema = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                        asiento.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3]);
                        asiento.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][4]);
                        asiento.codigoCuenta = Convert.ToInt16(ds.Tables[0].Rows[0][5]);
                        asiento.debito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                        asiento.credito = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                        asiento.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                        lista.Add(asiento);
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

        //get lista completa by cuenta
        public List<asiento_contable> getListaByCuentaId(Int16 cuentaId)
        {
            try
            {

                List<asiento_contable> lista = new List<asiento_contable>();
                string sql = "";
                sql = sqlGeneral + " and codigo_cuenta='"+cuentaId+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        asiento_contable asiento = new asiento_contable();
                        asiento.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                        asiento.codigoAsiento = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                        asiento.fechaSistema = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                        asiento.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3]);
                        asiento.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][4]);
                        asiento.codigoCuenta = Convert.ToInt16(ds.Tables[0].Rows[0][5]);
                        asiento.debito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                        asiento.credito = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                        asiento.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                        lista.Add(asiento);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByCuentaId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa by cuenta hasta una fecha
        public List<asiento_contable> getListaByCuentaIdAndFechaFinal(Int16 cuentaId,DateTime fechaFinal)
        {
            try
            {

                List<asiento_contable> lista = new List<asiento_contable>();
                string sql = "";
                sql = sqlGeneral + " and codigo_cuenta='" + cuentaId + "' and fecha<=" + utilidades.getFechayyyyMMdd(fechaFinal);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        asiento_contable asiento = new asiento_contable();
                        asiento.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                        asiento.codigoAsiento = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                        asiento.fechaSistema = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                        asiento.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3]);
                        asiento.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][4]);
                        asiento.codigoCuenta = Convert.ToInt16(ds.Tables[0].Rows[0][5]);
                        asiento.debito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                        asiento.credito = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                        asiento.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                        lista.Add(asiento);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByCuentaIdAndFechaFinal.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa by cuenta y rango de fecha
        public List<asiento_contable> getListaByCuentaIdAndRangoFecha(Int16 cuentaId,DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                List<asiento_contable> lista = new List<asiento_contable>();
                string sql = "";
                sql = sqlGeneral + " and codigo_cuenta='" + cuentaId + "' and fecha>=" + utilidades.getFechayyyyMMdd(fechaInicial) + " and fecha<=" + utilidades.getFechayyyyMMdd(fechaFinal);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        asiento_contable asiento = new asiento_contable();
                        asiento.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                        asiento.codigoAsiento = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                        asiento.fechaSistema = Convert.ToDateTime(ds.Tables[0].Rows[0][2]);
                        asiento.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][3]);
                        asiento.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][4]);
                        asiento.codigoCuenta = Convert.ToInt16(ds.Tables[0].Rows[0][5]);
                        asiento.debito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                        asiento.credito = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                        asiento.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                        lista.Add(asiento);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByCuentaIdAndRangoFecha.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
       
    
    }
}
