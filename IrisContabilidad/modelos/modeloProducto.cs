using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System.IO;

namespace IrisContabilidad.modelos
{
    public class modeloProducto
    {
        //objetos
        private utilidades utilidades = new utilidades();
        private producto producto;

        //variables
        private string rutaImagenesProductos = Directory.GetCurrentDirectory().ToString() + @"\Resources\productos\";



        //agregar 
        public bool agregarProducto(producto producto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from producto where nombre='" + producto.nombre + "' and codigo!='" +
                             producto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                //validar referencia
                sql = "select *from producto where referencia='" + producto.referencia + "' and codigo!='" +
                      producto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con esa referencia", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                if (producto.activo == true)
                {
                    activo = 1;
                }
                //validar la foto 
                if (producto.imagen == "")
                {
                    //si no tiene se asigna la foto por default
                    producto.imagen = "default1.png";
                }
                else
                {
                    //si tiene foto entonces se pega en la carpeta del proyecto
                    utilidades.copiarPegarArchivo(producto.imagen, rutaImagenesProductos, true);
                    producto.imagen = Path.GetFileName(producto.imagen);
                }
                sql =
                    "insert into producto(codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima) values('" +
                    producto.codigo + "','" + producto.nombre + "','" + producto.referencia + "','" + activo.ToString() +
                    "','" + producto.reorden + "','" + producto.punto_maximo + "','" + producto.codigo_itebis + "','" +
                    producto.codigo_categoria + "','" + producto.codigo_subcategoria + "','" + producto.codigo_almacen +
                    "','" + producto.imagen + "','" + producto.codigo_unidad_minima + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarProducto.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                string sql = "select *from producto where nombre='" + producto.nombre + "' and codigo!='" +
                             producto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                //validar referencia
                sql = "select *from producto where referencia='" + producto.referencia + "' and codigo!='" +
                      producto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con esa referencia", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                if (producto.activo == true)
                {
                    activo = 1;
                }
                //validar la foto 
                if (producto.imagen == "")
                {
                    //si no tiene se asigna la foto por default
                    producto.imagen = "default1.png";
                }
                else
                {
                    //si tiene foto entonces se pega en la carpeta del proyecto
                    utilidades.copiarPegarArchivo(producto.imagen, rutaImagenesProductos, true);
                    producto.imagen = Path.GetFileName(producto.imagen);
                }
                sql = "update producto set nombre='" + producto.nombre + "',referencia='" + producto.referencia +
                      "',activo='" + activo.ToString() + "',reorden='" + producto.reorden + "',punto_maximo='" +
                      producto.punto_maximo + "',cod_itebis='" + producto.codigo_itebis + "',cod_categoria='" +
                      producto.codigo_categoria + "',cod_subcategoria='" + producto.codigo_subcategoria +
                      "',cod_almacen='" + producto.codigo_almacen + "',imagen='" + producto.imagen +
                      "',cod_unidad_minima='" + producto.codigo_unidad_minima + "' where codigo='" + producto.codigo +
                      "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarProducto.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //agregar productos vs codigo de barra
        public bool agregarCodigoBarra(producto producto, List<producto_vs_codigobarra> lista)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();

                //borrar todos los codigo barra que son de este producto
                sql = "delete from producto_vs_codigobarra where cod_producto='" + producto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);

                //recorriendo la lista para agregarlo uno a uno
                lista.ForEach(x =>
                {
                    x.codigo_producto = producto.codigo;
                    sql = "insert into producto_vs_codigobarra(cod_producto,cod_unidad,codigo_barra) values('" +
                          producto.codigo + "','" + x.codigo_unidad + "','" + x.codigo_barra + "')";
                    ds = utilidades.ejecutarcomando_mysql(sql);
                });
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCodigoBarra.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //get lista de codigo de barra del producto
        public List<producto_vs_codigobarra> getListacodigoBarraById(int id)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                List<producto_vs_codigobarra> lista = new List<producto_vs_codigobarra>();
                producto_vs_codigobarra productoCodigoBarra;

                //borrar todos los codigo barra que son de este producto
                sql = "select cod_producto,cod_unidad,codigo_barra from producto_vs_codigobarra where cod_producto='" +
                      id + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    productoCodigoBarra = new producto_vs_codigobarra();
                    productoCodigoBarra.codigo_producto = Convert.ToInt16(row[0].ToString());
                    productoCodigoBarra.codigo_unidad = Convert.ToInt16(row[1].ToString());
                    productoCodigoBarra.codigo_barra = row[2].ToString();
                    lista.Add(productoCodigoBarra);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListacodigoBarraById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
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


        //get producto by id
        public producto getProductoById(int id)
        {
            try
            {
                producto producto = new producto();
                string sql =
                    "select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima from producto where codigo='" +
                    id + "'";
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
                MessageBox.Show("Error getProductoById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get producto by referencia
        public producto getProductoByReferencia(string referencia)
        {
            try
            {
                List<producto>lista=new List<producto>();
                producto producto = new producto();
                string sql ="select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima from producto";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    producto=new producto();
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
                producto = null;
                lista.FindAll(x => x.referencia.ToLower().Contains(referencia.ToLower()));
                if (lista.Count > 0)
                {
                    producto = lista.ToList().FirstOrDefault();
                }
                return producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getProductoById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<producto> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                producto producto = new producto();
                List<producto> lista = new List<producto>();
                string sql =
                    "select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima from producto ";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        producto = new producto();
                        producto.codigo = Convert.ToInt16(row[0].ToString());
                        producto.nombre = row[1].ToString();
                        producto.referencia = row[2].ToString();
                        producto.activo = Convert.ToBoolean(row[3].ToString());
                        producto.reorden = Convert.ToDecimal(row[4].ToString());
                        producto.punto_maximo = Convert.ToDecimal(row[5].ToString());
                        producto.codigo_itebis = Convert.ToInt16(row[6].ToString());
                        producto.codigo_categoria = Convert.ToInt16(row[7].ToString());
                        producto.codigo_subcategoria = Convert.ToInt16(row[8].ToString());
                        producto.codigo_almacen = Convert.ToInt16(row[9].ToString());
                        producto.imagen = row[10].ToString();
                        producto.codigo_unidad_minima = Convert.ToInt16(row[11].ToString());
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

        //validar codigo de barra
        public producto validarCodigoBarra(string codigoBarra,int codigoProducto=0)
        {
            try
            {
                string sql = "";
                DataSet ds=new DataSet();
                if (codigoProducto == 0)
                {
                    sql ="select cod_producto,cod_unidad,codigo_barra from producto_vs_codigobarra where codigo_barra='" +codigoBarra + "'";
                }
                else
                {
                    sql ="select cod_producto,cod_unidad,codigo_barra from producto_vs_codigobarra where codigo_barra='" +codigoBarra + "' and cod_producto='"+codigoProducto+"'";
                }
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count==0)
                {
                    return null;
                }
                producto = getProductoById(Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString()));
                return producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getProductoById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista Unidad ConversionById
        public List<productoUnidadConversion> getListaUnidadConversionById(int id)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                List<productoUnidadConversion> lista = new List<productoUnidadConversion>();
                productoUnidadConversion productoUnidadConversion;

                //borrar todos los codigo barra que son de este producto
                sql = "select cod_producto,cod_unidad,cantidad,precio_venta,costo from producto_unidad_conversion where cod_producto='" +id + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    productoUnidadConversion = new productoUnidadConversion();
                    productoUnidadConversion.codigo_producto = Convert.ToInt16(row[0].ToString());
                    productoUnidadConversion.codigo_unidad = Convert.ToInt16(row[1].ToString());
                    productoUnidadConversion.cantidad = Convert.ToDecimal(row[2].ToString());
                    productoUnidadConversion.precio_venta = Convert.ToDecimal(row[3].ToString());
                    productoUnidadConversion.precio_costo = Convert.ToDecimal(row[4].ToString());
                    lista.Add(productoUnidadConversion);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaUnidadConversionById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get precio producto unidad
        public productoUnidadConversion getPrecioProductoUnidad(int codigoProducto, int codigoUnidad)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                List<productoUnidadConversion> lista = new List<productoUnidadConversion>();
                productoUnidadConversion productoUnidadConversion;

                //borrar todos los codigo barra que son de este producto
                sql = "select cod_producto,cod_unidad,cantidad,precio_venta,costo from producto_unidad_conversion where cod_producto='"+codigoProducto+"' and cod_unidad='"+codigoUnidad+"'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if(ds.Tables[0].Rows.Count>0)
                {
                    productoUnidadConversion = new productoUnidadConversion();
                    productoUnidadConversion.codigo_producto = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    productoUnidadConversion.codigo_unidad = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    productoUnidadConversion.cantidad = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
                    productoUnidadConversion.precio_venta = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                    productoUnidadConversion.precio_costo = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    return productoUnidadConversion;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getPrecioProductoUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
