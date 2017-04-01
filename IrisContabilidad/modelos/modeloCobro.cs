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
        public List<venta_vs_cobros> getListaCompleta(bool mantenimiento=false)
        {
            try
            {
                List<venta_vs_cobros> lista = new List<venta_vs_cobros>();
                venta_vs_cobros cobro = new venta_vs_cobros();
                string sql ="select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from venta_vs_cobros";
                if (mantenimiento == false)
                {
                    sql += " where activo='1'";
                }
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
                lista = lista.OrderByDescending(x => x.codigo).ToList();
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
                lista = lista.OrderByDescending(x => x.codigo).ToList();
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
                lista = lista.OrderByDescending(x => x.codigo).ToList();
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

        //get venta pago by id
        public venta_vs_cobros getVentaCobroById(int codigoVentaPago)
        {
            try
            {
                venta_vs_cobros CobroDetalle = new venta_vs_cobros();
                string sql = "select codigo,fecha,detalle,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado from venta_vs_cobros where codigo='" + codigoVentaPago + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CobroDetalle = new venta_vs_cobros();
                    CobroDetalle.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    CobroDetalle.fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][1].ToString());
                    CobroDetalle.detalle = ds.Tables[0].Rows[0][2].ToString();
                    CobroDetalle.cod_empleado = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    CobroDetalle.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    CobroDetalle.cod_empleado_anular = Convert.ToInt16(ds.Tables[0].Rows[0][5].ToString());
                    CobroDetalle.motivo_anulado = ds.Tables[0].Rows[0][6].ToString();
                    CobroDetalle.cuadrado = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                }
                return CobroDetalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentaCobroById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista al completa de venta detalle by cuadre caja
        public List<venta_vs_cobros_detalles> getListaCobrosDetallesCompletaSinCuadradaBycuadreCaja(cuadre_caja cuadre)
        {
            try
            {
                List<venta_vs_cobros_detalles> lista = new List<venta_vs_cobros_detalles>();
                venta_vs_cobros_detalles cobroDetalle = new venta_vs_cobros_detalles();
                empleado empleado = new modeloEmpleado().getEmpleadoByCajeroId(cuadre.codigo_cajero);
                string sql = "select vc.codigo,vc.cod_cobro,vc.cod_metodo_cobro,vc.monto_cobrado,vc.monto_descontado,vc.activo,vc.cod_venta from venta_vs_cobros_detalles vc join venta_vs_cobros c on c.codigo=vc.cod_cobro join venta v on v.codigo=vc.cod_venta where vc.activo='1' and c.cuadrado='0' and c.activo='1' and c.fecha>='" + utilidades.getFechayyyyMMdd(cuadre.fecha) + "' and c.fecha<='" + utilidades.getFechayyyyMMdd(cuadre.fecha_cierre_cuadre) + "' and c.cod_empleado='"+empleado.codigo+"' and v.cod_sucursal='"+cuadre.codigo_sucursal+"' ";
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
                lista = lista.OrderByDescending(x => x.codigo).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCobrosDetallesCompletaSinCuadradaBycuadreCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    
    
    
    }
}
