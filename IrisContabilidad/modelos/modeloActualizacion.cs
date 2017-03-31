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
        private empleado empleado;
        singleton singleton=new singleton();
        private sucursal sucursal;
        modeloSucursal modeloSucursal=new modeloSucursal();


        public void getSucursalVersion()
        {
            try
            {
                empleado = new empleado();
                empleado = singleton.getEmpleado();
                sucursal = new sucursal();
                sucursal = new modeloSucursal().getSucursalById(empleado.codigo);
                if (sucursal == null)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSucursalVersion.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        public bool actualizar()
        {
            try
            {
                getSucursalVersion();

                if (sucursal == null)
                {
                    MessageBox.Show("Sucursal esta llegando nulo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //si la version actual es menor que la 1 actualizala a la 1
                if (sucursal.versionSistema <1)
                {
                    version1(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizar.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void version1(bool mostrarErrores=true)
        {
            try
            {
                string sql = "";

                #region querys version1
                //nuevo query
                sql = "ALTER TABLE `iris`.`sucursal` ADD COLUMN `version_sistema` INTEGER NOT NULL DEFAULT 0 AFTER `fax`;";
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

                //actualizar la version de la sucursal
                sucursal.versionSistema = 1;
                modeloSucursal.modificarSucursal(sucursal);
                
            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
