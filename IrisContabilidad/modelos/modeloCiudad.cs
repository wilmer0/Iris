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
    public class modeloCiudad
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCiudad(ciudad ciudad)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from ciudad where nombre='" + ciudad.nombre + "' and codigo!='" + ciudad.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una ciudad con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (ciudad.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into ciudad(codigo,nombre,activo) values('" + ciudad.codigo + "','" + ciudad.nombre + "','" + activo + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCiudad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //agregar lista ciudades
        public bool agregarCiudad(List<ciudad> lista)
        {
            try
            {
                lista.ForEach(ciudadActual=>
                {
                    int activo = 0;
                    //validar nombre
                    ciudadActual.codigo = getNext();
                    string sql = "select *from ciudad where nombre='" + ciudadActual.nombre + "' and codigo!='" + ciudadActual.codigo + "'";
                    DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        if (ciudadActual.activo == true)
                        {
                            activo = 1;
                        }
                        sql = "insert into ciudad(codigo,nombre,activo) values('" + ciudadActual.codigo + "','" + ciudadActual.nombre + "','" + activo + "')";
                        ds = utilidades.ejecutarcomando_mysql(sql);
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCiudad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCiudad(ciudad ciudad)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from ciudad where nombre='" + ciudad.nombre + "' and codigo!='" + ciudad.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una ciudad con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (ciudad.activo == true)
                {
                    activo = 1;
                }

                sql = "update ciudad set nombre='" + ciudad.nombre + "',activo='" + activo + "' where codigo='" + ciudad.codigo + "'";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCiudad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from ciudad";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //int id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                int id = 0;
                if (ds.Tables[0].Rows[0][0].ToString()==null || ds.Tables[0].Rows[0][0].ToString()=="")
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
        public ciudad getCiudadById(int id)
        {
            try
            {
                ciudad ciudad = new ciudad();
                string sql = "select codigo,nombre,activo from ciudad where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ciudad.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    ciudad.nombre = ds.Tables[0].Rows[0][1].ToString();
                    ciudad.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                   
                }
                return ciudad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCiudadById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<ciudad> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                ciudad ciudad;
                List<ciudad> lista = new List<ciudad>();
                string sql = "";
                sql = "select codigo,nombre,activo from ciudad ";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ciudad=new ciudad();
                        ciudad.codigo = Convert.ToInt16(row[0].ToString());
                        ciudad.nombre = row[1].ToString();
                        ciudad.activo = Convert.ToBoolean(row[2].ToString());

                        lista.Add(ciudad);
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
