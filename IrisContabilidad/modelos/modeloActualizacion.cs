using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloActualizacion
    {

        //objetos
        utilidades utilidades=new utilidades();

        public void version1()
        {
            try
            {
                string sql = "";
                List<string> listaQuerys=new List<string>();

                #region querys version1
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                #endregion


                listaQuerys.ForEach(x =>
                {
                    utilidades.ejecutarcomando_mysql(x);
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void version1_1_0()
        {
            try
            {
                string sql = "";
                List<string> listaQuerys = new List<string>();

                #region querys version1
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                #endregion


                listaQuerys.ForEach(x =>
                {
                    utilidades.ejecutarcomando_mysql(x);
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void version1_2_0()
        {
            try
            {
                string sql = "";
                List<string> listaQuerys = new List<string>();

                #region querys version1
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                #endregion


                listaQuerys.ForEach(x =>
                {
                    utilidades.ejecutarcomando_mysql(x);
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
