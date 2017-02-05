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
    public class modeloSuplidor
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarSuplidor(suplidor suplidor)
        {
            try
            {
                int activo = 0;
                //validar rnc
                string sql = "select *from suplidor where rnc='" + suplidor.rnc + "' and codigo!='" + suplidor.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un suplidor con ese RNC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre
                sql = "select *from suplidor where nombre='" + suplidor.nombre + "' and codigo!='" + suplidor.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un suplidor con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (suplidor.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into suplidor(codigo,nombre,rnc,fecha_creacion,cod_sucursal_creado,limite_credito,activo,direccion,telefono1,telefono2,tipo_gasto,fecha_modificacion,fax,cod_ciudad) values('" + suplidor.codigo + "','" + suplidor.nombre + "','" + suplidor.rnc + "','" + suplidor.fecha_creacion.ToString("yyyy-MM-dd") + "','" + suplidor.codigo_sucursal_creado + "','" + suplidor.limite_credito + "','" + activo + "','" + suplidor.direccion + "','" + suplidor.telefono1 + "','" + suplidor.telefono2 + "','" + suplidor.cod_tipo_gasto + "','" + suplidor.fecha_modificacion.ToString("yyyy-MM-dd")+ "','" + suplidor.fax + "','" + suplidor.codigo_ciudad + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarSuplidor(suplidor suplidor)
        {
            try
            {
                int activo = 0;
                //validar rnc
                string sql = "select *from suplidor where rnc='" + suplidor.rnc + "' and codigo!='" + suplidor.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un suplidor con ese RNC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre
                sql = "select *from suplidor where nombre='" + suplidor.nombre + "' and codigo!='" + suplidor.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un suplidor con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (suplidor.activo == true)
                {
                    activo = 1;
                }

                sql = "update suplidor set nombre='" + suplidor.nombre + "',rnc='" + suplidor.rnc + "',limite_credito='" + suplidor.limite_credito + "',activo='" + activo + "',direccion='" + suplidor.direccion + "',telefono1='" + suplidor.telefono1 + "',telefono2='" + suplidor.telefono2 + "',tipo_gasto='" + suplidor.cod_tipo_gasto + "',fecha_modificacion='"+DateTime.Today.ToString("yyyy-MM-dd")+"',fax='"+suplidor.fax+"',cod_ciudad='"+suplidor.codigo_ciudad+"' where codigo='" + suplidor.codigo + "'";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from suplidor";
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
        public suplidor getSuplidorById(int id)
        {
            try
            {
                suplidor suplidor=new suplidor();
                string sql = "select codigo,nombre,rnc,fecha_creacion,cod_sucursal_creado,limite_credito,activo,direccion,telefono1,telefono2,tipo_gasto,fecha_modificacion,fax,cod_ciudad from suplidor where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    suplidor.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    suplidor.nombre = ds.Tables[0].Rows[0][1].ToString();
                    suplidor.rnc = ds.Tables[0].Rows[0][2].ToString();
                    suplidor.fecha_creacion = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
                    suplidor.codigo_sucursal_creado = Convert.ToInt16(ds.Tables[0].Rows[0][4].ToString());
                    suplidor.limite_credito = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                    suplidor.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());
                    suplidor.direccion = ds.Tables[0].Rows[0][7].ToString();
                    suplidor.telefono1 = ds.Tables[0].Rows[0][8].ToString();
                    suplidor.telefono2 = ds.Tables[0].Rows[0][9].ToString();
                    suplidor.cod_tipo_gasto = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    suplidor.fecha_modificacion = Convert.ToDateTime(ds.Tables[0].Rows[0][11].ToString());
                    suplidor.fax = ds.Tables[0].Rows[0][12].ToString();
                    suplidor.codigo_ciudad = Convert.ToInt16(ds.Tables[0].Rows[0][13].ToString());
                }
                return suplidor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSuplidorById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<suplidor> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<suplidor> lista = new List<suplidor>();
                string sql = "";
                sql = "select codigo,nombre,rnc,fecha_creacion,cod_sucursal_creado,limite_credito,activo,direccion,telefono1,telefono2,tipo_gasto,fecha_modificacion,fax,cod_ciudad from suplidor";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        suplidor suplidor = new suplidor();
                        suplidor.codigo = Convert.ToInt16(row[0].ToString());
                        suplidor.nombre = row[1].ToString();
                        suplidor.rnc = row[2].ToString();
                        suplidor.fecha_creacion = Convert.ToDateTime(row[3].ToString());
                        suplidor.codigo_sucursal_creado = Convert.ToInt16(row[4].ToString());
                        suplidor.limite_credito = Convert.ToDecimal(row[5].ToString());
                        suplidor.activo = Convert.ToBoolean(row[6].ToString());
                        suplidor.direccion = row[7].ToString();
                        suplidor.telefono1 = row[8].ToString();
                        suplidor.telefono2 = row[9].ToString();
                        suplidor.cod_tipo_gasto = Convert.ToInt16(row[10].ToString());
                        suplidor.fecha_modificacion = Convert.ToDateTime(row[11].ToString());
                        suplidor.fax = row[12].ToString();
                        suplidor.codigo_ciudad = Convert.ToInt16(row[13].ToString());

                        lista.Add(suplidor);
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
        //get suplidor by compra pago
        public suplidor getSuplidorByCompraPago(int id)
        {
            try
            {
                suplidor suplidor = new suplidor();
                string sql = "select distinct s.codigo,s.nombre,s.rnc,s.fecha_creacion,s.cod_sucursal_creado,s.limite_credito,s.activo,s.direccion,s.telefono1,s.telefono2,s.tipo_gasto,s.fecha_modificacion,s.fax,s.cod_ciudad from suplidor s join compra c on c.cod_suplidor=s.codigo join compra_vs_pagos_detalles cd on cd.cod_compra=c.codigo where cd.cod_pago='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    suplidor.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    suplidor.nombre = ds.Tables[0].Rows[0][1].ToString();
                    suplidor.rnc = ds.Tables[0].Rows[0][2].ToString();
                    suplidor.fecha_creacion = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
                    suplidor.codigo_sucursal_creado = Convert.ToInt16(ds.Tables[0].Rows[0][4].ToString());
                    suplidor.limite_credito = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                    suplidor.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());
                    suplidor.direccion = ds.Tables[0].Rows[0][7].ToString();
                    suplidor.telefono1 = ds.Tables[0].Rows[0][8].ToString();
                    suplidor.telefono2 = ds.Tables[0].Rows[0][9].ToString();
                    suplidor.cod_tipo_gasto = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    suplidor.fecha_modificacion = Convert.ToDateTime(ds.Tables[0].Rows[0][11].ToString());
                    suplidor.fax = ds.Tables[0].Rows[0][12].ToString();
                    suplidor.codigo_ciudad = Convert.ToInt16(ds.Tables[0].Rows[0][13].ToString());
                }
                return suplidor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSuplidorByCompraPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
