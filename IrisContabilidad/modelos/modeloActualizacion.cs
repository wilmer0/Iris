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
                sql = "CREATE TABLE `iris`.`cuadre_caja_transacciones` ( `codigo_cuadre_caja` INTEGER NOT NULL DEFAULT 0, `codigo_venta` INTEGER NOT NULL DEFAULT 0, `codigo_cobro` INTEGER NOT NULL DEFAULT 0, `codigo_ingreso_caja` INTEGER NOT NULL DEFAULT 0, `codigo_egreso_caja` VARCHAR(45) NOT NULL DEFAULT '', `codigo_nota_credito` INTEGER NOT NULL DEFAULT 0, `codigo_nota_debito` INTEGER NOT NULL DEFAULT 0, `codigo_gasto` INTEGER NOT NULL DEFAULT 0, `codigo_pago` INTEGER NOT NULL DEFAULT 0, PRIMARY KEY(`codigo_cuadre_caja`, `codigo_venta`, `codigo_cobro`, `codigo_ingreso_caja`, `codigo_egreso_caja`, `codigo_nota_credito`, `codigo_nota_debito`, `codigo_gasto`, `codigo_pago`)";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_notas_debito` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_faltante`, ADD COLUMN `monto_notas_credito` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_notas_debito`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`compra` ADD COLUMN `cuadrado` BOOLEAN NOT NULL DEFAULT 0 AFTER `suplidor_informal`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja` ADD COLUMN `fecha_cierre_cuadre` DATE NOT NULL DEFAULT 0 AFTER `caja_abierta`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`gastos` ADD COLUMN `cuadrado` BOOLEAN NOT NULL DEFAULT 0 AFTER `activo`;";
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
