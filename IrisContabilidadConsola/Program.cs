using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad;
using IrisContabilidad.modelos;
using IrisContabilidadConsola.clases;

namespace IrisContabilidadConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            agregarPrimerosDatos primerosDatos=new agregarPrimerosDatos();
            primerosDatos.primerosDatos();
            primerosDatos.agregarModulos();
            primerosDatos.agregarVentanas();
            primerosDatos.agregarPrimerEmpleado();
            primerosDatos.agregarAccesosVentanas();
        }
    }
}
