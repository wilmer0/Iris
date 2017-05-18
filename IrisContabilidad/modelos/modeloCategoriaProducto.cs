using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloCategoriaProducto
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCategoria(categoria_producto categoria)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from categoria_producto where nombre='" + categoria.nombre + "' and codigo!='" + categoria.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una categoria con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (categoria.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into categoria_producto(codigo,nombre,activo) values('" + categoria.codigo + "','" + categoria.nombre + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCategoria(categoria_producto categoria)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from categoria_producto where nombre='" + categoria.nombre + "' and codigo!='" + categoria.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una categoria con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                if (categoria.activo == true)
                {
                    activo = 1;
                }
                sql = "update categoria_producto set nombre='" + categoria.nombre + "',activo='" + activo.ToString() + "' where codigo='" + categoria.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from categoria_producto";
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
        public categoria_producto getCategoriaById(int id)
        {
            try
            {
                categoria_producto categoria = new categoria_producto();
                string sql = "select codigo,nombre,activo from categoria_producto where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    categoria.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    categoria.nombre = ds.Tables[0].Rows[0][1].ToString();
                    categoria.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                }
                return categoria;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCategoriaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        //get lista completa
        public List<categoria_producto> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<categoria_producto> lista = new List<categoria_producto>();
                string sql = "";
                sql = "select codigo,nombre,activo from categoria_producto";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        categoria_producto categoria = new categoria_producto();
                        categoria.codigo = Convert.ToInt16(row[0].ToString());
                        categoria.nombre = row[1].ToString();
                        categoria.activo = Convert.ToBoolean(row[2].ToString());
                        lista.Add(categoria);
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
        public List<categoria_producto> getListaByNombre(string nombre)
        {
            try
            {

                List<categoria_producto> lista = new List<categoria_producto>();
                string sql = "";
                sql = "select codigo,nombre,activo from categoria_producto where activo='1'";
                
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        categoria_producto categoria = new categoria_producto();
                        categoria.codigo = Convert.ToInt16(row[0].ToString());
                        categoria.nombre = row[1].ToString();
                        categoria.activo = Convert.ToBoolean(row[2].ToString());
                        lista.Add(categoria);
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
        
        //get categoria completa por nombre
        public categoria_producto getCategoriaByNombre(string nombre)
        {
            try
            {
                bool existe = false;
                List<categoria_producto> lista=new List<categoria_producto>();
                categoria_producto categoria = new categoria_producto();
                lista = getListaCompleta();
                lista.ForEach(x =>
                {
                    if (x.nombre.ToLower().Contains(nombre.ToLower()) && existe==false)
                    {
                        categoria.codigo = x.codigo;
                        categoria.nombre = x.nombre;
                        categoria.activo = x.activo;
                        existe = true;
                    }
                });
                if (existe == true)
                {
                    return categoria;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCategoriaByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
