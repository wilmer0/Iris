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
    public class modeloSituacionEmpleado
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar
        public bool agregarSituacionEmpleado(situacion_empleado situacion)
        {
            try
            {
                int activo = 0;
                string sql = "select *from situacion_empleado where descripcion='" + situacion.descripcion + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una situación con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (situacion.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into situacion_empleado(codigo,descripcion,activo) values('" + situacion.codigo + "','" + situacion.descripcion + "','" + activo.ToString() + "')";
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarSituacionEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarSituacionEmpleado(situacion_empleado situacion)
        {
            try
            {
                int activo = 0;
                string sql = "select *from situacion_empleado where descripcion='" + situacion.descripcion + "' and codigo!='" + situacion.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una situación con ese nombre", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
                if (situacion.activo == true)
                {
                    activo = 1;
                }
                sql = "update situacion_empleado set descripcion='" + situacion.descripcion + "',activo='" + activo.ToString() + "' where codigo='" + situacion.codigo + "'";
                ds = utilidades.ejecutarcomando_sql(sql);
                MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarSituacionEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(id)from situacion_empleado";
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


        //get by id
        public situacion_empleado getSituacionEmpleadoById(int id)
        {
            try
            {
                situacion_empleado situacion = new situacion_empleado();
                string sql = "select codigo,descripcion,activo from situacion_empleado where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    situacion.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    situacion.descripcion = ds.Tables[0].Rows[0][1].ToString();
                    situacion.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                }
                return situacion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSituacionEmpleadoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<situacion_empleado> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<situacion_empleado> lista = new List<situacion_empleado>();
                string sql = "";
                sql = "select codigo,descripcion,activo from situacion_empleado ";
                if (mantenimiento == true)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        situacion_empleado situacion=new situacion_empleado();
                        situacion.codigo = Convert.ToInt16(row[0].ToString());
                        situacion.descripcion = row[1].ToString();
                        situacion.activo = Convert.ToBoolean(row[2].ToString());
                        lista.Add(situacion);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
