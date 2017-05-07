using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloIngresoCaja
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarIngreso(ingreso_caja ingreso)
        {
            try
            {
                int activo = 0;
                int afectaCuadre = 0;
                int cuadrado = 0;
                int modificable = 0;
                //validar nombre
                string sql = "";
                DataSet ds;

                if (ingreso.activo == true)
                {
                    activo = 1;
                }
                if (ingreso.afecta_cuadre == true)
                {
                    afectaCuadre = 1;
                }
                if (ingreso.cuadrado == true)
                {
                    cuadrado = 1;
                }
                if (ingreso.modificable == true)
                {
                    modificable = 1;
                }

                sql = "insert into ingresos_caja(codigo,cod_concepto,fecha,cod_cajero,monto,detalles,afecta_cuadre,activo,cuadrado,modificable) values('" + ingreso.codigo + "','" + ingreso.codigo_concepto + "'," + utilidades.getFechayyyyMMdd(ingreso.fecha) + ",'" + ingreso.codigo_cajero + "','" + ingreso.monto + "','" + ingreso.detalle + "','1','" + activo + "','" + cuadrado + "','" + modificable + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarIngreso.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarIngreso(ingreso_caja ingreso)
        {
            try
            {
                int activo = 0;
                int afectaCuadre = 0;
                int cuadrado = 0;
                int modificable = 0;
                //validar nombre
                string sql = "";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);


                if (ingreso.activo == true)
                {
                    activo = 1;
                }
                if (ingreso.afecta_cuadre == true)
                {
                    afectaCuadre = 1;
                }
                if (ingreso.cuadrado == true)
                {
                    cuadrado = 1;
                }
                if (ingreso.modificable == false)
                {
                    modificable = 0;
                    MessageBox.Show("Error no se puede modificar este ingreso de caja ya que fue hecho por el sistema","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                sql = "update ingresos_caja set cod_concepto='" + ingreso.codigo_concepto + "',fecha=" + utilidades.getFechayyyyMMdd(ingreso.fecha) + ",cod_cajero='" + ingreso.codigo_cajero + "',monto='" + ingreso.monto + "',detalles='" + ingreso.detalle + "',afecta_cuadre='1',activo='" + activo + "',cuadrado='" + cuadrado + "' where codigo='" + ingreso.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarIngreso.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from ingresos_caja";
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
        public ingreso_caja getIngresoCajaById(int id)
        {
            try
            {
                ingreso_caja ingreso = new ingreso_caja();
                string sql = "select codigo,cod_concepto,fecha,cod_Cajero,monto,detalles,afecta_cuadre,activo,cuadrado from ingresos_caja where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ingreso.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    ingreso.codigo_concepto = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    ingreso.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2].ToString());
                    ingreso.codigo_cajero = Convert.ToInt16(ds.Tables[0].Rows[0][3]);
                    ingreso.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    ingreso.detalle = ds.Tables[0].Rows[0][5].ToString();
                    ingreso.afecta_cuadre = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                    ingreso.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    ingreso.cuadrado = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                }
                return ingreso;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getIngresoCajaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<ingreso_caja> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<ingreso_caja> lista = new List<ingreso_caja>();
                string sql = "select codigo,cod_concepto,fecha,cod_Cajero,monto,detalles,afecta_cuadre,activo,cuadrado from ingresos_caja ";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ingreso_caja ingreso = new ingreso_caja();
                        ingreso.codigo = Convert.ToInt16(row[0]);
                        ingreso.codigo_concepto = Convert.ToInt16(row[1]);
                        ingreso.fecha = Convert.ToDateTime(row[2]);
                        ingreso.codigo_cajero = Convert.ToInt16(row[3]);
                        ingreso.monto = Convert.ToDecimal(row[4].ToString());
                        ingreso.detalle = row[5].ToString();
                        ingreso.afecta_cuadre = Convert.ToBoolean(row[6]);
                        ingreso.activo = Convert.ToBoolean(row[7]);
                        ingreso.cuadrado = Convert.ToBoolean(row[8]);
                        lista.Add(ingreso);
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

        //get lista completa no cuadrada by cuadre caja
        public List<ingreso_caja> getListaIngresosCajaNoCuadradaCompletaByCuadreCaja(cuadre_caja cuadre)
        {
            try
            {
                empleado empleado = new modeloEmpleado().getEmpleadoByCajeroId(cuadre.codigo_cajero);
                if (empleado == null)
                {
                    MessageBox.Show("Error el empleado esta nulo en base al cajero  getListaNoCuadradaCompletaByCuadreCaja .:");
                    return null;
                }
                List<ingreso_caja> lista = new List<ingreso_caja>();
                string sql = "select codigo,cod_concepto,fecha,cod_Cajero,monto,detalles,afecta_cuadre,activo,cuadrado from ingresos_caja where cuadrado='0' and activo='1' and fecha>='" + utilidades.getFechayyyyMMdd(cuadre.fecha) + "' and fecha<='" + utilidades.getFechayyyyMMdd(cuadre.fecha_cierre_cuadre) + "' and cod_cajero='"+cuadre.codigo_cajero+"' and afecta_cuadre='1' ";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ingreso_caja ingreso = new ingreso_caja();
                        ingreso.codigo = Convert.ToInt16(row[0]);
                        ingreso.codigo_concepto = Convert.ToInt16(row[1]);
                        ingreso.fecha = Convert.ToDateTime(row[2]);
                        ingreso.codigo_cajero = Convert.ToInt16(row[3]);
                        ingreso.monto = Convert.ToDecimal(row[4].ToString());
                        ingreso.detalle = row[5].ToString();
                        ingreso.afecta_cuadre = Convert.ToBoolean(row[6]);
                        ingreso.activo = Convert.ToBoolean(row[7]);
                        ingreso.cuadrado = Convert.ToBoolean(row[8]);
                        lista.Add(ingreso);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaIngresosCajaNoCuadradaCompletaByCuadreCaja.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        
    
    }
}
