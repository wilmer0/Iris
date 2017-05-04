using System;
using System.Collections.Generic;
using System.Data;
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
                if (empleado == null)
                {
                    empleado = new modeloEmpleado().getEmpleadoById(1);
                }
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

        public bool actualizar(sucursal sucursalParametro=null)
        {
            try
            {
                if (sucursalParametro == null)
                {
                    getSucursalVersion();
                }
                else
                {
                    sucursal = sucursalParametro;
                }


                if (sucursal == null)
                {
                    MessageBox.Show("Sucursal esta llegando nulo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //actualizaciones
                #region
                if (sucursal.versionSistema == 0)
                {
                    version1(true);
                    
                }else if (sucursal.versionSistema == 1)
                {
                    version2(true);

                }else if (sucursal.versionSistema == 2)
                {
                    //version3(true);
                }
                else if (sucursal.versionSistema == 3)
                {
                    //version4(true);
                }
                else if (sucursal.versionSistema == 4)
                {
                    //version5(true);
                }
                else if (sucursal.versionSistema == 5)
                {
                    //version6(true);
                }
                else if (sucursal.versionSistema == 6)
                {
                    //version7(true);
                }
                else if (sucursal.versionSistema == 7)
                {
                    //version8(true);
                }
                else if (sucursal.versionSistema == 8)
                {
                    //version9(true);
                }
                else if (sucursal.versionSistema == 9)
                {
                    //version10(true);
                }
                else if (sucursal.versionSistema == 10)
                {
                    //version11(true);
                }
                else if (sucursal.versionSistema == 11)
                {
                    //version12(true);
                }
                else if (sucursal.versionSistema == 12)
                {
                    //version13(true);
                }
                else if (sucursal.versionSistema == 13)
                {
                    //version14(true);
                }
                else if (sucursal.versionSistema == 14)
                {
                    //version15(true);
                }
                else if (sucursal.versionSistema == 15)
                {
                    //version16(true);
                }
                else if (sucursal.versionSistema == 16)
                {
                    //version17(true);
                }
                else if (sucursal.versionSistema == 17)
                {
                    //version18(true);
                }
                else if (sucursal.versionSistema == 18)
                {
                    //version19(true);
                }
                else if (sucursal.versionSistema == 19)
                {
                    //version20(true);
                }
                else if (sucursal.versionSistema == 20)
                {
                    //version21(true);
                }

                #endregion



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
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_cotizacion` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_notas_credito`, ADD COLUMN `monto_pedido` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_cotizacion`; ";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cxc_nota_credito` ADD COLUMN `cuadrado` BOOLEAN NOT NULL DEFAULT 0 AFTER `codigo_devolucion`, ADD COLUMN `contabilizado` BOOLEAN NOT NULL DEFAULT 0 AFTER `cuadrado`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cxc_nota_debito` ADD COLUMN `cuadrado` BOOLEAN NOT NULL DEFAULT 0 AFTER `codigo_concepto`, ADD COLUMN `contabilizado` BOOLEAN NOT NULL DEFAULT 0 AFTER `cuadrado`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`compra_vs_pagos_detalles` MODIFY COLUMN `activo` TINYINT(3) NOT NULL DEFAULT 1, ADD COLUMN `monto_subtotal` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `activo`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`venta_vs_cobros_detalles` ADD COLUMN `monto_subtotal` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `cod_venta`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`venta_vs_cobros_detalles` MODIFY COLUMN `monto_cobrado` DECIMAL(20,2) NOT NULL DEFAULT 0.00 COMMENT 'es el monto simbolico que cobro monto + descuento', MODIFY COLUMN `monto_descontado` DECIMAL(20,2) NOT NULL DEFAULT 0.00 COMMENT 'es el monto descontado en ese cobro', MODIFY COLUMN `monto_subtotal` DECIMAL(20,2) NOT NULL DEFAULT 0.00 COMMENT 'es el dinero que sale de la empresa, seria monto - descuento';";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cxp_nota_debito` ADD COLUMN `codigo_compra` INTEGER NOT NULL DEFAULT 0 AFTER `detalle`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cxp_nota_debito` ADD COLUMN `codigo_concepto` INTEGER NOT NULL DEFAULT 0 AFTER `codigo_compra`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cxp_nota_debito` ADD COLUMN `numero_nota` VARCHAR(99) NOT NULL DEFAULT '' COMMENT 'este es el numero de nota que me da el suplidor' AFTER `codigo_concepto` , AUTO_INCREMENT = 1;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "CREATE TABLE `iris`.`computadoras` ( `codigo` INTEGER NOT NULL AUTO_INCREMENT, `nombre_computadora` VARCHAR(999) NOT NULL DEFAULT '', `ip` VARCHAR(20) NOT NULL DEFAULT '', `mascara` VARCHAR(99), PRIMARY KEY(`codigo`) ) ENGINE = InnoDB;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_transacciones` MODIFY COLUMN `codigo_venta` INTEGER, MODIFY COLUMN `codigo_cobro` INTEGER, MODIFY COLUMN `codigo_ingreso_caja` INTEGER, MODIFY COLUMN `codigo_egreso_caja` VARCHAR(45) CHARACTER SET utf8 COLLATE utf8_general_ci, MODIFY COLUMN `codigo_nota_credito` INTEGER, MODIFY COLUMN `codigo_nota_debito` INTEGER, MODIFY COLUMN `codigo_gasto` INTEGER, MODIFY COLUMN `codigo_pago` INTEGER;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`producto_unidad_conversion` MODIFY COLUMN `cantidad` DECIMAL(20,2) NOT NULL DEFAULT 1.00, MODIFY COLUMN `precio_venta1` DECIMAL(20,2) NOT NULL DEFAULT 0.00, MODIFY COLUMN `costo` DECIMAL(20,2) NOT NULL DEFAULT 0.00;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sucursal` ADD COLUMN `version_sistema_maxima` INTEGER NOT NULL DEFAULT 0 AFTER `version_sistema`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sucursal` MODIFY COLUMN `version_sistema_maxima` INTEGER NOT NULL DEFAULT 50;";
                utilidades.ejecutarcomando_mysql(sql);


                #endregion

                //actualizar la version de la sucursal
                sucursal.versionSistema = 1;
                sucursal.versionSistemaMaxima = 2;
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

        private void version2(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version2
               
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_venta_contado` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_pedido`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_efectivo_apertura_caja` DECIMAL(20,2) NOT NULL DEFAULT 0 AFTER `monto_venta_contado`;";
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
                sucursal.versionSistema = 2;
                sucursal.versionSistemaMaxima = 3;
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
