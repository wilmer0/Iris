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
    public class modeloCaja
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCaja(caja caja)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from caja where nombre='" + caja.nombre + "' and codigo!='" + caja.codigo + "' and cod_sucursal='" + caja.codigo_sucursal + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una caja con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar secuencia
                sql = "select *from caja where secuencia='" + caja.secuencia + "' and codigo!='" + caja.codigo + "' and cod_sucursal='" + caja.codigo_sucursal + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una caja con esa secuencia", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }




                if (caja.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into caja(codigo,nombre,secuencia,cod_sucursal,activo) values('" + caja.codigo + "','" + caja.nombre + "','"+caja.secuencia+"','"+caja.codigo_sucursal + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCaja(caja caja)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from caja where nombre='" + caja.nombre + "' and codigo!='" + caja.codigo + "' and cod_sucursal='" + caja.codigo_sucursal + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una caja con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar secuencia
                sql = "select *from caja where secuencia='" + caja.secuencia + "' and codigo!='" + caja.codigo + "' and cod_sucursal='" + caja.codigo_sucursal + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una caja con esa secuencia", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



                if (caja.activo == true)
                {
                    activo = 1;
                }
                sql = "update caja set nombre='" + caja.nombre + "',secuencia='"+caja.secuencia+"',cod_sucursal='" + caja.codigo_sucursal + "',activo='" + activo.ToString() + "' where codigo='" + caja.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo) from caja";
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
        public caja getCajaById(int id)
        {
            try
            {
                caja caja = new caja();
                string sql = "select codigo,nombre,secuencia,cod_sucursal,activo from caja where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    caja.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    caja.nombre = ds.Tables[0].Rows[0][1].ToString();
                    caja.secuencia = ds.Tables[0].Rows[0][2].ToString();
                    caja.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    caja.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4].ToString());
                }
                return caja;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCajaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<caja> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<caja> lista = new List<caja>();
                string sql = "select codigo,nombre,secuencia,cod_sucursal,activo from caja";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        caja caja = new caja();
                        caja.codigo = Convert.ToInt16(row[0].ToString());
                        caja.nombre = row[1].ToString();
                        caja.secuencia = row[2].ToString();
                        caja.codigo_sucursal = Convert.ToInt16(row[3].ToString());
                        caja.activo = Convert.ToBoolean(row[4].ToString());
                        lista.Add(caja);
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
        //get lista completa por nombre
        public List<caja> getListaByNombre(string nombre)
        {
            try
            {

                List<caja> lista = new List<caja>();
                string sql = "";
                sql = "select codigo,nombre,secuencia,cod_sucursal,activo from caja where activo='1'";

                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        caja caja = new caja();
                        caja.codigo = Convert.ToInt16(row[0].ToString());
                        caja.nombre = row[1].ToString();
                        caja.secuencia = row[2].ToString();
                        caja.codigo_sucursal = Convert.ToInt16(row[3].ToString());
                        caja.activo = Convert.ToBoolean(row[4].ToString());
                        lista.Add(caja);
                    }
                }
                lista = lista.FindAll(x => x.nombre.ToLower().Contains(nombre.ToLower()));
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
