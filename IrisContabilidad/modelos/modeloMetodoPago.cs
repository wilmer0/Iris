using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloMetodoPago
    {


        //objetos
        utilidades utilidades=new utilidades();

        public metodo_pago getMetodoPagoById(int id)
        {
            try
            {
                //select codigo,metodo,descripcion,activo from metodo_pago where codigo='';
                metodo_pago metodoPago = new metodo_pago();
                string sql = "select codigo,metodo,descripcion,activo from metodo_pago where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    metodoPago.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    metodoPago.metodo = ds.Tables[0].Rows[0][1].ToString();
                    metodoPago.detalle = ds.Tables[0].Rows[0][2].ToString();
                    metodoPago.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                }
                return metodoPago;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMetodoPagoById.:" + ex.ToString(), "", MessageBoxButton.OK,MessageBoxImage.Error);
                return null;
            }
        }

        public List<metodo_pago> getListaMetodoPago()
        {
            try
            {
                //select codigo,metodo,descripcion,activo from metodo_pago where codigo='';
                metodo_pago metodoPago = new metodo_pago();
                List<metodo_pago> lista=new List<metodo_pago>();
                string sql = "select codigo,metodo,descripcion,activo from metodo_pago where activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        metodoPago=new metodo_pago();
                        metodoPago.codigo = Convert.ToInt16(row[0].ToString());
                        metodoPago.metodo = row[1].ToString();
                        metodoPago.detalle = row[2].ToString();
                        metodoPago.activo = Convert.ToBoolean(row[3]);
                        lista.Add(metodoPago);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaMetodoPago.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

    }
}
