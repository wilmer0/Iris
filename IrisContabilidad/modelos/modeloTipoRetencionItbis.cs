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
    public class modeloTipoRetencionItbis
    {
        //objetos
        utilidades utilidades = new utilidades();

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from tipo_retencion_itbis";
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
        public tipoRetencionItbis getTipoRetencionById(int id)
        {
            try
            {
                tipoRetencionItbis tipoRetencion = new tipoRetencionItbis();
                string sql = "select codigo,retencion, descripcion,porciento_retencion,activo from tipo_retencion_itbis where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipoRetencion.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    tipoRetencion.retencion = ds.Tables[0].Rows[0][1].ToString();
                    tipoRetencion.descripcion = ds.Tables[0].Rows[0][2].ToString();
                    tipoRetencion.porciento_retencion = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString());
                    tipoRetencion.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                }
                return tipoRetencion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoRetencionById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<tipoRetencionItbis> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<tipoRetencionItbis> lista = new List<tipoRetencionItbis>();
                string sql = "select codigo,retencion, descripcion,porciento_retencion,activo from tipo_retencion_itbis ";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        tipoRetencionItbis tipoRetencion = new tipoRetencionItbis();
                        tipoRetencion.codigo = Convert.ToInt16(row[0].ToString());
                        tipoRetencion.retencion = row[1].ToString();
                        tipoRetencion.descripcion = row[2].ToString();
                        tipoRetencion.porciento_retencion = Convert.ToDecimal(row[3].ToString());
                        tipoRetencion.activo = Convert.ToBoolean(row[4]);
                        lista.Add(tipoRetencion);
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
