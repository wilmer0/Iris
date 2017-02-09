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
    public class modeloCliente
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCliente(cliente cliente)
        {
            try
            {
                int abrir_credito = 0;
                int cliente_contado = 0;
                int activo = 0;
                //validar cedula
                string sql = "select * from cliente where cedula='" + cliente.cedula + "' and codigo!='" + cliente.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un cliente con la misma cedula", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar rnc
                sql = "select * from cliente where rnc='" + cliente.rnc + "' and codigo!='" + cliente.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un cliente con el mismo rnc", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



                if (cliente.activo == true)
                {
                    activo = 1;
                }
                if (cliente.abrir_credito == true)
                {
                    abrir_credito = 1;
                }
                if (cliente.cliente_contado == true)
                {
                    cliente_contado = 1;
                }
                sql = "insert cliente (codigo,nombre,limite_credito,cod_categoria,activo,fecha_creado,abrir_credito,cod_sucursal_creado,cliente_contado,telefono1,telefono2,cedula,rnc,cod_tipo_comprobante,direccion1,direccion2) values('" + cliente.codigo + "','" + cliente.nombre + "','" + cliente.limite_credito + "','" + cliente.codigo_categoria + "','" + activo + "','" + cliente.fecha_creado.ToString("yyyy-MM-dd") + "','" + abrir_credito + "','" + cliente.codigo_sucursal_creado + "','" + cliente_contado + "','" + cliente.telefono1 + "','" + cliente.telefono2 + "','" + cliente.cedula + "','" + cliente.rnc + "','" + cliente.codigo_tipo_comprobante_fiscal + "','" + cliente.direccion1 + "','" + cliente.direccion2 + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCliente(cliente cliente)
        {
            try
            {
                int abrir_credito = 0;
                int cliente_contado = 0;
                int activo = 0;
                //validar cedula
                string sql = "select * from cliente where cedula='" + cliente.cedula + "' and codigo!='" + cliente.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un cliente con la misma cedula", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar rnc
                sql = "select * from cliente where rnc='" + cliente.rnc + "' and codigo!='" + cliente.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un cliente con el mismo rnc", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



                if (cliente.activo == true)
                {
                    activo = 1;
                }
                if (cliente.abrir_credito == true)
                {
                    abrir_credito = 1;
                }
                if (cliente.cliente_contado == true)
                {
                    cliente_contado = 1;
                }
                sql = "update cliente set nombre='" + cliente.nombre + "',limite_credito='" + cliente.limite_credito + "',cod_Categoria='" + cliente.codigo_categoria + "',activo='" + activo + "',abrir_credito='" + abrir_credito + "',cod_sucursal_creado='" + cliente.codigo_sucursal_creado + "',cliente_contado='" + cliente_contado + "',telefono1='" + cliente.telefono1 + "',telefono2='" + cliente.telefono2 + "',cedula='" + cliente.cedula + "',rnc='" + cliente.rnc + "',cod_tipo_comprobante='" + cliente.codigo_tipo_comprobante_fiscal + "',direccion1='"+cliente.direccion1+"',direccion2='"+cliente.direccion2+"' where codigo='" + cliente.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from cliente";
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
        public cliente getClienteById(int id)
        {
            try
            {
                cliente cliente = new cliente();
                string sql = "select codigo,nombre,limite_credito,cod_categoria,activo,fecha_creado,abrir_credito,cod_sucursal_creado,cliente_contado,telefono1,telefono2,cedula,rnc,cod_tipo_comprobante,direccion1,direccion2  from cliente where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cliente.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    cliente.nombre = ds.Tables[0].Rows[0][1].ToString();
                    cliente.limite_credito = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
                    cliente.codigo_categoria = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    //cliente.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4].ToString());
                    cliente.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    cliente.fecha_creado = Convert.ToDateTime(ds.Tables[0].Rows[0][5].ToString());
                    //cliente.abrir_credito = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());
                    cliente.abrir_credito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                    cliente.codigo_sucursal_creado = Convert.ToInt16(ds.Tables[0].Rows[0][7].ToString());
                    //cliente.cliente_contado = Convert.ToBoolean(ds.Tables[0].Rows[0][8].ToString());
                    cliente.cliente_contado = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    cliente.telefono1 = ds.Tables[0].Rows[0][9].ToString();
                    cliente.telefono2 = ds.Tables[0].Rows[0][10].ToString();
                    cliente.cedula = ds.Tables[0].Rows[0][11].ToString();
                    cliente.rnc = ds.Tables[0].Rows[0][12].ToString();
                    cliente.codigo_tipo_comprobante_fiscal = Convert.ToInt16(ds.Tables[0].Rows[0][13].ToString());
                }
                return cliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getClienteById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<cliente> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<cliente> lista = new List<cliente>();
                string sql = "select codigo,nombre,limite_credito,cod_categoria,activo,fecha_creado,abrir_credito,cod_sucursal_creado,cliente_contado,telefono1,telefono2,cedula,rnc,cod_tipo_comprobante,direccion1,direccion2  from cliente";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cliente cliente = new cliente();
                        cliente.codigo = Convert.ToInt16(row[0].ToString());
                        cliente.nombre = row[1].ToString();
                        cliente.limite_credito = Convert.ToDecimal(row[2].ToString());
                        cliente.codigo_categoria = Convert.ToInt16(row[3].ToString());
                        //cliente.activo = Convert.ToBoolean(row[4].ToString());
                        cliente.activo = Convert.ToBoolean(row[4]);
                        cliente.fecha_creado = Convert.ToDateTime(row[5].ToString());
                        //cliente.abrir_credito = Convert.ToBoolean(row[6].ToString());
                        cliente.abrir_credito = Convert.ToBoolean(row[6]);
                        cliente.codigo_sucursal_creado = Convert.ToInt16(row[7].ToString());
                        //cliente.cliente_contado = Convert.ToBoolean(row[8].ToString());
                        cliente.cliente_contado = Convert.ToBoolean(row[8]);
                        cliente.telefono1 = row[9].ToString();
                        cliente.telefono2 = row[10].ToString();
                        cliente.cedula = row[11].ToString();
                        cliente.rnc = row[12].ToString();
                        cliente.codigo_tipo_comprobante_fiscal = Convert.ToInt16(row[13].ToString());
                        cliente.direccion1 = row[13].ToString();
                        cliente.direccion2 = row[14].ToString();
                        lista.Add(cliente);
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
        public List<cliente> getListaByNombre(string nombre)
        {
            try
            {

                List<cliente> lista = new List<cliente>();
                string sql = "select codigo,nombre,limite_credito,cod_categoria,activo,fecha_creado,abrir_credito,cod_sucursal_creado,cliente_contado,telefono1,telefono2,cedula,rnc,cod_tipo_comprobante,direccion1,direccion2   from cliente where activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cliente cliente = new cliente();
                        cliente.codigo = Convert.ToInt16(row[0].ToString());
                        cliente.nombre = row[1].ToString();
                        cliente.limite_credito = Convert.ToDecimal(row[2].ToString());
                        cliente.codigo_categoria = Convert.ToInt16(row[3].ToString());
                        cliente.activo = Convert.ToBoolean(row[4]);
                        cliente.fecha_creado = Convert.ToDateTime(row[5]);
                        cliente.abrir_credito = Convert.ToBoolean(row[6]);
                        cliente.codigo_sucursal_creado = Convert.ToInt16(row[7].ToString());
                        cliente.cliente_contado = Convert.ToBoolean(row[8]);
                        cliente.telefono1 = row[9].ToString();
                        cliente.telefono2 = row[10].ToString();
                        cliente.cedula = row[11].ToString();
                        cliente.rnc = row[12].ToString();
                        cliente.codigo_tipo_comprobante_fiscal = Convert.ToInt16(row[13].ToString());
                        cliente.direccion1 = row[13].ToString();
                        cliente.direccion2 = row[14].ToString();
                        lista.Add(cliente);
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
        //get cliente by venta cobro
        public cliente getClienteByVentaCobro(int codigoCobro)
        {
            try
            {
                cliente cliente = new cliente();
                string sql = "select distinct c.codigo,c.nombre,c.limite_credito,c.cod_categoria,c.activo,c.fecha_creado,c.abrir_credito,c.cod_sucursal_creado,c.cliente_contado,c.telefono1,c.telefono2,c.cedula,c.rnc,c.cod_tipo_comprobante,c.direccion1,c.direccion2 from cliente c join venta v on v.codigo_cliente=c.codigo join venta_vs_cobros_detalles vcd on vcd.cod_venta=v.codigo where vcd.cod_cobro='"+codigoCobro+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cliente.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    cliente.nombre = ds.Tables[0].Rows[0][1].ToString();
                    cliente.limite_credito = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString());
                    cliente.codigo_categoria = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    cliente.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    cliente.fecha_creado = Convert.ToDateTime(ds.Tables[0].Rows[0][5].ToString());
                    cliente.abrir_credito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                    cliente.codigo_sucursal_creado = Convert.ToInt16(ds.Tables[0].Rows[0][7].ToString());
                    cliente.cliente_contado = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    cliente.telefono1 = ds.Tables[0].Rows[0][9].ToString();
                    cliente.telefono2 = ds.Tables[0].Rows[0][10].ToString();
                    cliente.cedula = ds.Tables[0].Rows[0][11].ToString();
                    cliente.rnc = ds.Tables[0].Rows[0][12].ToString();
                    cliente.codigo_tipo_comprobante_fiscal = Convert.ToInt16(ds.Tables[0].Rows[0][13].ToString());
                    cliente.direccion1 = ds.Tables[0].Rows[0][13].ToString();
                    cliente.direccion2 = ds.Tables[0].Rows[0][14].ToString();
                    
                }
                return cliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getClienteByVentaCobro.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
