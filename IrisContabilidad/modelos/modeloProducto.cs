using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;

namespace IrisContabilidad.modelos
{
    public class modeloProducto
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarProducto(producto producto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from producto where nombre='" + producto.nombre + "' and codigo!='" + producto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar referencia
                sql = "select *from producto where referencia='" + producto.nombre + "' and codigo!='" + producto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con esa referencia", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (producto.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into producto(codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima) values('" + producto.codigo + "','" + producto.nombre + "','" + producto.referencia + "','" + activo.ToString() + "','" + producto.referencia + "','" + producto.punto_maximo + "','" + producto.codigo_itebis + "','" + producto.codigo_categoria + "','" + producto.codigo_subcategoria + "','" + producto.codigo_almacen + "','" + producto.imagen + "','" + producto.codigo_unidad_minima + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarProducto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarProducto(producto producto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from producto where nombre='" + producto.nombre + "' and codigo!='" + producto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar referencia
                sql = "select *from producto where referencia='" + producto.nombre + "' and codigo!='" + producto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con esa referencia", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (producto.activo == true)
                {
                    activo = 1;
                }
                sql = "update producto set nombre='" + producto.nombre + "',referencia='" + producto.referencia + "',activo='" +activo.ToString()+ "',reorden='"+producto.reorden+"',punto_maximo='"+producto.punto_maximo+"',cod_itebis='"+producto.codigo_itebis+"',cod_categoria='"+producto.codigo_categoria+"',cod_subcategoria='"+producto.codigo_subcategoria+"',cod_almacen='"+producto.codigo_almacen+"',imagen='"+producto.imagen+"',cod_unidad_minima='"+producto.codigo_unidad_minima+"' where codigo='" + producto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarProducto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from producto";
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
        public producto getProductoById(int id)
        {
            try
            {
                producto producto = new producto();
                string sql = "select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima from producto where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    producto.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    producto.nombre = ds.Tables[0].Rows[0][1].ToString();
                    producto.referencia = ds.Tables[0].Rows[0][2].ToString();
                    producto.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    producto.reorden = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    producto.punto_maximo = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                    producto.codigo_itebis = Convert.ToInt16(ds.Tables[0].Rows[0][6].ToString());
                    producto.codigo_categoria = Convert.ToInt16(ds.Tables[0].Rows[0][7].ToString());
                    producto.codigo_subcategoria = Convert.ToInt16(ds.Tables[0].Rows[0][8].ToString());
                    producto.codigo_almacen = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    producto.imagen = ds.Tables[0].Rows[0][10].ToString();
                    producto.codigo_unidad_minima = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                }
                return producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getProductoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<producto> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<producto> lista = new List<producto>();
                string sql = "select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima from producto'";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        producto producto=new producto();
                        producto.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                        producto.nombre = ds.Tables[0].Rows[0][1].ToString();
                        producto.referencia = ds.Tables[0].Rows[0][2].ToString();
                        producto.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                        producto.reorden = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                        producto.punto_maximo = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                        producto.codigo_itebis = Convert.ToInt16(ds.Tables[0].Rows[0][6].ToString());
                        producto.codigo_categoria = Convert.ToInt16(ds.Tables[0].Rows[0][7].ToString());
                        producto.codigo_subcategoria = Convert.ToInt16(ds.Tables[0].Rows[0][8].ToString());
                        producto.codigo_almacen = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                        producto.imagen = ds.Tables[0].Rows[0][10].ToString();
                        producto.codigo_unidad_minima = Convert.ToInt16(ds.Tables[0].Rows[0][11].ToString());
                        lista.Add(producto);
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
