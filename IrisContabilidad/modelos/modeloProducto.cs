﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloProducto
    {
        //objetos
        private utilidades utilidades = new utilidades();

        //variables
        private string rutaImagenesProductos = Directory.GetCurrentDirectory().ToString() + @"\Resources\productos\";
         


        //agregar 
        public bool agregarProducto(producto producto)
        {
            try
            {
                int activo = 0;
                int productoTitular = 0;
                //validar nombre
                string sql = "select *from producto where nombre='" + producto.nombre + "' and nombre!='' and codigo!='" +producto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con ese nombre", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
                //validar referencia
                sql = "select *from producto where referencia='" + producto.referencia + "' and referencia!='' and codigo!='"+producto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con esa referencia", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }

                if (producto.activo == true)
                {
                    activo = 1;
                }
                if (producto.producto_titular == true)
                {
                    productoTitular = 1;
                }
                else
                {
                    productoTitular = 0;
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
                sql ="insert into producto(codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima,producto_titular) values('" +
                    producto.codigo + "','" + producto.nombre + "','" + producto.referencia + "','" + activo.ToString() +
                    "','" + producto.reorden + "','" + producto.punto_maximo + "','" + producto.codigo_itebis + "','" +
                    producto.codigo_categoria + "','" + producto.codigo_subcategoria + "','" + producto.codigo_almacen +
                    "','" + producto.imagen + "','" + producto.codigo_unidad_minima + "','"+productoTitular+"')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarProducto.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarProducto(producto producto)
        {
            try
            {
                int activo = 0;
                int productoTitular = 0;
                //validar nombre
                string sql = "select *from producto where nombre='" + producto.nombre + "' and nombre!='' and codigo!='" + producto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un producto con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar referencia
                sql = "select *from producto where referencia='" + producto.referencia + "' and referencia!='' and codigo!='" + producto.codigo + "'";
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
                if (producto.producto_titular == true)
                {
                    productoTitular = 1;
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
                      "',cod_unidad_minima='" + producto.codigo_unidad_minima + "',producto_titular='" + productoTitular +
                      "' where codigo='" + producto.codigo + "'";
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
        public producto getProductoById(Int64 id)
        {
            try
            {
                producto producto = new producto();
                string sql ="select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima,controla_inventario,producto_titular from producto where codigo='" +id + "'";
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
                    producto.controla_inventario = Convert.ToBoolean(ds.Tables[0].Rows[0][12]);
                    producto.producto_titular = Convert.ToBoolean(ds.Tables[0].Rows[0][13]);
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
                string sql ="select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima,controla_inventario,producto_titular from producto where referencia like '%"+referencia+"%'";
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
                    producto.controla_inventario = Convert.ToBoolean(ds.Tables[0].Rows[0][12]);
                    producto.producto_titular = Convert.ToBoolean(ds.Tables[0].Rows[0][13]);
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
                MessageBox.Show("Error getProductoByReferencia.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        //get producto by codigo de barra
        public producto getProductoByCodigoBarra(string codigoBarra)
        {
            try
            {
                List<producto> lista = new List<producto>();
                producto producto = new producto();
                string sql = "select p.codigo,p.nombre,p.referencia,p.activo,p.reorden,p.punto_maximo,p.cod_itebis,p.cod_categoria,p.cod_subcategoria,p.cod_almacen,p.imagen,p.cod_unidad_minima,p.controla_inventario,p.producto_titular from producto p, producto_vs_codigobarra pc where p.codigo=pc.cod_producto and pc.codigo_barra like '%"+codigoBarra+"%';";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    producto = new producto();
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
                    producto.controla_inventario = Convert.ToBoolean(ds.Tables[0].Rows[0][12]);
                    producto.producto_titular = Convert.ToBoolean(ds.Tables[0].Rows[0][13]);
                    lista.Add(producto);
                }
                producto = null;
                lista.FindAll(x => x.referencia.ToLower().Contains(codigoBarra.ToLower()));
                if (lista.Count > 0)
                {
                    producto = lista.ToList().FirstOrDefault();
                }
                return producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getProductoByCodigoBarra.:" + ex.ToString(), "", MessageBoxButtons.OK,
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
                    "select codigo,nombre,referencia,activo,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima,controla_inventario,producto_titular from producto ";
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
                        producto.controla_inventario = Convert.ToBoolean(row[12]);
                        producto.producto_titular = Convert.ToBoolean(row[13]);
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
                producto producto = getProductoById(Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString()));
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
                sql = "select cod_producto,cod_unidad,cantidad,precio_venta1,precio_venta2,precio_venta3,precio_venta4,precio_venta5,costo from producto_unidad_conversion where cod_producto='" + id + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    productoUnidadConversion = new productoUnidadConversion();
                    productoUnidadConversion.codigo_producto = Convert.ToInt16(row[0].ToString());
                    productoUnidadConversion.codigo_unidad = Convert.ToInt16(row[1].ToString());
                    productoUnidadConversion.cantidad = Convert.ToDecimal(row[2].ToString());
                    productoUnidadConversion.precio_venta1 = Convert.ToDecimal(row[3].ToString());
                    productoUnidadConversion.precio_venta2 = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    productoUnidadConversion.precio_venta3 = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                    productoUnidadConversion.precio_venta4 = Convert.ToDecimal(ds.Tables[0].Rows[0][6].ToString());
                    productoUnidadConversion.precio_venta5 = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString());
                    productoUnidadConversion.precio_costo = Convert.ToDecimal(row[8].ToString());
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
                sql = "select cod_producto,cod_unidad,cantidad,precio_venta1,precio_venta2,precio_venta3,precio_venta4,precio_venta5,costo from producto_unidad_conversion where cod_producto='" + codigoProducto + "' and cod_unidad='" + codigoUnidad + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if(ds.Tables[0].Rows.Count>0)
                {
                    productoUnidadConversion = new productoUnidadConversion();
                    productoUnidadConversion.codigo_producto = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    productoUnidadConversion.codigo_unidad = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    productoUnidadConversion.cantidad = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
                    productoUnidadConversion.precio_venta1 = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                    productoUnidadConversion.precio_venta2 = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    productoUnidadConversion.precio_venta3 = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                    productoUnidadConversion.precio_venta4 = Convert.ToDecimal(ds.Tables[0].Rows[0][6].ToString());
                    productoUnidadConversion.precio_venta5 = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString());
                    productoUnidadConversion.precio_costo = Convert.ToDecimal(ds.Tables[0].Rows[0][8].ToString());
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
        //get lista precios producto unidad
        public List<producto_precio_venta> getListaPrecioProductoUnidad(int codigoProducto, int codigoUnidad)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                List<producto_precio_venta> lista = new List<producto_precio_venta>();
                producto_precio_venta productoPrecioVenta;

                //borrar todos los codigo barra que son de este producto
                sql = "select precio_venta1,precio_venta2,precio_venta3,precio_venta4,precio_venta5 from producto_unidad_conversion where cod_producto='" + codigoProducto + "' and cod_unidad='" + codigoUnidad + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        productoPrecioVenta = new producto_precio_venta();
                        productoPrecioVenta.precio_venta1 = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
                        productoPrecioVenta.precio_venta2 = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString());
                        productoPrecioVenta.precio_venta3 = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
                        productoPrecioVenta.precio_venta4 = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                        productoPrecioVenta.precio_venta5 = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                        lista.Add(productoPrecioVenta);    
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaPrecioProductoUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista productos requisitos
        public List<producto_productos_requisitos> getListaProductoRequisitos(int codigoProducto)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                List<producto_productos_requisitos> lista = new List<producto_productos_requisitos>();
                producto_productos_requisitos productoRequisitos;

                //borrar todos los codigo barra que son de este producto
                sql = "select codpro_titular,codpro_requisito,cod_unidad,cantidad FROM producto_productos_requisitos where codpro_titular='" + codigoProducto + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        productoRequisitos = new producto_productos_requisitos();
                        productoRequisitos.codigo_producto_titular = Convert.ToInt16(row[0].ToString());
                        productoRequisitos.codigo_producto_requisito = Convert.ToInt16(row[1].ToString());
                        productoRequisitos.codigo_unidad = Convert.ToInt16(row[2].ToString());
                        productoRequisitos.cantidad = Convert.ToDecimal(row[3].ToString());
                        lista.Add(productoRequisitos);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaProductoRequisitos.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        public unidad getUnidadMinimaByProducto(int idProducto)
        {
            try
            {
                unidad unidad;
                string sql = "select cod_unidad_minima from producto where codigo='"+idProducto+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                unidad = new modeloUnidad().getUnidadById(Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString()));
                if (unidad.codigo != null)
                {
                    return unidad;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getUnidadMinimaByProducto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //obtiene la existencia de un producto con relacion a una unidad
        public decimal getExistenciaByProductoAndUnidad(int codigoProducto, int codigoUnidadConvertir)
        {
            try
            {
                List<unidad> listaUnidad=new List<unidad>();
                unidad unidadMinima;
                decimal existencia = 0;
                string sql = "";
                DataSet ds = new DataSet();
                decimal cantidadUnidadMinima = 0;//saber la cantidad de la unidad minima
                decimal cantidadUnidadConvertir = 0;//saber la cantidad de la unidad a la que se quiere convertir
                decimal cantidadUnidadMinimaExistencia = 0;//saber la cantidad que hay en existencia de la unidad minima


                //lista de las unidad producto conversion que tiene este producto
                listaUnidad = new modeloUnidad().getListaCompletaByProductoId(codigoProducto);
                listaUnidad = listaUnidad.Distinct().ToList();


                //obtiene la unidad minima del producto
                unidadMinima = getUnidadMinimaByProducto(codigoProducto);

                //obtiene la cantidad unidades que maneja la unidad minima
                sql = "select cantidad from producto_unidad_conversion where cod_producto='"+codigoProducto+"' and cod_unidad='"+unidadMinima.codigo+"'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    cantidadUnidadMinima = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
                }

                //obtiene la cantidad unidades que maneja la unidad a convertir
                sql = "select cantidad from producto_unidad_conversion where cod_producto='" + codigoProducto + "' and cod_unidad='" + codigoUnidadConvertir + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    cantidadUnidadConvertir = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
                }

                existencia = 0;
                foreach (var unidadActual in listaUnidad)
                {
                    existencia = 0;
                    sql = "select sum(cantidad) from inventario where codigo_producto='"+codigoProducto+"' and codigo_unidad='"+unidadActual.codigo+"'";
                    ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        existencia = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
                        cantidadUnidadMinimaExistencia += existencia*cantidadUnidadMinima;
                    }
                }

                existencia = cantidadUnidadMinimaExistencia/cantidadUnidadConvertir;
                return existencia;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getExistenciaByProductoAndUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return 0;
            }
        }


        //obtiene el precio venta de un producto con relacion a una unidad
        public producto_precio_venta getPrecioVentaByProductoAndUnidad(int codigoProducto, int codigoUnidad)
        {
            try
            {
                List<unidad> listaUnidad = new List<unidad>();
                unidad unidadMinima;
                producto_precio_venta precioVenta =new producto_precio_venta();
                string sql = "";
                DataSet ds = new DataSet();
                

                //obtiene la cantidad unidades que maneja la unidad minima
                sql = "select precio_venta1,precio_venta2,precio_venta3,precio_venta4,precio_venta5 from producto_unidad_conversion where cod_producto='"+codigoProducto+"' and cod_unidad='"+codigoUnidad+"'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                precioVenta.codigo_producto = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                precioVenta.codigo_unidad = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                precioVenta.precio_venta1 = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
                precioVenta.precio_venta2 = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                precioVenta.precio_venta3 = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                precioVenta.precio_venta4 = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                precioVenta.precio_venta5 = Convert.ToDecimal(ds.Tables[0].Rows[0][6].ToString());

                return precioVenta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getExistenciaByProductoAndUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista precio productos unidades
        public List<producto_precio_venta> getListaProductoPrecioVenta()
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                List<producto_precio_venta> lista = new List<producto_precio_venta>();
                producto_precio_venta precioVenta;

                //borrar todos los codigo barra que son de este producto
                sql = "select cod_producto,cod_unidad,precio_venta1,precio_venta2,precio_venta3,precio_venta4,precio_venta5 from producto_unidad_conversion";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        precioVenta = new producto_precio_venta();
                        precioVenta.codigo_producto = Convert.ToInt16(row[0]);
                        precioVenta.codigo_unidad = Convert.ToInt16(row[1]);
                        precioVenta.precio_venta1 = Convert.ToInt16(row[2]);
                        precioVenta.precio_venta2 = Convert.ToInt16(row[3]);
                        precioVenta.precio_venta3 = Convert.ToInt16(row[4]);
                        precioVenta.precio_venta4 = Convert.ToDecimal(row[5]);
                        precioVenta.precio_venta5 = Convert.ToDecimal(row[6]);
                        lista.Add(precioVenta);
                    }
                }
                lista = lista.OrderByDescending(x => x.codigo_producto).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaProductoPrecioVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool agregarListaPrecioProducto(List<producto_precio_venta> lista)
        {
            try
            {
                string sql = "";
                DataSet ds=new DataSet();
                if (lista == null)
                {
                    MessageBox.Show("Lista llega nula agregarListaPrecioProducto.","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                lista.ForEach(x =>
                {
                    sql = "select *from producto_unidad_conversion where cod_producto='"+x.codigo_producto+"' and cod_unidad='"+x.codigo_unidad+"'";
                    ds=utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //update
                        sql = "update producto_unidad_conversion set precio_venta1='"+x.precio_venta1+"',precio_venta2='"+x.precio_venta2+"',precio_venta3='"+x.precio_venta3+"',precio_venta4='"+x.precio_venta4+"',precio_venta5='"+x.precio_venta5+"' where cod_producto='"+x.codigo_producto+"' and cod_unidad='"+x.codigo_unidad+"'";
                    }
                    else
                    {
                        producto producto = new modeloProducto().getProductoById(x.codigo_producto);
                        MessageBox.Show("El producto.: "+producto.nombre+", no tiene unidades de conversión, por favor revisarlo","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        //insert
                        //sql = "insert into producto_unidad_conversion(cod_producto,cod_unidad,cantidad,costo,precio_venta1,precio_venta2,precio_venta3,precio_venta4,precio_venta5) values('" + x.codigo_producto + "','" + x.codigo_unidad + "','" + x.precio_venta1 + "','" + x.precio_venta2 + "','" + x.precio_venta3 + "','" + x.precio_venta4 + "','" + x.precio_venta5 + "')";
                    }
                    utilidades.ejecutarcomando_mysql(sql);
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarListaPrecioProducto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
