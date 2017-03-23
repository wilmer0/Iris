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
                string sql = "select codigo,tamano_modulo_ancho,tamano_modulo_alto,tamano_separacion,tamano_modulo_letra,nombre,tamano_ventana_ancho,tamano_ventana_alto,tamano_ventana_letra from tipo_ventana where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipoVentana.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    tipoVentana.tamanoModuloAncho = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    tipoVentana.tamanoModuloAlto = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    tipoVentana.tamanoSeparacion = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    tipoVentana.tamanoModuloLetra = Convert.ToInt16(ds.Tables[0].Rows[0][4].ToString());
                    tipoVentana.nombre = ds.Tables[0].Rows[0][5].ToString();
                    tipoVentana.tamanoVentanaAncho = Convert.ToInt16(ds.Tables[0].Rows[0][6].ToString());
                    tipoVentana.tamanoVentanaAlto = Convert.ToInt16(ds.Tables[0].Rows[0][7].ToString());
                    tipoVentana.tamanoVentanaLetra = Convert.ToInt16(ds.Tables[0].Rows[0][8].ToString());
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
                string sql = "select codigo,tamano_modulo_ancho,tamano_modulo_alto,tamano_separacion,tamano_modulo_letra,nombre," +
                             "tamano_ventana_ancho,tamano_ventana_alto,tamano_ventana_letra from tipo_ventana where nombre='" + nombre + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipoVentana.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    tipoVentana.tamanoModuloAncho = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    tipoVentana.tamanoModuloAlto = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    tipoVentana.tamanoSeparacion = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    tipoVentana.tamanoModuloLetra = Convert.ToInt16(ds.Tables[0].Rows[0][4].ToString());
                    tipoVentana.nombre = ds.Tables[0].Rows[0][5].ToString();
                    tipoVentana.tamanoVentanaAncho = Convert.ToInt16(ds.Tables[0].Rows[0][6].ToString());
                    tipoVentana.tamanoVentanaAlto = Convert.ToInt16(ds.Tables[0].Rows[0][7].ToString());
                    tipoVentana.tamanoVentanaLetra = Convert.ToInt16(ds.Tables[0].Rows[0][8].ToString());
                }

                return tipoVentana;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoVentanaByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista objeto 
        public List<tipoVentana> getListaCompleta()
        {
            try
            {
                tipoVentana tipoVentana=new tipoVentana();
                List<tipoVentana> lista = new List<tipoVentana>();
                string sql = "select codigo,tamano_modulo_ancho,tamano_modulo_alto,tamano_separacion,tamano_modulo_letra,nombre,tamano_ventana_ancho,tamano_ventana_alto,tamano_ventana_letra from tipo_ventana";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        tipoVentana = new tipoVentana();
                        tipoVentana.codigo = Convert.ToInt16(row[0]);
                        tipoVentana.tamanoModuloAncho = Convert.ToInt16(row[1]);
                        tipoVentana.tamanoModuloAlto = Convert.ToInt16(row[2]);
                        tipoVentana.tamanoSeparacion = Convert.ToInt16(row[3]);
                        tipoVentana.tamanoModuloLetra = Convert.ToInt16(row[4]);
                        tipoVentana.nombre = row[5].ToString();
                        tipoVentana.tamanoVentanaAncho = Convert.ToInt16(row[6]);
                        tipoVentana.tamanoVentanaAlto = Convert.ToInt16(row[7]);
                        tipoVentana.tamanoVentanaLetra = Convert.ToInt16(row[8]);
                    
                        lista.Add(tipoVentana);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoVentangetListaCompletaaByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
