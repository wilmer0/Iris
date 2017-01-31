using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modulo_nomina;

namespace IrisContabilidad.modelos
{
    public class modeloPrimerLogin
    {


        //objetos
        private utilidades utilidades=new utilidades();
        private ventana ventana;
        private empresa empresa;
        private sucursal sucursal;
        private ciudad ciudad;
        private modulo modulo;
        private cargo cargo;
        private departamento departamento;
        private situacion_empleado situacionEmpleado;
        private tipo_gasto tipoGasto;
        private nomina_tipo nominaTipo;

        //modelos
        modeloEmpresa modeloEmpresa = new modeloEmpresa();
        modeloSucursal modeloSucursal=new modeloSucursal();
        modeloCiudad modeloCiudad=new modeloCiudad();
        modeloModulo modeloModulo = new modeloModulo();
        modeloCargo modeloCargo=new modeloCargo();
        modeloDepartamento modeloDepartamento=new modeloDepartamento();
        modeloSituacionEmpleado modeloSituacionEmpleado=new modeloSituacionEmpleado();
        modeloTipoGasto modeloTipoGasto=new modeloTipoGasto();
        modeloNominaTipo modeloNominaTipo=new modeloNominaTipo();

        //validar primer login
        public void validarPrimerLogin()
        {
            try
            {
                string sql = "select *from empleado";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //no existe empleado entonces se debe agregar todo
                    primerosDatos();
                    agregarModulos();
                    agregarVentanas();
                    agregarPrimerEmpleado();
                    agregarAccesosVentanas();
                    agregarVentanasPrimerModulo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarPrimerLogin.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //agregando todos los datos que son necesarios al momento de iniciar el sistemas
        public void primerosDatos()
        {
            try
            {
                //empresa
                string sql = "SELECT * FROM empresa";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //debe agregar la empresa
                    empresa=new empresa();
                    empresa.codigo = 1;
                    empresa.nombre = "Empresa";
                    empresa.secuencia = "001";
                    empresa.division = "01";
                    empresa.rnc = "000000000";
                    empresa.activo = true;
                    modeloEmpresa.agregarEmpresa(empresa);
                }


                //sucursal
                sql = "SELECT * FROM sucursal";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count ==0)
                {
                    //debe agregar la empresa
                    sucursal = new sucursal();
                    sucursal.codigo = 1;
                    sucursal.codigo_empresa = 1;
                    sucursal.secuencia = "001";
                    sucursal.direccion = "Direccion";
                    sucursal.activo = true;
                    modeloSucursal.agregarSucursal(sucursal);
                }


                //cargos
                #region
                List<cargo> listaCargo=new List<cargo>();

                //nuevo cargo
                cargo=new cargo();
                cargo.id = 1;
                cargo.nombre = "general";
                cargo.activo = true;
                listaCargo.Add(cargo);

                listaCargo.ForEach(cargoActual =>
                {
                    modeloCargo.agregarCargo(cargoActual);
                });

                #endregion


                //departamentos sucursales
                #region
                List<departamento> listaDepartamento = new List<departamento>();

                //nuevo departamento
                departamento = new departamento();
                departamento.codigo = 1;
                departamento.nombre = "general";
                departamento.codigo_sucursal = 1;
                departamento.activo = true;
                listaDepartamento.Add(departamento);

                listaDepartamento.ForEach(cargoActual =>
                {
                    modeloDepartamento.agregarDepartamento(departamento);
                });

                #endregion

                
                //situacion empleado
                #region
                List<situacion_empleado> listaSituacionEmpleado = new List<situacion_empleado>();

                //situacion empleado
                situacionEmpleado = new situacion_empleado();
                situacionEmpleado.codigo = 1;
                situacionEmpleado.descripcion = "general";
                situacionEmpleado.activo = true;
                listaSituacionEmpleado.Add(situacionEmpleado);

                listaSituacionEmpleado.ForEach(cargoActual =>
                {
                    modeloSituacionEmpleado.agregarSituacionEmpleado(situacionEmpleado);
                });

                #endregion

                //tipos de nomina
                #region
                List<nomina_tipo> listaNominaTipo = new List<nomina_tipo>();

                //tipos de nomina
                nominaTipo = new nomina_tipo();
                nominaTipo.codigo = 1;
                nominaTipo.nombre = "general";
                nominaTipo.activo = true;
                listaNominaTipo.Add(nominaTipo);

                listaNominaTipo.ForEach(cargoActual =>
                {
                    modeloNominaTipo.agregarNominaTipo(nominaTipo);
                });

                #endregion
                
                //tipos de gastos
                #region
                List<tipo_gasto> listaTipoGasto = new List<tipo_gasto>();

                //nuevo tipo_gasto
                tipoGasto = new tipo_gasto();
                tipoGasto.id = 1;
                tipoGasto.nombre = "general";
                tipoGasto.activo = true;
                listaTipoGasto.Add(tipoGasto);

                listaTipoGasto.ForEach(cargoActual =>
                {
                    modeloTipoGasto.agregarTipoGasto(tipoGasto);
                });

                #endregion

                //ciudades
                #region
                List<ciudad> listaCiudades=new List<ciudad>();

                    //nueva ciudad
                    ciudad = new ciudad();
                    ciudad.nombre = "santo domingo";
                    ciudad.activo = true;
                    listaCiudades.Add(ciudad);
                    //nueva ciudad
                    ciudad = new ciudad();
                    ciudad.nombre = "santiago de los caballeros";
                    ciudad.activo = true;
                    listaCiudades.Add(ciudad);
                    //nueva ciudad
                    ciudad = new ciudad();
                    ciudad.nombre = "montecristi";
                    ciudad.activo = true;
                    listaCiudades.Add(ciudad);
                    //nueva ciudad
                    ciudad = new ciudad();
                    ciudad.nombre = "mao";
                    ciudad.activo = true;
                    listaCiudades.Add(ciudad);
                    //nueva ciudad
                    ciudad = new ciudad();
                    ciudad.nombre = "la vega";
                    ciudad.activo = true;
                    listaCiudades.Add(ciudad);


                    modeloCiudad.agregarCiudad(listaCiudades);
                #endregion


                
                
                //permisos productos
                #region
                sql = "insert into producto_permisos(codigo,nombre,activo) values('1','vender a precio diferente','1');";
                utilidades.ejecutarcomando_mysql(sql);
                sql = "insert into producto_permisos(codigo,nombre,activo) values('2','vender sin existencia','1');";
                utilidades.ejecutarcomando_mysql(sql);




                //metodos de pago
                sql = "insert into metodo_pago(codigo,metodo,descripcion,activo) values('1','Efectivo','cuando se recive el dinero en metal','1')";
                utilidades.ejecutarcomando_mysql(sql);
                sql ="insert into metodo_pago(codigo,metodo,descripcion,activo) values('2','Deposito','cuando se recive el dinero por transferencia bancaria','1')";
                utilidades.ejecutarcomando_mysql(sql);
                sql = "insert into metodo_pago(codigo,metodo,descripcion,activo) values('3','cheque','cuando se recive el dinero en base a un cheque bancario','1')";
                utilidades.ejecutarcomando_mysql(sql);

                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error primerosDatos.: " + ex.ToString());
            }
        }

        //agregar modulos del sistema
        public void agregarModulos()
        {
            try
            {
                /*
                   1-modulo empresa
                   2-modulo facturacion
                   3-modulo cxc
                   4-modulo cxp
                   5-modulo inventario
                   6-modulo opciones
                   7-modulo nomina
                   8-modulo inicio rapido
                   9-modulo contabilidad
                */
                #region
                List<modulo> listaModulo = new List<modulo>();
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 1;
                modulo.nombre = "modulo empresa";
                modulo.imagen = "empresa1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_empresa";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 2;
                modulo.nombre = "modulo facturacion";
                modulo.imagen = "facturacion1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_facturacion";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 3;
                modulo.nombre = "modulo cuentas por cobrar";
                modulo.imagen = "cxc.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_cuenta_por_cobrar";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 4;
                modulo.nombre = "modulo cuentas por pagar";
                modulo.imagen = "cxp.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_cuenta_por_pagar";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 5;
                modulo.nombre = "modulo inventario";
                modulo.imagen = "inventario1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_inventario";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 6;
                modulo.nombre = "modulo opciones";
                modulo.imagen = "opciones1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_opciones";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 7;
                modulo.nombre = "modulo nomina";
                modulo.imagen = "nomina1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_nomina";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 8;
                modulo.nombre = "modulo inicio rapido";
                modulo.imagen = "inicio_rapido1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_inicio_rapido";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = 9;
                modulo.nombre = "modulo contabilidad";
                modulo.imagen = "contabilidad1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_contabilidad";
                listaModulo.Add(modulo);

                #endregion


                listaModulo.ForEach(moduloActual =>
                {
                    modeloModulo.agregarModulo(moduloActual);
                    string sql = "insert into sistema_modulo(id,nombre,activo,nombre_modulo_proyecto,imagen) values('1','modulo_empresa','1','IrisContabilidad.modulo_empresa','empresa1.png')";
                    utilidades.ejecutarcomando_mysql(sql);
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVentanas.: " + ex.ToString());
            }
        }

        //agregando las ventanas para que salgan al primer usuario
        public void agregarVentanas()
        {
            try
            {
                //1-modulo empresa
                //2-modulo facturacion
                //3-modulo cxc
                //4-modulo cxp
                //5-modulo inventario
                //6-modulo opciones
                //7-modulo nomina
                //8-modulo inicio rapido
                //9-modulo contabilidad
                List<ventana> listaVentana=new List<ventana>();

                //modulo empresa
                #region
                //nueva ventana
                ventana=new ventana();
                ventana.nombre_ventana = "Empresa";
                ventana.nombre_logico = "IrisContabilidad.modulo_empresa.ventana_empresa";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 1;
                ventana.imagen = "empresa1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Ciudad";
                ventana.nombre_logico = "IrisContabilidad.modulo_empresa.ventana_ciudad";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 1;
                ventana.imagen = "ciudad1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Sucursal";
                ventana.nombre_logico = "IrisContabilidad.modulo_empresa.ventana_sucursal";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 1;
                ventana.imagen = "sucursal1.png";
                listaVentana.Add(ventana);
               
                #endregion



                //modulo facturacion
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Itbis";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_itebis";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 2;
                ventana.imagen = "itebis1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Caja";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_caja";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 2;
                ventana.imagen = "caja1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Cajero";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_cajero";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 2;
                ventana.imagen = "cajero1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Tipo comprobante fiscal";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_tipo_comprobante_fiscal";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 2;
                ventana.imagen = "tipo_comprobante_fiscal1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Egreso de caja";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_egreso_caja";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 2;
                ventana.imagen = "egreso_caja1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "caja egresos/ingresos";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_caja_ingresos_egresos_conceptos";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 2;
                ventana.imagen = "egresos_ingresos1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Vendedor";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_vendedor";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 2;
                ventana.imagen = "vendedor1.png";
                listaVentana.Add(ventana);
                #endregion



                //modulo cuentas por cobrar
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Cliente";
                ventana.nombre_logico = "IrisContabilidad.modulo_cuenta_por_cobrar.ventana_cliente";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 3;
                ventana.imagen = "cliente1.png";
                listaVentana.Add(ventana);
                ventana = new ventana();
                ventana.nombre_ventana = "Categoria cliente";
                ventana.nombre_logico = "IrisContabilidad.modulo_cuenta_por_cobrar.ventana_categoria_cliente";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 3;
                ventana.imagen = "categoria_cliente1.png";
                listaVentana.Add(ventana);
                #endregion



                //modulo cuentas por pagar
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Suplidor";
                ventana.nombre_logico = "IrisContabilidad.modulo_cuenta_por_pagar.ventana_suplidor";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 4;
                ventana.imagen = "suplidor1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "compra pagos";
                ventana.nombre_logico = "IrisContabilidad.modulo_cuenta_por_pagar.ventana_compra_pagos";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 4;
                ventana.imagen = "suplidor1.png";
                listaVentana.Add(ventana);
                #endregion

                

                //modulo inventario
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Producto";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_producto";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 5;
                ventana.imagen = "producto1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Unidad";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_unidad";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 5;
                ventana.imagen = "unidad1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Almacen";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_almacen";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 5;
                ventana.imagen = "almacen1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Categoria producto";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_categoria_producto";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 5;
                ventana.imagen = "categoria_producto1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Subcategoria producto";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_subcategoria_producto";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 5;
                ventana.imagen = "sub_categoria_producto1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Compra";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_compra";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 5;
                ventana.imagen = "compra1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Reporte productos";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_reporte_producto";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 5;
                ventana.imagen = "reporte_producto1.png";
                listaVentana.Add(ventana);
                #endregion



                //modulo opciones
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "Cambio de clave";
                ventana.nombre_logico = "IrisContabilidad.modulo_opciones.ventana_cambio_clave";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 6;
                ventana.imagen = "cambio_clave1.png";
                listaVentana.Add(ventana);
                #endregion



                //modulo nomina
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "tipo nomina";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_tipo_nomina";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 7;
                ventana.imagen = "tipo_nomina1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "situacion empleado";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_situacion_empleado";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 7;
                ventana.imagen = "situacion_empleado1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "cargo empleado";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_cargo";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 7;
                ventana.imagen = "cargo1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = " departamento";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_departamento";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 7;
                ventana.imagen = "departamento1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "empleado";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_empleado";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 7;
                ventana.imagen = "empleado1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "grupo de usuarios";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_grupo_usuarios";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 7;
                ventana.imagen = "grupo_usuario1.png";
                listaVentana.Add(ventana);
                #endregion



                //modulo inicio rapido
                #region
                #endregion



                //modulo sistema
                #region
                #endregion


                //modulo contabilidad
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "tipo gastos";
                ventana.nombre_logico = "IrisContabilidad.modulo_contabilidad.ventana_tipo_gastos";
                ventana.activo = true;
                ventana.programador = false;
                ventana.codigo_modulo = 9;
                ventana.imagen = "tipo_gastos1.png";
                listaVentana.Add(ventana);
                #endregion




                listaVentana.ForEach(ventanaActual =>
                {
                    modeloModulo.agregarPoolVentana(ventanaActual);
                });
                

                //para agregarla manualmente
                //insert into sistema_ventanas(codigo,nombre_ventana,nombre_logico,imagen,activo,programador) values('15','ventana almacen','IrisContabilidad.modulo_inventario.ventana_almacen','almacen1.png','1','0');
                //insert into empleado_accesos_ventanas(id_empleado,id_ventana_sistema) values('1','15');
                //insert into modulos_vs_ventanas(id_modulo,id_ventana) values('1','15');
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVentanas.: " + ex.ToString());
            }
        }

        //agregar accesos a ventana al primer empleado
        public void agregarAccesosVentanas()
        {
            try
            {
                string sql = "select codigo,nombre_ventana,nombre_logico,imagen,activo,programador FROM sistema_ventanas";
                DataSet ventanas = utilidades.ejecutarcomando_mysql(sql);
                //ingresando acceso a ventanas del primer usuario
                foreach (DataRow row in ventanas.Tables[0].Rows)
                {
                    sql ="select *from empleado_accesos_ventanas  where id_empleado='1' and id_ventana_sistema='" + row[0].ToString() + "'";
                    DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count==0)
                    {
                        sql = "insert into empleado_accesos_ventanas(id_empleado,id_ventana_sistema) values('1','" +row[0].ToString() + "')";
                        utilidades.ejecutarcomando_mysql(sql);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarAccesosVentanas.: " + ex.ToString());
            }
        }


        public void agregarVentanasPrimerModulo()
        {
            try
            {
                //seleccionando todas las ventanas
                string sql = "select codigo,nombre_ventana,nombre_logico,imagen,activo,programador FROM sistema_ventanas";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //agregar esta ventana al primer modulo
                    utilidades.ejecutarcomando_mysql("insert into modulos_vs_ventanas(id_modulo,id_ventana) values('1','" + row[0].ToString() + "')");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVentanasPrimerModulo.: " + ex.ToString());
            }
        }

        //agregar primer empleado
        public void agregarPrimerEmpleado()
        {
            try
            {
                string sql = "select *from empleado";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //debe crear el primer empleado
                    ventana_empleado ventana = new ventana_empleado();
                    ventana.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error ValidarCrearPrimerEmpleado.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
