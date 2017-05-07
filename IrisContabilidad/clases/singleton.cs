using System.Collections.Generic;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class singleton
    {
        //objetos
        public static singleton singletonInstance = null;
        public static empleado empleado;
        public static sistemaConfiguracion sistema;

        //listas
        public static List<mes> listaMes; 

        
        public static singleton obtenerDatos()
        {
            if (singletonInstance == null)
                singletonInstance = new singleton();

            return singletonInstance;
        }

        public static empleado getEmpleado()
        {
            if (empleado == null)
                empleado = new empleado();

            return empleado;
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
    }
}
