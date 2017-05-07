using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloAlmacen
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarAlmacen(almacen almacen)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from almacen where nombre='" + almacen.nombre + "' and codigo!='" + almacen.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un almacen con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }





                if (almacen.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into almacen(codigo,nombre,cod_sucursal,activo) values('" + almacen.codigo + "','" + almacen.nombre +"','"+almacen.codigo_sucursal+ "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarAlmacen.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarAlmacen(almacen almacen)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from almacen where nombre='" + almacen.nombre + "' and codigo!='" + almacen.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un almacen con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }



                if (almacen.activo == true)
                {
                    activo = 1;
                }
                sql = "update almacen set nombre='" + almacen.nombre + "',cod_sucursal='"+almacen.codigo_sucursal+"',activo='" + activo.ToString() + "' where codigo='" + almacen.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarAlmacen.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from almacen";
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
        public almacen getAlmacenById(int id)
        {
            try
            {
                almacen almacen = new almacen();
                string sql = "select codigo,nombre,cod_sucursal,activo from almacen where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    almacen.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    almacen.nombre = ds.Tables[0].Rows[0][1].ToString();
                    almacen.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][2]);
                    almacen.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                }
                return almacen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAlmacenById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<almacen> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<almacen> lista = new List<almacen>();
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
                        almacen almacen = new almacen();
                        almacen.codigo = Convert.ToInt16(row[0]);
                        almacen.nombre = row[1].ToString();
                        almacen.codigo_sucursal = Convert.ToInt16(row[2]);
                        almacen.activo = Convert.ToBoolean(row[3]);
                        lista.Add(almacen);
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
        public List<almacen> getListaByNombre(string nombre)
        {
            try
            {

                List<almacen> lista = new List<almacen>();
                string sql = "";
                sql = "select codigo,nombre,cod_sucursal,activo from almacen where activo='1'";

                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        almacen almacen = new almacen();
                        almacen.codigo = Convert.ToInt16(row[0]);
                        almacen.nombre = row[1].ToString();
                        almacen.codigo_sucursal = Convert.ToInt16(row[2]);
                        almacen.activo = Convert.ToBoolean(row[3]);
                        lista.Add(almacen);
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
        
        //get almacen by nombre
        public almacen getAlmacenByNombre(string nombre)
        {
            try
            {
                bool existe = false;
                List<almacen> lista = new List<almacen>();
                almacen almacen = new almacen();
                lista = getListaCompleta();
                lista.ForEach(x =>
                {
                    if (x.nombre.ToLower().Contains(nombre.ToLower()) && existe == false)
                    {
                        almacen.codigo = x.codigo;
                        almacen.nombre = x.nombre;
                        almacen.codigo_sucursal = x.codigo_sucursal;
                        almacen.activo = x.activo;
                        existe = true;
                    }
                });
                if (existe == true)
                {
                    return almacen;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAlmacenByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
