using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloCategoriaCliente
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCategoriaCliente(categoria_cliente categoria)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from cliente_categoria where nombre='" + categoria.nombre + "' and codigo!='" + categoria.codigo + "'";
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

                sql = "insert into cliente_categoria(codigo,nombre,activo) values('" + categoria.codigo + "','"+ categoria.nombre + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCategoriaCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCategoriaCliente(categoria_cliente categoria)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from cliente_categoria where nombre='" + categoria.nombre + "' and codigo!='" + categoria.codigo + "'";
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
                sql = "update cliente_categoria set nombre='" + categoria.nombre + "',activo='" + activo.ToString() + "' where codigo='" + categoria.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCategoriaCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from cliente_categoria";
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


        //get objeto by id
        public categoria_cliente getCategoriaClienteById(int id)
        {
            try
            {
                categoria_cliente categoria = new categoria_cliente();
                string sql = "select codigo,nombre,activo from cliente_categoria where codigo='" + id + "'";
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
                MessageBox.Show("Error getCategoriaClienteById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
       

        //get lista completa
        public List<categoria_cliente> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<categoria_cliente> lista = new List<categoria_cliente>();
                string sql = "select codigo,nombre,activo from cliente_categoria";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        categoria_cliente tipo = new categoria_cliente();
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
