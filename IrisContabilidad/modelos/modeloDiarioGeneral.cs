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
    public class modeloDiarioGeneral
    {
        //objetos
        utilidades utilidades = new utilidades();


        //agregar 
        public bool agregarDiarioAsientoContable(diario_general diario)
        {
            try
            {
                int activo = 0;
                

                if (diario.activo == true)
                {
                    activo = 1;
                }

                string sql = "insert into diario_general(codigo,codigo_asiento,fecha_sistema,fecha,codigo_cuenta_contable,debito,credito,codigo_empleado,activo)values('" + diario.codigo + "','" + diario.codigoAsiento + "',"+utilidades.getFechayyyyMMddhhmmss(diario.fechaSistema)+","+utilidades.getFechayyyyMMdd(diario.fecha)+",'"+diario.codigoCuentaContable+"','"+diario.debito+"','"+diario.credito+"','"+diario.codigoEmpleado+"','"+activo+"');";
                //MessageBox.Show(sql);
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarDiarioAsientoContable.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarDiarioAsientocontable(diario_general diario)
        {
            try
            {
                int activo = 0;

                if (diario.activo == true)
                {
                    activo = 1;
                }
                string sql = "update diario_general fecha="+utilidades.getFechayyyyMMdd(diario.fecha)+",codigo_cuenta_contable='"+diario.codigoCuentaContable+"',debito='"+diario.debito+"',credito='"+diario.credito+"',codigo_empleado='"+diario.codigoEmpleado+"',activo='"+activo+"' where codigo='"+diario.codigo+"' and codigo_asiento='"+diario.codigoAsiento+"';";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarDiarioAsientocontable.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from diario_general";
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

        //obtener el codigo siguiente
        public int getNextAsiento()
        {
            try
            {
                string sql = "select max(codigo_asiento)from diario_general";
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
                MessageBox.Show("Error getNextAsiento.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //get lista de deario asiento contable objeto
        public List<diario_general> getListaDiarioAsientoContableById(int diarioId)
        {
            try
            {
                List<diario_general> listaDiarioGeneralAsientos=new List<diario_general>();
                string sql = "select codigo,codigo_asiento,fecha_sistema,fecha,codigo_cuenta_contable,debito,credito,codigo_empleado,activo from diario_general where activo='1' and codigo='" + diarioId + "';";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        diario_general diario = new diario_general();
                        diario.codigo = Convert.ToInt16(row[0]);
                        diario.codigoAsiento = Convert.ToInt16(row[1]);
                        diario.fechaSistema = Convert.ToDateTime(row[2]);
                        diario.fecha = Convert.ToDateTime(row[3]);
                        diario.codigoCuentaContable = Convert.ToInt16(row[4]);
                        diario.debito = Convert.ToDecimal(row[5]);
                        diario.credito = Convert.ToDecimal(row[6]);
                        diario.codigoEmpleado = Convert.ToInt16(row[7]);
                        diario.activo = Convert.ToBoolean(row[8]);
                        listaDiarioGeneralAsientos.Add(diario);
                    }
                }
                return listaDiarioGeneralAsientos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaDiarioAsientoContableById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<diario_general> getListaCompleta()
        {
            try
            {
                List<diario_general> listaDiarioGeneralAsientos = new List<diario_general>();
                string sql = "select codigo,codigo_asiento,fecha_sistema,fecha,codigo_cuenta_contable,debito,credito,codigo_empleado,activo from diario_general;";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        diario_general diario = new diario_general();
                        diario.codigo = Convert.ToInt16(row[0]);
                        diario.codigoAsiento = Convert.ToInt16(row[1]);
                        diario.fechaSistema = Convert.ToDateTime(row[2]);
                        diario.fecha = Convert.ToDateTime(row[3]);
                        diario.codigoCuentaContable = Convert.ToInt16(row[4]);
                        diario.debito = Convert.ToDecimal(row[5]);
                        diario.credito = Convert.ToDecimal(row[6]);
                        diario.codigoEmpleado = Convert.ToInt16(row[7]);
                        diario.activo = Convert.ToBoolean(row[8]);
                        listaDiarioGeneralAsientos.Add(diario);
                    }
                }
                return listaDiarioGeneralAsientos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaDiarioAsientoContableById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



    }
}
