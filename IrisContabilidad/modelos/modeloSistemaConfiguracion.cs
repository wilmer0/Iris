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
    public class modeloSistemaConfiguracion
    {

        //objetos
        utilidades utilidades=new utilidades();

        //agregar 
        public bool agregarConfiguracion(sistemaConfiguracion sistemaconfiguracion)
        {
            try
            {
                int permisosGruposUsuarios = 0;
                int emitirComprobantes = 0;
                int verImagenProductoFacturacionTouch = 0;
                int verNombreProductoFacturacionTouch = 0;
                int emitirNotasCreditoDebito = 0;
                int limitarDevolucionesVenta30Dias = 0;

                if (sistemaconfiguracion.permisosGrupo == true)
                {
                    permisosGruposUsuarios = 1;
                }
                if (sistemaconfiguracion.emitirComprobante == true)
                {
                    emitirComprobantes = 1;
                }
                if (sistemaconfiguracion.verImagenProductoFacturacionTouch == true)
                {
                    verImagenProductoFacturacionTouch = 1;
                }
                if (sistemaconfiguracion.verNombreProductoFacturacionTouch == true)
                {
                    verNombreProductoFacturacionTouch = 1;
                }
                if (sistemaconfiguracion.emitirNotasCreditoDebito == true)
                {
                    emitirNotasCreditoDebito = 1;
                }
                if (sistemaconfiguracion.limitar_devoluciones_venta_30dias == true)
                {
                    limitarDevolucionesVenta30Dias = 1;
                }

                string sql = "delete from sistema";
                utilidades.ejecutarcomando_mysql(sql);


                sql = "";
                utilidades.ejecutarcomando_mysql(sql);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public sistemaConfiguracion getSistemaConfiguracion()
        {
            try
            {
                int permisosGruposUsuarios = 0;
                int emitirComprobantes = 0;
                int verImagenProductoFacturacionTouch = 0;
                int verNombreProductoFacturacionTouch = 0;
                int emitirNotasCreditoDebito = 0;
                int limitarDevolucionesVenta30Dias = 0;

                sistemaConfiguracion sistemaConfiguracion=new sistemaConfiguracion();

                string sql = "select codigo,ruta_backup,imagen_logo_empresa,codigo_moneda,permisos_por_grupos_usuarios,autorizar_pedidos_apartir,limite_egreso_caja,emitir_comprobantes,fecha_vencimiento,ver_imagen_fact_touch,ver_nombre_fact_touch,porciento_propina,emitir_notas_credito_debito,limitar_devoluciones_venta_30dias,concepto_egreso_caja_devolucion_venta from sistema where codigo='1'";
                DataSet ds=utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    //esta lleno
                    sistemaConfiguracion.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    sistemaConfiguracion.rutaBackup = ds.Tables[0].Rows[0][1].ToString();
                    sistemaConfiguracion.imagenLogoEmpresa = ds.Tables[0].Rows[0][2].ToString();
                    sistemaConfiguracion.codigoMonedaDefault = Convert.ToInt16(ds.Tables[0].Rows[0][3]);
                    sistemaConfiguracion.permisosGrupo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    sistemaConfiguracion.codigoMonedaDefault = Convert.ToInt16(ds.Tables[0].Rows[0][5]);
                    sistemaConfiguracion.montoMaximoPedido = Convert.ToDecimal(ds.Tables[0].Rows[0][6].ToString());
                    sistemaConfiguracion.montoLimiteEgresoCaja = Convert.ToDecimal(ds.Tables[0].Rows[0][7]);
                    sistemaConfiguracion.emitirComprobante = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    sistemaConfiguracion.fechaVencimientoSistema = Convert.ToDateTime(ds.Tables[0].Rows[0][9]);
                    sistemaConfiguracion.verImagenProductoFacturacionTouch = Convert.ToBoolean(ds.Tables[0].Rows[0][10]);
                    sistemaConfiguracion.verNombreProductoFacturacionTouch = Convert.ToBoolean(ds.Tables[0].Rows[0][11]);
                    sistemaConfiguracion.porcientoPropina = Convert.ToDecimal(ds.Tables[0].Rows[0][12]);
                    sistemaConfiguracion.emitirNotasCreditoDebito = Convert.ToBoolean(ds.Tables[0].Rows[0][13]);
                    sistemaConfiguracion.limitar_devoluciones_venta_30dias = Convert.ToBoolean(ds.Tables[0].Rows[0][14]);
                    sistemaConfiguracion.codigo_concepto_egreso_caja_devolucion_venta = Convert.ToInt16(ds.Tables[0].Rows[0][15]);
                }
                else
                {
                    //esta vacio
                    sistemaConfiguracion = null;
                }

                return sistemaConfiguracion;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSistemaConfiguracion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
