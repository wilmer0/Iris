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
    public class modeloSubCategoriaProducto
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarSubCategoria(subCategoriaProducto subCategoria)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from subcategoria_producto where nombre='" + subCategoria.nombre + "' and cod_categoria='"+subCategoria.codigo_categoria+"' and codigo!='" + subCategoria.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una subCategoria con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (subCategoria.activo == true)
                {
                    activo = 1;
                }
                sql = "insert into subcategoria_producto(codigo,nombre,cod_categoria,activo) values('" + subCategoria.codigo + "','" + subCategoria.nombre +"','"+subCategoria.codigo_categoria.ToString()+ "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarSubCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarSubCategoria(subCategoriaProducto subCategoria)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from subcategoria_producto where nombre='" + subCategoria.nombre + "' and cod_categoria='" + subCategoria.codigo_categoria + "' and codigo!='" + subCategoria.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una subCategoria con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (subCategoria.activo == true)
                {
                    activo = 1;
                }
                sql = "update subcategoria_producto set nombre='" + subCategoria.nombre + "',cod_categoria='"+subCategoria.codigo_categoria.ToString()+"',activo='" + activo.ToString() + "' where codigo='" + subCategoria.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarSubCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from subcategoria_producto";
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
        public subCategoriaProducto getSubCategoriaById(int id)
        {
            try
            {
                subCategoriaProducto subcategoria = new subCategoriaProducto();
                string sql = "select codigo,nombre,cod_categoria,activo from subcategoria_producto where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    subcategoria.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    subcategoria.nombre = ds.Tables[0].Rows[0][1].ToString();
                    subcategoria.codigo_categoria = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    subcategoria.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                }
                return subcategoria;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSubCategoriaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<subCategoriaProducto> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<subCategoriaProducto> lista = new List<subCategoriaProducto>();
                string sql = "select codigo,nombre,cod_categoria,activo from subcategoria_producto ";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        subCategoriaProducto subcategoria = new subCategoriaProducto();
                        subcategoria.codigo = Convert.ToInt16(row[0].ToString());
                        subcategoria.nombre = row[1].ToString();
                        subcategoria.codigo_categoria = Convert.ToInt16(row[2].ToString());
                        subcategoria.activo = Convert.ToBoolean(row[3].ToString());
                        lista.Add(subcategoria);
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
