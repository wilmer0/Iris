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
    public class modeloItebis
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarItebis(itebis itebis)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from itebis where nombre='" + itebis.nombre + "' and codigo!='" + itebis.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un itbis con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (itebis.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into itebis(codigo,nombre,porciento,activo) values('" + itebis.codigo + "','" + itebis.nombre+"','"+itebis.porciento + "','" + activo + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarItebis.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //agregar lista ciudades
        public bool agregarItebis(List<itebis> lista)
        {
            try
            {
                lista.ForEach(itebisActual =>
                {
                    int activo = 0;
                    //validar nombre
                    itebisActual.codigo = getNext();
                    string sql = "select *from itebis where nombre='" + itebisActual.nombre + "' and codigo!='" + itebisActual.codigo + "'";
                    DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        if (itebisActual.activo == true)
                        {
                            activo = 1;
                        }
                        sql = "insert into itebis(codigo,nombre,porciento,activo) values('" + itebisActual.codigo + "','" + itebisActual.nombre+"','"+itebisActual.porciento + "','" + activo + "')";
                        ds = utilidades.ejecutarcomando_mysql(sql);
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarItebis.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarItebis(itebis itebis)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from itebis where nombre='" + itebis.nombre + "' and codigo!='" + itebis.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un itbis con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (itebis.activo == true)
                {
                    activo = 1;
                }


                sql = "update itebis set nombre='" + itebis.nombre + "',porciento='" + itebis.porciento + "',activo='" + activo + "' where codigo='" + itebis.codigo + "'";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarItebis.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from itebis";
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
        public itebis getItebisById(int id)
        {
            try
            {
                itebis itebis = new itebis();
                string sql = "select codigo,nombre,porciento,activo from itebis where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    itebis.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    itebis.nombre = ds.Tables[0].Rows[0][1].ToString();
                    itebis.porciento = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
                    itebis.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());

                }
                return itebis;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getItebisById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<itebis> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                itebis itebis;
                List<itebis> lista = new List<itebis>();
                string sql = "";
                sql = "select codigo,nombre,porciento,activo from itebis ";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        itebis = new itebis();
                        itebis.codigo = Convert.ToInt16(row[0].ToString());
                        itebis.nombre = row[1].ToString();
                        itebis.porciento = Convert.ToDecimal(row[2].ToString());
                        itebis.activo = Convert.ToBoolean(row[3].ToString());

                        lista.Add(itebis);
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
