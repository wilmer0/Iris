using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloModulo
    {
        //objetos
        utilidades utilidades = new utilidades();


        public cargo getModuloByid(modulo)
        {
            try
            {
                cargo cargo = new cargo();
                string sql = "select id,nombre,activo from cargo where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cargo.id = (int)ds.Tables[0].Rows[0][0];
                    cargo.nombre = ds.Tables[0].Rows[0][1].ToString();
                    cargo.activo = (int)ds.Tables[0].Rows[0][2];
                }

                return cargo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCargoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }





    }
}
