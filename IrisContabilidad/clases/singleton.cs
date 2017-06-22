using System;
using System.Collections.Generic;
using System.Windows;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class singleton
    {
        //objetos
        #region objetos
        public static singleton singletonInstance = null;
        public static empleado empleado;
        public static sistemaConfiguracion sistema;
        public static Object idioma;
        #endregion

        //idiomas
        #region idiomas
        private static idiomas.Es_do idiomaEsDo=new idiomas.Es_do();
        private static idiomas.En_us idiomaEnUs=new idiomas.En_us();
        #endregion

        //listas
        #region listas
        public static List<mes> listaMes;
        #endregion


        public static empleado getEmpleado()
        {
            if (empleado == null)
            {
                empleado = new empleado();
                GetIdioma();
            }
            return empleado;
        }

        public static singleton obtenerDatos()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new singleton();
            }
            return singletonInstance;
        }

        public static sistemaConfiguracion getSistemaconfiguracion()
        {
            if (sistema == null)
                sistema=new sistemaConfiguracion();


                return sistema;
        }

        public static List<mes> obtenerListaMes()
        {
            if (listaMes == null)
            {
                listaMes = new List<mes>();
                listaMes = new modeloMes().getListaCompleta();
            }
            return listaMes;
        }

        public static void GetIdioma()
        {
            try
            {
                if (idioma == null)
                {
                    idioma = new ResourceDictionary();
                    singleton singleton = new singleton();
                    singleton.sistema = new modeloSistemaConfiguracion().getSistemaConfiguracion();
                    if (singleton.sistema.codigoIdiomaSistema == 1)
                    {
                        //es
                        idioma = idiomaEsDo;
                    }
                    else if (singleton.sistema.codigoIdiomaSistema == 2)
                    {
                        //usa
                        idioma = idiomaEnUs;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getIdioma.: " + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
