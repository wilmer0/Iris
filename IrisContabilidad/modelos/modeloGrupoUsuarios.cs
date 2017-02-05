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
    public class modeloGrupoUsuarios
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarGrupoUsuario(grupo_usuarios grupoUsuario)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from grupo_usuarios where nombre='" + grupoUsuario.nombre + "' and codigo!='"+grupoUsuario.codigo+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un grupo de usuarios con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (grupoUsuario.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into grupo_usuarios(codigo,nombre,detalles,activo) values('" + grupoUsuario.codigo + "','" + grupoUsuario.nombre + "','"+grupoUsuario.detalles+"','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarGrupoUsuario.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarGrupoUsuario(grupo_usuarios grupoUsuario)
        {
            try
            {
                int activo = 0;
                //validaciones
                string sql = "select *from grupo_usuarios where nombre='" + grupoUsuario.nombre + "' and codigo!='" + grupoUsuario.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un grupo de usuarios con ese nombre", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
                if (grupoUsuario.activo == true)
                {
                    activo = 1;
                }
                sql = "update grupo_usuarios set nombre='" + grupoUsuario.nombre + "',detalles='"+grupoUsuario.detalles+"',activo='" + activo.ToString() + "' where codigo='" + grupoUsuario.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarGrupoUsuario.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from grupo_usuarios";
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
        public grupo_usuarios getGrupoUsuarioById(int id)
        {
            try
            {
                grupo_usuarios grupuUsuario = new grupo_usuarios();
                string sql = "select codigo,nombre,detalles,activo from grupo_usuarios where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grupuUsuario.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    grupuUsuario.nombre = ds.Tables[0].Rows[0][1].ToString();
                    grupuUsuario.detalles = ds.Tables[0].Rows[0][2].ToString();
                    grupuUsuario.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                }
                return grupuUsuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getGrupoUsuarioById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<grupo_usuarios> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<grupo_usuarios> lista = new List<grupo_usuarios>();
                string sql = "";
                sql = "select codigo,nombre,detalles,activo from grupo_usuarios";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        grupo_usuarios grupoUsuarios = new grupo_usuarios();
                        grupoUsuarios.codigo = Convert.ToInt16(row[0].ToString());
                        grupoUsuarios.nombre = row[1].ToString();
                        grupoUsuarios.detalles = row[2].ToString();
                        grupoUsuarios.activo = Convert.ToBoolean(row[3]);
                        lista.Add(grupoUsuarios);
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
