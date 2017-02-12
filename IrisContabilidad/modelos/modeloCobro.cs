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
    public class modeloCobro
    {
        private utilidades utilidades = new utilidades();

        //get lista cobros todos
        public List<venta_vs_cobros> getListaCompletaCobros()
        {
            try
            {
                List<venta_vs_cobros> lista = new List<venta_vs_cobros>();
                venta_vs_cobros cobro = new venta_vs_cobros();
                string sql =
                    "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from venta_vs_cobros where activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobro = new venta_vs_cobros();
                        cobro.codigo = Convert.ToInt16(row[0].ToString());
                        cobro.fecha = Convert.ToDateTime(row[1].ToString());
                        cobro.cod_empleado = Convert.ToInt16(row[2].ToString());
                        cobro.activo = Convert.ToBoolean(row[3]);
                        cobro.cod_empleado_anular = Convert.ToInt16(row[4].ToString());
                        cobro.motivo_anulado = row[5].ToString();
                        cobro.cuadrado = Convert.ToBoolean(row[6]);
                        cobro.detalle = row[7].ToString();
                        lista.Add(cobro);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaCobros.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista cobros todos
        public List<venta_vs_cobros> getListaCompletaCobrosNoCuadrados()
        {
            try
            {
                List<venta_vs_cobros> lista = new List<venta_vs_cobros>();
                venta_vs_cobros cobro = new venta_vs_cobros();
                string sql =
                    "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from venta_vs_cobros where activo='1' and cuadrado='0'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobro = new venta_vs_cobros();
                        cobro.codigo = Convert.ToInt16(row[0].ToString());
                        cobro.fecha = Convert.ToDateTime(row[1].ToString());
                        cobro.cod_empleado = Convert.ToInt16(row[2].ToString());
                        cobro.activo = Convert.ToBoolean(row[3]);
                        cobro.cod_empleado_anular = Convert.ToInt16(row[4].ToString());
                        cobro.motivo_anulado = row[5].ToString();
                        cobro.cuadrado = Convert.ToBoolean(row[6]);
                        cobro.detalle = row[7].ToString();
                        lista.Add(cobro);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaCobrosNoCuadrados.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista cobros no cuadrados by cliente id
        public List<venta_vs_cobros> getListaCompletaCobrosNoCuadradosByClienteId()
        {
            try
            {
                List<venta_vs_cobros> lista = new List<venta_vs_cobros>();
                venta_vs_cobros cobro = new venta_vs_cobros();
                string sql =
                    "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from venta_vs_cobros where activo='1' and cuadrado='0'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobro = new venta_vs_cobros();
                        cobro.codigo = Convert.ToInt16(row[0].ToString());
                        cobro.fecha = Convert.ToDateTime(row[1].ToString());
                        cobro.cod_empleado = Convert.ToInt16(row[2].ToString());
                        cobro.activo = Convert.ToBoolean(row[3]);
                        cobro.cod_empleado_anular = Convert.ToInt16(row[4].ToString());
                        cobro.motivo_anulado = row[5].ToString();
                        cobro.cuadrado = Convert.ToBoolean(row[6]);
                        cobro.detalle = row[7].ToString();
                        lista.Add(cobro);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaCobrosNoCuadrados.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista cobros activo detalle by cliente
        public List<venta_vs_cobros_detalles> getListaCobrosDetallesActivosByClienteId(int id)
        {
            try
            {
                List<venta_vs_cobros_detalles> lista = new List<venta_vs_cobros_detalles>();
                venta_vs_cobros_detalles cobroDetalle = new venta_vs_cobros_detalles();
                string sql = "select cd.codigo,cd.cod_cobro,cd.cod_metodo_cobro,cd.monto_cobrado,cd.monto_descontado,cd.activo,cd.cod_venta from venta_vs_cobros_detalles cd join venta v on cd.cod_venta=v.codigo where cd.activo='1' and v.codigo_cliente='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        cobroDetalle.codigo_cobro = Convert.ToInt16(row[1].ToString());
                        cobroDetalle.codigo_metodo_cobro = Convert.ToInt16(row[2].ToString());
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(row[3]);
                        cobroDetalle.monto_descontado = Convert.ToDecimal(row[4].ToString());
                        cobroDetalle.activo = Convert.ToBoolean(row[5]);
                        cobroDetalle.codigo_venta = Convert.ToInt16(row[6]);
                        lista.Add(cobroDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCobrosDetallesByVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
