using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloCajero
    {

        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCajero(cajero cajero)
        {
            try
            {
                int activo = 0;
                //validar caja del cajero
                string sql = "select *from cajero where cod_caja='" + cajero.codigo_caja + "' and codigo!='" + cajero.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una cajero con esa caja", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
               

                if (cajero.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into cajero(codigo,cod_empleado,cod_caja,activo,tipo_impresion_venta) values('" + cajero.codigo + "','" + cajero.codigo_empleado + "','" + cajero.codigo_caja + "','" + activo.ToString() + "','"+cajero.tipoImpresionVenta+"')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCajero.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCajero(cajero cajero)
        {
            try
            {
                int activo = 0;
                //validar caja del cajero
                string sql = "select *from cajero where cod_caja='" + cajero.codigo_caja + "' and codigo!='" + cajero.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una cajero con esa caja", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
               



                if (cajero.activo == true)
                {
                    activo = 1;
                }
                sql = "update cajero set cod_empleado='" + cajero.codigo_empleado + "',cod_caja='" + cajero.codigo_caja + "',activo='" + activo.ToString() + "',tipo_impresion_venta='"+cajero.tipoImpresionVenta+"' where codigo='" + cajero.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCajero.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo) from cajero";
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


        //get by id
        public cajero getCajeroById(int id)
        {
            try
            {
                cajero cajero = new cajero();
                string sql = "select codigo,cod_empleado,cod_caja,activo,tipo_impresion_venta from cajero where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cajero.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    cajero.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    cajero.codigo_caja = Convert.ToInt16(ds.Tables[0].Rows[0][2]);
                    cajero.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    cajero.tipoImpresionVenta = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                }
                return cajero;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCajeroById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get by empleado
        public cajero getCajeroByIdEmpleado(int id)
        {
            try
            {
                cajero cajero = new cajero();
                string sql = "select codigo,cod_empleado,cod_caja,activo,tipo_impresion_venta from cajero where cod_empleado='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cajero.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    cajero.codigo_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    cajero.codigo_caja = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    cajero.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    cajero.tipoImpresionVenta = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                }
                return cajero;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCajeroByIdEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<cajero> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<cajero> lista = new List<cajero>();
                string sql = "select codigo,cod_empleado,cod_caja,activo,tipo_impresion_venta from cajero";
                if (mantenimiento == false)
                {
                    sql += " where activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cajero cajero = new cajero();
                        cajero.codigo = Convert.ToInt16(row[0].ToString());
                        cajero.codigo_empleado = Convert.ToInt16(row[1].ToString());
                        cajero.codigo_caja = Convert.ToInt16(row[2].ToString());
                        cajero.activo = Convert.ToBoolean(row[3]);
                        cajero.tipoImpresionVenta = Convert.ToInt16(row[4]);
                        lista.Add(cajero);
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

        //get validar si cajero tiene caja abierta
        public bool getValidarCajaAbiertaByCajero(int codigoCajero)
        {
            try
            {
                empleado empleado=new empleado();
                empleado = new modeloEmpleado().getEmpleadoByCajeroId(codigoCajero);
                if (empleado == null)
                {
                    return false;
                }

                string sql = "select *from cuadre_caja where activo='1' and cod_sucursal='"+empleado.codigo_sucursal+"' and caja_cuadrada='0' and caja_abierta='1' and cod_cajero='"+codigoCajero+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getValidarCajaAbiertaByCajero.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
