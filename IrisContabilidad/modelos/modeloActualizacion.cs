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
