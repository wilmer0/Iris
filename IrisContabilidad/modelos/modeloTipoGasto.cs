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
    public class modeloTipoGasto
    {
        //objetos
        utilidades utilidades = new utilidades();
        private tipo_gasto tipoGasto;




        //agregar 
        public bool agregarTipoGasto(tipo_gasto tipoGasto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from tipo_gasto where nombre='" + tipoGasto.nombre + "' and id!='" + tipoGasto.id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de gasto con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (tipoGasto.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into tipo_gasto(id,nombre,activo) values('" + tipoGasto.id + "','" + tipoGasto.nombre + "','" + activo + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarTipoGasto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarTipoGasto(tipo_gasto tipoGasto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from tipo_gasto where nombre='" + tipoGasto.nombre + "' and id!='" + tipoGasto.id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de gasto con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (tipoGasto.activo == true)
                {
                    activo = 1;
                }

                sql = "update ciudad set nombre='" + tipoGasto.nombre + "',activo='" + activo + "' where codigo='" + tipoGasto.id + "'";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarTipoGasto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(id)from tipo_gasto";
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
        public tipo_gasto getTipoGastoById(int id)
        {
            try
            {
                string sql = "select id,nombre,activo from tipo_gasto where id='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                tipoGasto=new tipo_gasto();
                if (ds.Tables[0].Rows.Count>0)
                {
                    tipoGasto.id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    tipoGasto.nombre = ds.Tables[0].Rows[0][1].ToString();
                    tipoGasto.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                }
                return tipoGasto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoGastoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<tipo_gasto> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<tipo_gasto> lista = new List<tipo_gasto>();
                string sql = "";
                sql = "select id,nombre,activo from tipo_gasto";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        tipo_gasto tipoGasto = new tipo_gasto();
                        tipoGasto.id = Convert.ToInt16(row[0].ToString());
                        tipoGasto.nombre = row[1].ToString();
                        tipoGasto.activo = Convert.ToBoolean(row[2].ToString());
                        lista.Add(tipoGasto);
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
