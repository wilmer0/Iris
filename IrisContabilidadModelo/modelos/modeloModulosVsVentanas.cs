using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidadModelo.modelos
{
    public class modeloModulosVsVentanas
    {

        public List<modulos_vs_ventanas> getListaCompleta()
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();

                var lista = (from c in entity.modulos_vs_ventanas
                             select c).ToList();


                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaCompleta.: " + ex.ToString());
                return null;
            }
        }

    }
}
