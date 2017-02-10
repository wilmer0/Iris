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
    public class modeloUnidad
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarUnidad(unidad unidad)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from unidad where nombre='" + unidad.nombre + "' and codigo!='" + unidad.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una unidad con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre abreviado
                sql = "select *from unidad where unidad_abreviada='" + unidad.unidad_abreviada + "' and codigo!='" + unidad.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una unidad con ese nombre abreviado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                if (unidad.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into unidad(codigo,nombre,unidad_abreviada,activo) values('" + unidad.codigo + "','" + unidad.nombre +"','"+unidad.unidad_abreviada+ "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarUnidad(unidad unidad)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from unidad where nombre='" + unidad.nombre + "' and codigo!='" + unidad.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una unidad con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre abreviado
                sql = "select *from unidad where unidad_abreviada='" + unidad.unidad_abreviada + "' and codigo!='" + unidad.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una unidad con ese nombre abreviado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (unidad.activo == true)
                {
                    activo = 1;
                }
                sql = "update unidad set nombre='" + unidad.nombre + "',unidad_abreviada='"+unidad.unidad_abreviada+"',activo='" + activo.ToString() + "' where codigo='" + unidad.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from unidad";
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
        public unidad getUnidadById(int id)
        {
            try
            {
                unidad unidad = new unidad();
                string sql = "select codigo,nombre,unidad_abreviada,activo from unidad where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    unidad.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    unidad.nombre = ds.Tables[0].Rows[0][1].ToString();
                    unidad.unidad_abreviada = ds.Tables[0].Rows[0][2].ToString();
                    unidad.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                }
                return unidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getUnidadById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<unidad> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<unidad> lista = new List<unidad>();
                string sql = "";
                sql = "select codigo,nombre,unidad_abreviada,activo from unidad";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        unidad unidad = new unidad();
                        unidad.codigo = Convert.ToInt16(row[0].ToString());
                        unidad.nombre = row[1].ToString();
                        unidad.unidad_abreviada = row[2].ToString();
                        unidad.activo = Convert.ToBoolean(row[3].ToString());
                        lista.Add(unidad);
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
        //get lista unidad por producto
        public List<unidad> getListaByProducto(int id)
        {
            try
            {

                List<unidad> lista = new List<unidad>();
                string sql = "";
                sql = "select u.codigo,u.nombre,u.unidad_abreviada,u.activo from producto_unidad_conversion p join unidad u on p.cod_unidad=u.codigo where cod_producto='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        unidad unidad = new unidad();
                        unidad.codigo = Convert.ToInt16(row[0].ToString());
                        unidad.nombre = row[1].ToString();
                        unidad.unidad_abreviada = row[2].ToString();
                        unidad.activo = Convert.ToBoolean(row[3].ToString());
                        lista.Add(unidad);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByProducto.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista unidad by producto
        public List<unidad> getListaCompletaByProductoId(int id)
        {
            try
            {
                List<unidad> lista = new List<unidad>();
                string sql = "";
                sql = "select cod_unidad from producto_unidad_conversion where cod_producto='"+id+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        unidad unidad = new unidad();
                        unidad = getUnidadById(Convert.ToInt16(row[0].ToString()));
                        lista.Add(unidad);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaByProductoId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
