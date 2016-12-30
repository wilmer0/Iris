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
    public class modeloNominaTipo
    {
        //objetos
        utilidades utilidades = new utilidades();

        //agregar
        public bool agregarNominaTipo(nomina_tipo tipo)
        {
            try
            {
                int activo = 0;
                string sql = "select *from nomina_tipos where nombre='" + tipo.nombre + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de nomina con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (tipo.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into nomina_tipos(codigo,nombre,activo) values('" + tipo.codigo + "','" + tipo.nombre + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarNominaTipo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarNominaTipo(nomina_tipo tipo)
        {
            try
            {
                int activo = 0;
                string sql = "select *from nomina_tipos where nombre='" + tipo.nombre + "' and id!='" + tipo.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de nomina con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                if (tipo.activo == true)
                {
                    activo = 1;
                }
                sql = "update nomina_tipos set nombre='" + tipo.nombre + "',activo='" + activo.ToString() + "' where codigo='" + tipo.codigo + "'";
                ds = utilidades.ejecutarcomando(sql);
                MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarNominaTipo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(id)from nomina_tipos";
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
        public nomina_tipo getNominaTipoById(int id)
        {
            try
            {
                nomina_tipo tipo = new nomina_tipo();
                string sql = "select codigo,nombre,activo from nomina_tipos where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipo.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    tipo.nombre = ds.Tables[0].Rows[0][1].ToString();
                    tipo.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                }
                return tipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNominaTipoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<nomina_tipo> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<nomina_tipo> lista = new List<nomina_tipo>();
                string sql = "";
                sql = "select codigo,nombre,activo from nomina_tipos";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        nomina_tipo tipo = new nomina_tipo();
                        tipo.codigo = Convert.ToInt16(row[0].ToString());
                        tipo.nombre = row[1].ToString();
                        tipo.activo = Convert.ToBoolean(row[2].ToString());
                        lista.Add(tipo);
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
