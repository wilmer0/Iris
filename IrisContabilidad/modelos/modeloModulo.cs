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
    public class modeloModulo
    {
        //objetos
        utilidades utilidades = new utilidades();


        public modulo getModuloByid(int id)
        {
            try
            {
                modulo modulo=new modulo();
                string sql = "select id,nombre,activo,imagen from sistema_modulo where id='" + id.ToString() + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    modulo.id = (int)ds.Tables[0].Rows[0][0];
                    modulo.nombre = ds.Tables[0].Rows[0][1].ToString();
                    modulo.activo = (bool)ds.Tables[0].Rows[0][2];
                    modulo.imagen = ds.Tables[0].Rows[0][3].ToString();
                }

                return modulo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getModuloByid.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<string> getVentanasByModuloId(int id)
        {
            try
            {
                List<string> listaVentanas=new List<string>();
                ventana ventana=new ventana();
                string sql = "SELECT id_modulo,id_ventana FROM modulos_vs_ventanas where id_modulo='" + id.ToString() + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventana.codigo = (int) row[1];
                        listaVentanas.Add(row[1].ToString());
                    }
                }

                return listaVentanas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentanasByModuloId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public ventana getVentanaById(int id)
        {
            try
            {
                ventana ventana = new ventana();
                string sql = "SELECT codigo,nombre_ventana,nombre_logico,imagen,activo,programador FROM sistema_ventanas s where codigo ='" + id.ToString() + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ventana.codigo = (int)ds.Tables[0].Rows[0][0];
                    ventana.nombre_ventana = ds.Tables[0].Rows[0][1].ToString();
                    ventana.nombre_logico = ds.Tables[0].Rows[0][2].ToString();
                    ventana.imagen = ds.Tables[0].Rows[0][3].ToString();
                    ventana.activo = (bool) ds.Tables[0].Rows[0][4];
                    ventana.programador = (bool)ds.Tables[0].Rows[0][5];
                }

                return ventana;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentanaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
