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
    public class modeloCuadreCaja
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCuadreCaja(cuadre_caja cuadreCaja)
        {
            try
            {
                int activo = 0;
                int cajaCuadrada = 0;
                //validar que tenga una apertura de caja activa
                string sql = "select *from cuadre_caja where cod_cajero='" + cuadreCaja.codigo_cajero + "' and activo='1' and cod_caja='" + cuadreCaja.codigo_caja + "' and caja_cuadrada='0'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("No tiene apertura de caja activa", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cuadreCaja.activo == true)
                {
                    activo = 1;
                }
                if(cuadreCaja.caja_cuadrada==true)
                {
                    cajaCuadrada = 1;
                }

                sql = "insert into cuadre_caja(codigo,cod_cajero,fecha,turno,activo,cod_sucursal,cod_caja,efectivo_inicial,caja_cuadrada)values('" + cuadreCaja.codigo + "','" + cuadreCaja.codigo_cajero + "'," + utilidades.getFechayyyyMMdd(cuadreCaja.fecha) + ",'" + cuadreCaja.turno + "','" + activo + "','" + cuadreCaja.codigo_sucursal + "','" + cuadreCaja.codigo_caja + "','" + cuadreCaja.efectivo_inicial + "','"+cajaCuadrada+"')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCuadreCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from cuadra_caja";
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
        //obtener el codigo siguiente turno
        public int getNextTurno()
        {
            try
            {
                int turno = 0;
                singleton singleton = new singleton();


                string sql = "select max(turno) from cuadre_caja";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows[0][0].ToString() == null || ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    turno = 1;
                    return turno;
                }
                


                
                sql = "select max(fecha) from cuadre_caja where activo='1' and cod_sucursal='" + singleton.getEmpleado().codigo_sucursal + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //validar que el resultado se pueda convertir en fecha
                DateTime fecha;
                DateTime fechaHoy=DateTime.Today;
                string temp = "";
                    
                if (DateTime.TryParse(ds.Tables[0].Rows[0][0].ToString(), out fecha) == true)
                {
                    DateTime FechaUltimoCuadre = Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString());
                    
                    temp = fechaHoy.ToString("yyyy/MM/dd");
                    fechaHoy = Convert.ToDateTime(temp);

                    temp = FechaUltimoCuadre.ToString("yyyy/MM/dd");
                    FechaUltimoCuadre = Convert.ToDateTime(temp);
                    
                    //si las fechas es igual a la de hoy entonces se asigna el turno siguiente
                    if (Convert.ToDateTime(fechaHoy) == Convert.ToDateTime(FechaUltimoCuadre))
                    {
                        sql = "select max(turno) from cuadre_caja where activo='1' and cod_sucursal='" +singleton.getEmpleado().codigo_sucursal + "'";
                        ds = utilidades.ejecutarcomando_mysql(sql);
                        if (ds.Tables[0].Rows[0][0].ToString() == null || ds.Tables[0].Rows[0][0].ToString() == "")
                        {
                            turno = 0;
                        }
                        else
                        {
                            turno = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                        }
                        turno += 1;
                    }
                    else if (fechaHoy.Date>FechaUltimoCuadre.Date)
                    {
                        
                        //la fecha de hoy es mayor que la del ultimo cuadre de caja 
                        //entonces el dia es nuevo y el tuno es el primero del dia
                        turno = 1;
                    }
                }
                return turno;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNextTurno.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //get objeto
        public cuadre_caja getCuadreCajaById(int id)
        {
            try
            {
                cuadre_caja cuadreCaja = new cuadre_caja();
                string sql = "select codigo,cod_cajero,fecha,turno,activo,cod_sucursal,cod_caja,efectivo_inicial,caja_cuadrada from cuadre_caja where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cuadreCaja.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    cuadreCaja.codigo_cajero = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    cuadreCaja.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2].ToString());
                    cuadreCaja.turno = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    cuadreCaja.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    cuadreCaja.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][5].ToString());
                    cuadreCaja.codigo_caja = Convert.ToInt16(ds.Tables[0].Rows[0][6].ToString());
                    cuadreCaja.efectivo_inicial = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString());
                    cuadreCaja.caja_cuadrada = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                }
                return cuadreCaja;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCuadreCajaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista Lista Cuadre Caja Detalle By Cuadre Caja Id
        public List<cuadre_caja_detalle> getListaCuadreCajaDetalleByCuadreCajaId(int id)
        {
            try
            {
                List<cuadre_caja_detalle> lista = new List<cuadre_caja_detalle>();
                string sql = "";
                sql = "select codigo_cuadre,monto_efectivo,monto_tarjeta,monto_cheque,monto_deposito,monto_egreso,monto_ingreso,monto_sobrante,monto_faltante from cuadre_caja_detalles where codigo_cuadre='"+id+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cuadre_caja_detalle cuadreCajaDetalle = new cuadre_caja_detalle();
                        cuadreCajaDetalle.codigo_cuadre_caja = Convert.ToInt16(row[0].ToString());
                        cuadreCajaDetalle.monto_efectivo = Convert.ToDecimal(row[1].ToString());
                        cuadreCajaDetalle.monto_tarjeta = Convert.ToDecimal(row[2].ToString());
                        cuadreCajaDetalle.monto_cheque = Convert.ToDecimal(row[3].ToString());
                        cuadreCajaDetalle.monto_deposito = Convert.ToDecimal(row[4].ToString());
                        cuadreCajaDetalle.monto_egreso = Convert.ToDecimal(row[5].ToString());
                        cuadreCajaDetalle.monto_ingreso = Convert.ToDecimal(row[6].ToString());
                        cuadreCajaDetalle.monto_sobrante = Convert.ToDecimal(row[7].ToString());
                        cuadreCajaDetalle.monto_faltante = Convert.ToDecimal(row[8].ToString());
                        lista.Add(cuadreCajaDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCuadreCajaDetalleByCuadreCajaId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa por nombre
        public List<cuadre_caja_detalle> getListaCompleta()
        {
            try
            {
                List<cuadre_caja_detalle> lista = new List<cuadre_caja_detalle>();
                string sql = "";
                sql = "select codigo_cuadre,monto_efectivo,monto_tarjeta,monto_cheque,monto_deposito,monto_egreso,monto_ingreso,monto_sobrante,monto_faltante from cuadre_caja_detalles";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cuadre_caja_detalle cuadreCajaDetalle = new cuadre_caja_detalle();
                        cuadreCajaDetalle.codigo_cuadre_caja = Convert.ToInt16(row[0].ToString());
                        cuadreCajaDetalle.monto_efectivo = Convert.ToDecimal(row[1].ToString());
                        cuadreCajaDetalle.monto_tarjeta = Convert.ToDecimal(row[2].ToString());
                        cuadreCajaDetalle.monto_cheque = Convert.ToDecimal(row[3].ToString());
                        cuadreCajaDetalle.monto_deposito = Convert.ToDecimal(row[4].ToString());
                        cuadreCajaDetalle.monto_egreso = Convert.ToDecimal(row[5].ToString());
                        cuadreCajaDetalle.monto_ingreso = Convert.ToDecimal(row[6].ToString());
                        cuadreCajaDetalle.monto_sobrante = Convert.ToDecimal(row[7].ToString());
                        cuadreCajaDetalle.monto_faltante = Convert.ToDecimal(row[8].ToString());
                        lista.Add(cuadreCajaDetalle);
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
    }
}
