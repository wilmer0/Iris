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
    public class modeloTipoVentana
    {

        //objetos 
        private utilidades utilidades = new utilidades();



        //get objeto by id
        public tipoVentana getTipoVentanaById(int id)
        {
            try
            {
                tipoVentana tipoVentana = new tipoVentana();
                string sql = "SELECT codigo,nombre,tamano_ancho,tamano_alto,tamano_separacion,tamano_letra FROM tipo_ventana where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipoVentana.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    tipoVentana.nombre = ds.Tables[0].Rows[0][1].ToString();
                    tipoVentana.tamanoAncho = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    tipoVentana.tamanoAlto = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    tipoVentana.tamanoSeparacion = Convert.ToInt16(ds.Tables[0].Rows[0][4].ToString());
                    tipoVentana.tamanoLeta = Convert.ToInt16(ds.Tables[0].Rows[0][5].ToString());
                }

                return tipoVentana;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoVentanaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get objeto by nombre
        public tipoVentana getTipoVentanaByNombre(string nombre)
        {
            try
            {
                tipoVentana tipoVentana = new tipoVentana();
                string sql = "SELECT codigo,nombre,tamano_ancho,tamano_alto,tamano_separacion,tamano_letra FROM tipo_ventana where nombre='" + nombre + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipoVentana.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    tipoVentana.nombre = ds.Tables[0].Rows[0][1].ToString();
                    tipoVentana.tamanoAncho = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    tipoVentana.tamanoAlto = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    tipoVentana.tamanoSeparacion = Convert.ToInt16(ds.Tables[0].Rows[0][4].ToString());
                    tipoVentana.tamanoLeta = Convert.ToInt16(ds.Tables[0].Rows[0][5].ToString());
                }

                return tipoVentana;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoVentanaByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
