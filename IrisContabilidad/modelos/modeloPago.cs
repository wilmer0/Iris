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
    public class modeloPago
    {
        private utilidades utilidades = new utilidades();

        //get lista pagos todos
        public List<compra_vs_pagos> getListaCompletaPagos()
        {
            try
            {
                List<compra_vs_pagos> lista = new List<compra_vs_pagos>();
                compra_vs_pagos pago = new compra_vs_pagos();
                string sql = "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from compra_vs_pagos where activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        pago = new compra_vs_pagos();
                        pago.codigo = Convert.ToInt16(row[0].ToString());
                        pago.fecha = Convert.ToDateTime(row[1].ToString());
                        pago.cod_empleado = Convert.ToInt16(row[2].ToString());
                        pago.activo = Convert.ToBoolean(row[3]);
                        pago.cod_empleado_anular = Convert.ToInt16(row[4].ToString());
                        pago.motivo_anulado = row[5].ToString();
                        pago.cuadrado = Convert.ToBoolean(row[6]);
                        pago.detalle = row[7].ToString();
                        lista.Add(pago);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaPagos.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista pagos todos
        public List<compra_vs_pagos> getListaCompletaPagosNoCuadrados()
        {
            try
            {
                List<compra_vs_pagos> lista = new List<compra_vs_pagos>();
                compra_vs_pagos pago = new compra_vs_pagos();
                string sql = "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from compra_vs_pagos where activo='1' and cuadrado='0'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        pago = new compra_vs_pagos();
                        pago.codigo = Convert.ToInt16(row[0].ToString());
                        pago.fecha = Convert.ToDateTime(row[1].ToString());
                        pago.cod_empleado = Convert.ToInt16(row[2].ToString());
                        pago.activo = Convert.ToBoolean(row[3]);
                        pago.cod_empleado_anular = Convert.ToInt16(row[4].ToString());
                        pago.motivo_anulado = row[5].ToString();
                        pago.cuadrado = Convert.ToBoolean(row[6]);
                        pago.detalle = row[7].ToString();
                        lista.Add(pago);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaPagosNoCuadrados.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista pagos no cuadrados by suplidor id
        public List<compra_vs_pagos> getListaCompletaPagosNoCuadradosBySuplidorId()
        {
            try
            {
                List<compra_vs_pagos> lista = new List<compra_vs_pagos>();
                compra_vs_pagos pago = new compra_vs_pagos();
                string sql = "select codigo,fecha,cod_empleado,activo,cod_empleado_anular,motivo_anulado,cuadrado,detalle from compra_vs_pagos where activo='1' and cuadrado='0'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        pago = new compra_vs_pagos();
                        pago.codigo = Convert.ToInt16(row[0].ToString());
                        pago.fecha = Convert.ToDateTime(row[1].ToString());
                        pago.cod_empleado = Convert.ToInt16(row[2].ToString());
                        pago.activo = Convert.ToBoolean(row[3]);
                        pago.cod_empleado_anular = Convert.ToInt16(row[4].ToString());
                        pago.motivo_anulado = row[5].ToString();
                        pago.cuadrado = Convert.ToBoolean(row[6]);
                        pago.detalle = row[7].ToString();
                        lista.Add(pago);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompletaPagosNoCuadradosBySuplidorId.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista pagos activo detalle by suplidor
        public List<compra_vs_pagos_detalles> getListaPagosDetallesActivosBySuplidorId(int id)
        {
            try
            {
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                compra_vs_pagos_detalles cobroDetalle = new compra_vs_pagos_detalles();
                string sql = "select cd.codigo,cd.cod_pago,cd.cod_metodo_pago,cd.monto_pagado,cd.monto_descontado,cd.activo,cd.cod_compra from compra_vs_pagos_detalles cd join compra c on cd.cod_compra=c.codigo where cd.activo='1' and c.cod_suplidor='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobroDetalle = new compra_vs_pagos_detalles();
                        cobroDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        cobroDetalle.codigo_compra = Convert.ToInt16(row[1].ToString());
                        cobroDetalle.codigo_metodo_pago = Convert.ToInt16(row[2].ToString());
                        cobroDetalle.monto_pagado = Convert.ToDecimal(row[3]);
                        cobroDetalle.monto_descontado = Convert.ToDecimal(row[4].ToString());
                        cobroDetalle.activo = Convert.ToBoolean(row[5]);
                        cobroDetalle.codigo_compra = Convert.ToInt16(row[6]);
                        lista.Add(cobroDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaPagosDetallesActivosBySuplidorId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa pagos activo detalle activo
        public List<compra_vs_pagos_detalles> getListaCompraPagosDetallesActivos()
        {
            try
            {
                List<compra_vs_pagos_detalles> lista = new List<compra_vs_pagos_detalles>();
                compra_vs_pagos_detalles cobroDetalle = new compra_vs_pagos_detalles();
                string sql = "select cd.codigo,cd.cod_pago,cd.cod_metodo_pago,cd.monto_pagado,cd.monto_descontado,cd.activo,cd.cod_compra from compra_vs_pagos_detalles cd join compra c on cd.cod_compra=c.codigo where cd.activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cobroDetalle = new compra_vs_pagos_detalles();
                        cobroDetalle.codigo = Convert.ToInt16(row[0].ToString());
                        cobroDetalle.codigo_compra = Convert.ToInt16(row[1].ToString());
                        cobroDetalle.codigo_metodo_pago = Convert.ToInt16(row[2].ToString());
                        cobroDetalle.monto_pagado = Convert.ToDecimal(row[3]);
                        cobroDetalle.monto_descontado = Convert.ToDecimal(row[4].ToString());
                        cobroDetalle.activo = Convert.ToBoolean(row[5]);
                        cobroDetalle.codigo_compra = Convert.ToInt16(row[6]);
                        lista.Add(cobroDetalle);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompraPagosDetallesActivos.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
