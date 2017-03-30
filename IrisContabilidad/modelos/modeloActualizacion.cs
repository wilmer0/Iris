using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IrisContabilidad.clases;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IrisContabilidad.modelos
{
    public class modeloActualizacion
    {

        //objetos
        utilidades utilidades=new utilidades();

        public void version1(bool mostrarErrores=true)
        {
            try
            {
                string sql = "";

                #region querys version1
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);

                #endregion


                //listaQuerys.ForEach(x =>
                //{
                //    utilidades.ejecutarcomando_mysql(x);
                //});
            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void version1_1_0()
        {
            try
            {
                string sql = "";
                //List<string> listaQuerys = new List<string>();

                #region querys version1
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "";
                utilidades.ejecutarcomando_mysql(sql);
                #endregion


                //listaQuerys.ForEach(x =>
                //{
                //    utilidades.ejecutarcomando_mysql(x);
                //});
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       

    }
}
