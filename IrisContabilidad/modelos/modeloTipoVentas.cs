﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloTipoVentas
    {
        //objetos
        utilidades utilidades = new utilidades();


        //get objeto
        public tipo_ventas getTipoVentaById(int id)
        {
            try
            {
                tipo_ventas tipoVenta = new tipo_ventas();
                string sql = "select codigo,nombre,activo from tipo_ventas where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipoVenta.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    tipoVenta.nombre = ds.Tables[0].Rows[0][1].ToString();
                    tipoVenta.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2]);
                }
                return tipoVenta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoVentaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<tipo_ventas> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<tipo_ventas> lista = new List<tipo_ventas>();
                string sql = "";
                sql = "select codigo,nombre,activo from tipo_ventas";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        tipo_ventas tipoVenta = new tipo_ventas();
                        tipoVenta.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                        tipoVenta.nombre = ds.Tables[0].Rows[0][1].ToString();
                        tipoVenta.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2]);
                        lista.Add(tipoVenta);
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

        //get tipo venta by nombre
        public tipo_ventas getTipoVentaByNombre(string nombre)
        {
            try
            {
                tipo_ventas tipoVenta;
                string sql = "";
                sql = "select codigo,nombre,activo from tipo_ventas where activo='1' and nombre like '%"+nombre+"%'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipoVenta = new tipo_ventas();
                    tipoVenta.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    tipoVenta.nombre = ds.Tables[0].Rows[0][1].ToString();
                    tipoVenta.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2]);
                    return tipoVenta;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
