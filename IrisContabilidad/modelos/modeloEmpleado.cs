using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using empleado = IrisContabilidad.clases.empleado;

namespace IrisContabilidad.modelos
{
    internal class modeloEmpleado
    {
        //objetos
        private utilidades utilidades = new utilidades();
        private empleado empleado;




        private Boolean validarLogin(string usuario, string clave)
        {
            try
            {

                //hacer select de usuario y clave
                string sql = "";
                sql = "select *from empleado where login='" + usuario + "' and clave='" + clave + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error validarLogin.: " + ex.ToString());
                return false;
            }
        }




        private List<string> GetListaModulosByEmpleado(empleado empleado)
        {
            try
            {
                //listas
                List<string> listaModulos = new List<string>();

                string sql = "";
                sql = "SELECT id_ventana_sistema FROM empleado_accesos_ventanas ev where  ev.id_empleado ='" +
                      empleado.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (var x in ds.Tables[0].Rows)
                {
                    //hacer select para saber a que modulo pertenece esa ventana
                    string sql2 = "";
                    sql2 = "SELECT id_modulo FROM modulos_vs_ventanas  where id_ventana='" + x.ToString() + "'";
                    listaModulos.Add(x.ToString());
                }
                foreach (var x in listaModulos)
                {
                    MessageBox.Show("modulos normal-->" + x.ToString());
                }
                listaModulos = listaModulos.Distinct().ToList();
                foreach (var x in listaModulos)
                {
                    MessageBox.Show("modulos limpio-->" + x.ToString());
                }

                return listaModulos;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetListaModulosByEmpleado.: " + ex.ToString());
                return null;
            }
        }

        private List<empleado> getListaCompleta()
        {
            try
            {
                List<empleado> listaEmpleado = new List<empleado>();
                string sql =
                    "select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_gripo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado where activo='1'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clases.empleado empleado = new empleado();
                    empleado.codigo = (int) row[0];
                    empleado.nombre = row[1].ToString();
                    empleado.login = row[2].ToString();
                    empleado.clave = row[3].ToString();
                    empleado.sueldo = (decimal) row[4];
                    empleado.codigo_situacion = (int) row[5];
                    empleado.activo = (bool) row[6];
                    empleado.codigo_sucursal = (int) row[7];
                    empleado.codigo_departamento = (int) row[8];
                    empleado.codigo_cargo = (int) row[9];
                    empleado.codigo_grupo_usuario = (int) row[10];
                    empleado.fecha_ingreso = (DateTime) row[11];
                    empleado.tipo_permiso = row[12].ToString();
                    empleado.codigo_tipo_nomina = (int) row[13];
                    empleado.identificacion = row[14].ToString();
                    empleado.pasaporte = row[15].ToString();

                    listaEmpleado.Add(empleado);
                }
                return listaEmpleado;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error getListaCompleta.: " + ex.ToString());
                return null;
            }
        }

        public empleado getEmpleadoByLogin(empleado empleado1)
        {
            try
            {
                clases.empleado empleado = new empleado();
                List<empleado> listaEmpleado = new List<empleado>();
                string sql ="select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_gripo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado where login='"+empleado1.login+"' and clave='"+empleado1.clave+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    empleado.codigo = (int)row[0];
                    empleado.nombre = row[1].ToString();
                    empleado.login = row[2].ToString();
                    empleado.clave = row[3].ToString();
                    empleado.sueldo = (decimal)row[4];
                    empleado.codigo_situacion = (int)row[5];
                    empleado.activo = (bool)row[6];
                    empleado.codigo_sucursal = (int)row[7];
                    empleado.codigo_departamento = (int)row[8];
                    empleado.codigo_cargo = (int)row[9];
                    empleado.codigo_grupo_usuario = (int)row[10];
                    empleado.fecha_ingreso = (DateTime)row[11];
                    empleado.tipo_permiso = row[12].ToString();
                    empleado.codigo_tipo_nomina = (int)row[13];
                    empleado.identificacion = row[14].ToString();
                    empleado.pasaporte = row[15].ToString();
                   
                }
                return empleado;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error getEmpleadoByLogin.: " + ex.ToString());
                return null;
            }
        }
    }
}
