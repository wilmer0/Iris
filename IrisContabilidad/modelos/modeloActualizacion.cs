using System;
using System.Windows.Forms;
using IrisContabilidad.clases;

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
        private sistemaConfiguracion sistemaConfiguracion;


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
                    version3(true);
                }
                else if (sucursal.versionSistema == 3)
                {
                    version4(true);
                }
                else if (sucursal.versionSistema == 4)
                {
                    version5(true);
                }
                else if (sucursal.versionSistema == 5)
                {
                    version6(true);
                }
                else if (sucursal.versionSistema == 6)
                {
                    version7(true);
                }
                else if (sucursal.versionSistema == 7)
                {
                    version8(true);
                }
                else if (sucursal.versionSistema == 8)
                {
                    version9(true);
                }
                else if (sucursal.versionSistema == 9)
                {
                    version10(true);
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
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_pagos_efectivo` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_efectivo_apertura_caja`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_efectivo_recibido_cajero` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_pagos_efectivo`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_cobro_efectivo` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_efectivo_recibido_cajero`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_venta_efectivo` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_cobro_efectivo`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`venta` ADD COLUMN `monto_impuesto` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `cod_tipo_comprobante`, ADD COLUMN `pedido` BOOLEAN NOT NULL DEFAULT 0 AFTER `monto_impuesto`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` CHANGE COLUMN `monto_efectivo` `monto_efectivo_esperado` DECIMAL(20,2) NOT NULL DEFAULT 0.00;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into metodo_pago(codigo,metodo,descripcion,activo) values('4','tarjeta','cuando se recive dinero en base a tarjeta','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_cobro_deposito` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_venta_efectivo`, ADD COLUMN `monto_cobro_cheque` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_cobro_deposito`, ADD COLUMN `monto_cobro_tarjeta` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_cobro_cheque`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` CHANGE COLUMN `monto_cobro_deposito` `monto_cobro_deposito_efectivo` DECIMAL(20,2) NOT NULL DEFAULT 0.00, CHANGE COLUMN `monto_cobro_cheque` `monto_cobro_cheque_efectivo` DECIMAL(20,2) NOT NULL DEFAULT 0.00, CHANGE COLUMN `monto_cobro_tarjeta` `monto_cobro_tarjeta_efectivo` DECIMAL(20,2) NOT NULL DEFAULT 0.00;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` CHANGE COLUMN `monto_cobro_deposito_efectivo` `monto_cobro_deposito` DECIMAL(20,2) NOT NULL DEFAULT 0.00, CHANGE COLUMN `monto_cobro_cheque_efectivo` `monto_cobro_cheque` DECIMAL(20,2) NOT NULL DEFAULT 0.00, CHANGE COLUMN `monto_cobro_tarjeta_efectivo` `monto_cobro_tarjeta` DECIMAL(20,2) NOT NULL DEFAULT 0.00;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` CHANGE COLUMN `monto_cotizacion` `monto_venta_cotizacion` DECIMAL(20,2) NOT NULL DEFAULT 0.00, CHANGE COLUMN `monto_pedido` `monto_venta_pedido` DECIMAL(20,2) NOT NULL DEFAULT 0.00;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` DROP COLUMN `monto_tarjeta`, DROP COLUMN `monto_cheque`, DROP COLUMN `monto_deposito`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`cuadre_caja_detalles` ADD COLUMN `monto_venta_credito` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_cobro_tarjeta`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`catalogo_cuentas` CHANGE COLUMN `cuenta_superior` `codigo_cuenta_superior` INTEGER NOT NULL DEFAULT 0 COMMENT 'para saber a que cuenta pertenece esta';";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "CREATE TABLE `iris`.`notas_programador` (`notas` LONGTEXT)ENGINE = InnoDB;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_debito,origen_credito,activo) values('1','ACTIVOS','1','1','1','0','0','1','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_debito,origen_credito,activo) values('2','PASIVOS','2','2','1','0','1','0','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_debito,origen_credito,activo) values('3','CAPITAL','3','3','1','0','1','0','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_debito,origen_credito,activo) values('4','INGRESOS','4','4','1','0','0','1','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_debito,origen_credito,activo) values('5','COSTOS','5','5','1','0','1','1','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_debito,origen_credito,activo) values('6','GASTOS','6','6','1','0','1','1','1');";
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
                    MessageBox.Show("Error version2.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version3(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version3
                //nuevo query
                sql = "CREATE TABLE `iris`.`diario_general` ( `codigo` INTEGER NOT NULL DEFAULT 0, `fecha_sistema` DATETIME NOT NULL DEFAULT 0, `fecha` DATE NOT NULL DEFAULT 0, `codigo_cuenta` INTEGER NOT NULL DEFAULT 0, `debito` DECIMAL(20,2) NOT NULL DEFAULT 0, `credito` DECIMAL(20,2) NOT NULL DEFAULT 0, `codigo_usuario` INTEGER NOT NULL DEFAULT 0, PRIMARY KEY(`codigo`) ) ENGINE = InnoDB;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`diario_general` CHARACTER SET Default COLLATE utf8_bin;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`diario_general` CHANGE COLUMN `codigo_cuenta` `codigo_cuenta_contable` INTEGER NOT NULL DEFAULT 0, CHANGE COLUMN `codigo_usuario` `codigo_empleado` INTEGER NOT NULL DEFAULT 0, ADD CONSTRAINT `FK_diario_general_1` FOREIGN KEY `FK_diario_general_1` (`codigo_cuenta_contable`) REFERENCES `catalogo_cuentas` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT, ADD CONSTRAINT `FK_diario_general_2` FOREIGN KEY `FK_diario_general_2` (`codigo_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE RESTRICT";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`diario_general` ADD COLUMN `codigo_asiento` INTEGER NOT NULL DEFAULT 0 AFTER `codigo`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`diario_general` DROP PRIMARY KEY;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`diario_general` ADD PRIMARY KEY(`codigo`, `codigo_asiento`);";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`catalogo_cuentas` ADD COLUMN `origen_cuenta` VARCHAR(99) NOT NULL DEFAULT '' AFTER `activo`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "CREATE TABLE `iris`.`parametrizacion_contable` ( `codigo_cuenta_caja_efectivo` INTEGER, `codigo_cuenta_compras` INTEGER, `codigo_cuenta_suplidores` INTEGER, `codigo_cuenta_gastos` INTEGER, `codigo_cuenta_pago_suplidores` INTEGER NOT NULL DEFAULT 0, `codigo_cuenta_ingreso_cobros_venta` INTEGER NOT NULL DEFAULT 0, `codigo_cuenta_itbis` INTEGER NOT NULL DEFAULT 0, `codigo_cuenta_flete` INTEGER NOT NULL DEFAULT 0 ) ENGINE = InnoDB;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` ADD COLUMN `codigo_idioma_sistema` INTEGER NOT NULL DEFAULT 0 AFTER `concepto_egreso_caja_devolucion_venta`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "CREATE TABLE `iris`.`idiomas` ( `codigo` INTEGER UNSIGNED NOT NULL DEFAULT 0, `idioma` VARCHAR(99) NOT NULL DEFAULT '', PRIMARY KEY(`codigo`) ) ENGINE = InnoDB;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into idiomas(codigo,idioma) values('1','español');insert into idiomas(codigo,idioma) values('2','english');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` MODIFY COLUMN `codigo_idioma_sistema` INTEGER NOT NULL DEFAULT 1;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` ADD COLUMN `codigo_numero_comprobante_fiscal_defecto_ventas` INTEGER NOT NULL DEFAULT 1 AFTER `codigo_idioma_sistema`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` ADD COLUMN `tipo_venta_defecto` INTEGER NOT NULL DEFAULT 1 AFTER `codigo_numero_comprobante_fiscal_defecto_ventas`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` CHANGE COLUMN `tipo_venta_defecto` `codigo_tipo_venta_defecto` INTEGER NOT NULL DEFAULT 1;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "CREATE TABLE `iris`.`tipo_ventas` (`codigo` INTEGER UNSIGNED NOT NULL DEFAULT 0,`nombre` VARCHAR(99) NOT NULL DEFAULT '',`activo` BOOLEAN NOT NULL DEFAULT 1, PRIMARY KEY(`codigo`))ENGINE = InnoDB;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`tipo_ventas` ADD COLUMN `nombre_abreviado` VARCHAR(99) NOT NULL DEFAULT '' AFTER `nombre`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into tipo_ventas(codigo,nombre,nombre_abreviado,activo) values('1','CONTADO','CON','1');insert into tipo_ventas(codigo,nombre,nombre_abreviado,activo) values('2','CREDITO','CRE','1');insert into tipo_ventas(codigo,nombre,nombre_abreviado,activo)values('3','COTIZACION','COT','1');insert into tipo_ventas(codigo,nombre,nombre_abreviado,activo) values('4','PEDIDO','PED','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` ADD COLUMN `tipo_ventana_cuadre_caja` INTEGER NOT NULL DEFAULT 1 AFTER `codigo_tipo_venta_defecto`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` MODIFY COLUMN `tipo_ventana_cuadre_caja` INTEGER NOT NULL DEFAULT 1 COMMENT '1 republica dominicana, 2 usa';";
                utilidades.ejecutarcomando_mysql(sql);







                #endregion

                //actualizar la version de la sucursal
                sucursal.versionSistema = 3;
                sucursal.versionSistemaMaxima = 4;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version3.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version4(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version4

                //nuevo query
                sql = "insert into pais(codigo,nombre,estado) values('1','REPUBLICA DOMINICANA','1');insert into pais(codigo,nombre,estado) values('2','UNITED STATES OF AMERICA','1');insert into pais(codigo,nombre,estado) values('3','MEXICO','1');insert into pais(codigo,nombre,estado) values('4','COLOMBIA','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into region(codigo,cod_pais,nombre,activo) values('1','1','NORTE','1');insert into region(codigo,cod_pais,nombre,activo) values('2','1','SUR','1');insert into region(codigo,cod_pais,nombre,activo) values('3','1','ESTE','1');insert into region(codigo,cod_pais,nombre,activo) values('4','1','OESTE','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "insert into ciudad(codigo,nombre,activo) values('6','YONKERS','1');insert into ciudad(codigo,nombre,activo) values('7','BRONX','1');insert into ciudad(codigo,nombre,activo) values('8','QUEENS','1');insert into ciudad(codigo,nombre,activo) values('9','MANHATTAN','1');";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` ADD COLUMN `sistema_full` BOOLEAN NOT NULL DEFAULT 1 COMMENT 'saber si el sistema es full, de no ser asi corta con la fecha' AFTER `tipo_ventana_cuadre_caja`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` MODIFY COLUMN `sistema_full` TINYINT(1) NOT NULL DEFAULT 0 COMMENT 'saber si el sistema es full, de no ser asi corta con la fecha';";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`venta` ADD COLUMN `codigo_tipo_venta` INTEGER NOT NULL DEFAULT 1 AFTER `pedido`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`venta` MODIFY COLUMN `tipo_venta` VARCHAR(99) CHARACTER SET utf8 COLLATE utf8_bin;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`venta_vs_cobros_detalles` MODIFY COLUMN `monto_subtotal` DECIMAL(20,2) NOT NULL DEFAULT 0.00 COMMENT 'es el dinero que entra de la empresa, seria monto - descuento', ADD COLUMN `monto_devuelta` DECIMAL(20,2) NOT NULL DEFAULT 0.00 COMMENT 'es el monto devuelto al cliente cuando paga con un billete mayor al monto esperado' AFTER `monto_subtotal`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`compra_vs_pagos_detalles` ADD COLUMN `monto_devuelta` DECIMAL(20,2) NOT NULL DEFAULT 0.00 AFTER `monto_subtotal`;";
                utilidades.ejecutarcomando_mysql(sql);
                //nuevo query
                sql = "ALTER TABLE `iris`.`sistema` ADD COLUMN `mensaje_pie_pagina_factura` VARCHAR(9999) NOT NULL DEFAULT '' COMMENT 'Thank you for coming !!!' AFTER `sistema_full`;";
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
                sucursal.versionSistema = 4;
                sucursal.versionSistemaMaxima = 5;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version4.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version5(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version5

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
                sucursal.versionSistema = 5;
                sucursal.versionSistemaMaxima = 6;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version5.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version6(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version6

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
                sucursal.versionSistema = 6;
                sucursal.versionSistemaMaxima = 7;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version6.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version7(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version7

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
                sucursal.versionSistema =7;
                sucursal.versionSistemaMaxima = 8;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version7.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version8(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version8

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
                sucursal.versionSistema = 8;
                sucursal.versionSistemaMaxima = 9;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version8.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version9(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version9

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
                sucursal.versionSistema = 9;
                sucursal.versionSistemaMaxima = 10;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version9.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void version10(bool mostrarErrores = true)
        {
            try
            {
                string sql = "";

                #region querys version10

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
                sucursal.versionSistema = 10;
                sucursal.versionSistemaMaxima = 11;
                modeloSucursal.modificarSucursal(sucursal);

            }
            catch (Exception ex)
            {
                if (mostrarErrores == true)
                {
                    MessageBox.Show("Error version10.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

     

    }
}
