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
    public class modeloDepartamento
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarDepartamento(departamento departamento)
        {
            try
            {
             
                int activo = 0;
                string sql = "select *from departamento where nombre='" + departamento.nombre + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un departamento con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (departamento.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into departamento(codigo,codigo_sucursal,nombre,activo) values('" + departamento.codigo+"','"+departamento.codigo_sucursal + "','" + departamento.nombre + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarDepartamento.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarDepartamento(departamento departamento)
        {
            try
            {
                int activo = 0;
                string sql = "select *from departamento where nombre='" + departamento.nombre + "' and codigo!='" + departamento.codigo + "' and codigo_sucursal!='"+departamento.codigo_sucursal+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un departamento con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                if (departamento.activo == true)
                {
                    activo = 1;
                }
                sql = "update departamento set nombre='" + departamento.nombre + "', codigo_sucursal='"+departamento.codigo_sucursal+"', activo='" + activo.ToString() + "' where codigo='" + departamento.codigo + "'";
                ds = utilidades.ejecutarcomando_sql(sql);
                MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarDepartamento.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from departamento";
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
        public departamento getDepartamentoById(int id)
        {
            try
            {
                departamento departamento = new departamento();
                string sql = "select codigo,nombre,codigo_sucursal,activo from departamento where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    departamento.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    departamento.nombre = ds.Tables[0].Rows[0][1].ToString();
                    departamento.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    departamento.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                }
                return departamento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getDepartamentoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<departamento> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<departamento> lista = new List<departamento>();
                string sql = "";
                sql = "select codigo,nombre,codigo_sucursal,activo from departamento";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        departamento departamento = new departamento();
                        departamento.codigo = Convert.ToInt16(row[0].ToString());
                        departamento.nombre = row[1].ToString();
                        departamento.codigo_sucursal = Convert.ToInt16(row[2].ToString());
                        departamento.activo = Convert.ToBoolean(row[3].ToString());
                        lista.Add(departamento);
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
