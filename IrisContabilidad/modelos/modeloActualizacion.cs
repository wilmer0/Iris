using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloActualizacion
    {

        //objetos
        utilidades utilidades=new utilidades();

        public void version1()
        {
            try
            {
                string sql = "";
                List<string> listaQuerys=new List<string>();

                #region querys version1
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cajero` ADD COLUMN `tipo_impresion_venta` INTEGER UNSIGNED NOT NULL DEFAULT 1 AFTER `activo`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_credito` ADD COLUMN `codigo_venta` INTEGER NOT NULL DEFAULT 0 AFTER `detalle`, ADD CONSTRAINT `FK_cxc_nota_credito_3` FOREIGN KEY `FK_cxc_nota_credito_3` (`codigo_venta`) REFERENCES `venta` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_credito` ADD COLUMN `codigo_venta` INTEGER NOT NULL DEFAULT 0 AFTER `detalle`,ADD CONSTRAINT `FK_cxp_nota_credito_3` FOREIGN KEY `FK_cxp_nota_credito_3` (`codigo_venta`) REFERENCES `venta` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT; ";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_credito` MODIFY COLUMN `activo` TINYINT(1) NOT NULL DEFAULT 1;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "CREATE TABLE `iris_contabilidad`.`nota_credito_debito_concepto` ( `codigo` INTEGER UNSIGNED NOT NULL DEFAULT 0, `concepto` VARCHAR(100) NOT NULL DEFAULT '', `detalle` VARCHAR(500) NOT NULL DEFAULT '', `activo` BOOLEAN NOT NULL DEFAULT 1, PRIMARY KEY(`codigo`) ) ENGINE = InnoDB;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`nota_credito_debito_concepto` MODIFY COLUMN `codigo` INTEGER NOT NULL DEFAULT 0;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_credito` ADD COLUMN `codigo_concepto` INTEGER NOT NULL DEFAULT 0 AFTER `codigo_venta`, ADD CONSTRAINT `FK_cxc_nota_credito_4` FOREIGN KEY `FK_cxc_nota_credito_4` (`codigo_concepto`) REFERENCES `nota_credito_debito_concepto` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "CREATE TABLE `iris_contabilidad`.`tipo_impresion_venta` (`codigo` INTEGER NOT NULL DEFAULT 0,`descripcion` VARCHAR(200) NOT NULL DEFAULT '',`activo` BOOLEAN NOT NULL DEFAULT 1,PRIMARY KEY(`codigo`))ENGINE = InnoDB;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cajero` MODIFY COLUMN `tipo_impresion_venta` INTEGER NOT NULL DEFAULT 1;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`comprobante_fiscal` MODIFY COLUMN `desde_numero` BIGINT NOT NULL DEFAULT 0,MODIFY COLUMN `hasta_numero` BIGINT UNSIGNED NOT NULL DEFAULT 0;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_debito` ADD COLUMN `codigo_concepto` INTEGER NOT NULL DEFAULT 0 AFTER `detalle`, ADD CONSTRAINT `FK_cxc_nota_debito_4` FOREIGN KEY `FK_cxc_nota_debito_4` (`codigo_concepto`) REFERENCES `nota_credito_debito_concepto` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_credito` ADD COLUMN `codigo_devolucion` INTEGER NOT NULL DEFAULT 0 AFTER `codigo_concepto`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_debito` ADD COLUMN `codigo_devolucion` INTEGER NOT NULL DEFAULT 0 AFTER `codigo_concepto`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_debito` DROP COLUMN `codigo_devolucion`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "CREATE TABLE `iris_contabilidad`.`log_reportes_generados` ( `codigo` INTEGER NOT NULL DEFAULT 0, `reporte_generado` VARCHAR(999) NOT NULL DEFAULT '', `codigo_empleado` INTEGER NOT NULL DEFAULT 0, `fecha` DATE NOT NULL DEFAULT 0, `fecha_hora` DATETIME NOT NULL DEFAULT 0, PRIMARY KEY(`codigo`) ) ENGINE = InnoDB;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`log_reportes_generados` MODIFY COLUMN `reporte_generado` VARCHAR(999) NOT NULL DEFAULT '', ADD CONSTRAINT `FK_log_reportes_generados_1` FOREIGN KEY `FK_log_reportes_generados_1` (`codigo_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxc_nota_credito` MODIFY COLUMN `codigo_devolucion` INTEGER;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_credito` DROP FOREIGN KEY `FK_cxp_nota_credito_3`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_credito` CHANGE COLUMN `codigo_venta` `codigo_compra` INTEGER NOT NULL DEFAULT 0, DROP INDEX `FK_cxp_nota_credito_3`, ADD INDEX `FK_cxp_nota_credito_3` USING BTREE(`codigo_compra`);";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_credito` ADD CONSTRAINT `FK_cxp_nota_credito_3` FOREIGN KEY `FK_cxp_nota_credito_3` (`codigo_compra`) REFERENCES `compra` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_credito` ADD COLUMN `codigo_devolucion` INTEGER AFTER `codigo_compra`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`ingresos_caja` ADD COLUMN `modificable` BOOLEAN NOT NULL DEFAULT 1 AFTER `cuadrado`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_credito` ADD COLUMN `activo` BOOLEAN NOT NULL DEFAULT 1 AFTER `codigo_devolucion`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_credito` ADD COLUMN `codigo_concepto` INTEGER NOT NULL DEFAULT 0 AFTER `activo`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_debito` ADD COLUMN `codigo_compra` INTEGER NOT NULL DEFAULT 0 AFTER `detalle`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cxp_nota_debito` ADD COLUMN `codigo_concepto` INTEGER NOT NULL DEFAULT 0 AFTER `codigo_compra`;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "CREATE TABLE `iris_contabilidad`.`entidades` ( `codigo` INTEGER NOT NULL AUTO_INCREMENT, `codigo_cliente` INTEGER NOT NULL DEFAULT 0, `codigo_suplidor` INTEGER NOT NULL DEFAULT 0, `codigo_empleado` INTEGER NOT NULL DEFAULT 0, `codigo_cajero` INTEGER NOT NULL DEFAULT 0, PRIMARY KEY(`codigo`) ) ENGINE = InnoDB;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`entidades` ADD CONSTRAINT `FK_entidades_1` FOREIGN KEY `FK_entidades_1` (`codigo_cliente`) REFERENCES `cliente` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`entidades` ADD CONSTRAINT `FK_entidades_2` FOREIGN KEY `FK_entidades_2` (`codigo_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`cajero` MODIFY COLUMN `cod_empleado` INTEGER NOT NULL DEFAULT 0, MODIFY COLUMN `cod_caja` INTEGER NOT NULL DEFAULT 0, MODIFY COLUMN `activo` TINYINT(1) NOT NULL DEFAULT 0;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`entidades` ADD CONSTRAINT `FK_entidades_3` FOREIGN KEY `FK_entidades_3` (`codigo_suplidor`) REFERENCES `suplidor` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "ALTER TABLE `iris_contabilidad`.`entidades` ADD CONSTRAINT `FK_entidades_4` FOREIGN KEY `FK_entidades_4` (`codigo_cajero`) REFERENCES `cajero` (`codigo`) ON DELETE RESTRICT ON UPDATE RESTRICT;";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                
                #endregion


                listaQuerys.ForEach(x =>
                {
                    utilidades.ejecutarcomando_mysql(x);
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void version1_1_0()
        {
            try
            {
                string sql = "";
                List<string> listaQuerys = new List<string>();

                #region querys version1
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                #endregion


                listaQuerys.ForEach(x =>
                {
                    utilidades.ejecutarcomando_mysql(x);
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void version1_2_0()
        {
            try
            {
                string sql = "";
                List<string> listaQuerys = new List<string>();

                #region querys version1
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                //nuevo query
                sql = "";
                listaQuerys.Add(sql);
                #endregion


                listaQuerys.ForEach(x =>
                {
                    utilidades.ejecutarcomando_mysql(x);
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error version1.:" + ex.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
