using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloEgresoCaja
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarEgreso(egreso_caja egreso)
        {
            try
            {
                int activo = 0;
                int afectaCuadre = 0;
                int cuadrado = 0;
                //validar nombre
                string sql = "";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("Existe un almacen con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}





                if (egreso.activo == true)
                {
                    activo = 1;
                }
                if (egreso.afecta_cuadre == true)
                {
                    afectaCuadre = 1;
                }
                if (egreso.cuadrado == true)
                {
                    cuadrado = 1;
                }

                sql = "insert into egresos_caja(codigo,cod_concepto,fecha,cod_cajero,monto,detalles,afecta_cuadre,activo,cuadrado) values('"+egreso.codigo+"','"+egreso.codigo_concepto+"','"+egreso.fecha.ToString("dd-MM-yyyy")+"','"+egreso.codigo_cajero+"','"+egreso.monto+"','"+egreso.detalle+"','1','"+activo+"','"+cuadrado+"')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarEgreso.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarEgreso(egreso_caja egreso)
        {
            try
            {
                int activo = 0;
                int afectaCuadre = 0;
                int cuadrado = 0;
                //validar nombre
                string sql = "";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("Existe un almacen con ese nombre", "", MessageBoxButtons.OK,
                //        MessageBoxIcon.Warning);
                //    return false;
                //}



                if (egreso.activo == true)
                {
                    activo = 1;
                }
                if (egreso.afecta_cuadre == true)
                {
                    afectaCuadre = 1;
                }
                if (egreso.cuadrado == true)
                {
                    cuadrado = 1;
                }

                sql = "update egresos_caja set cod_concepto='" + egreso.codigo_concepto + "',fecha='" + egreso.fecha.ToString("dd-MM-yyyy") + "',cod_cajero='" + egreso.codigo_cajero + "',monto='" + egreso.monto + "',detalles='" + egreso.detalle + "',afecta_cuadre='1',activo='" + activo + "',cuadrado='" + cuadrado + "' where codigo='" + egreso.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarEgreso.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from egresos_caja";
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
        public egreso_caja getEgresoCajaById(int id)
        {
            try
            {
                egreso_caja egreso = new egreso_caja();
                string sql = "select codigo,cod_concepto,fecha,cod_Cajero,monto,detalles,afecta_cuadre,activo,cuadrado from egresos_caja where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    egreso.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    egreso.codigo_concepto = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    egreso.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][2].ToString());
                    egreso.codigo_cajero = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    egreso.monto = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    egreso.detalle =ds.Tables[0].Rows[0][5].ToString();
                    egreso.afecta_cuadre = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());
                    egreso.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][7].ToString());
                    egreso.cuadrado = Convert.ToBoolean(ds.Tables[0].Rows[0][8].ToString());
                }
                return egreso;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEgresoCajaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<egreso_caja> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<egreso_caja> lista = new List<egreso_caja>();
                string sql = "";
                sql = "select codigo,nombre,cod_sucursal,activo from almacen";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        egreso_caja egreso = new egreso_caja();
                        egreso.codigo = Convert.ToInt16(row[0].ToString());
                        egreso.codigo_concepto = Convert.ToInt16(row[1].ToString());
                        egreso.fecha = Convert.ToDateTime(row[2].ToString());
                        egreso.codigo_cajero = Convert.ToInt16(row[3].ToString());
                        egreso.monto = Convert.ToDecimal(row[4].ToString());
                        egreso.detalle = row[5].ToString();
                        egreso.afecta_cuadre = Convert.ToBoolean(row[6].ToString());
                        egreso.activo = Convert.ToBoolean(row[7].ToString());
                        egreso.cuadrado = Convert.ToBoolean(row[8].ToString());
                        lista.Add(egreso);
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
