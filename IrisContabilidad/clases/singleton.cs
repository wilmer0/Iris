using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class singleton
    {
        //objetos
        public static singleton singletonInstance = null;
        public static empleado empleado;

        
        
        
        
        
        
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











    }
}
