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

        //modelos
        modeloEmpresa modeloEmpresa = new modeloEmpresa();
        modeloSucursal modeloSucursal=new modeloSucursal();
        modeloCiudad modeloCiudad=new modeloCiudad();
        modeloModulo modeloModulo = new modeloModulo();



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
                    empresa.division = "001";
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

                    //ciudades
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
                

                //primera sucursal
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
                #region
                List<modulo> listaModulo = new List<modulo>();
                //nuevo modulo
                modulo = new modulo();
                modulo.id = modeloModulo.getNextModulo();
                modulo.nombre = "modulo empresa";
                modulo.imagen = "empresa1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_empresa";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = modeloModulo.getNextModulo();
                modulo.nombre = "modulo facturacion";
                modulo.imagen = "facturacion1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_facturacion";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = modeloModulo.getNextModulo();
                modulo.nombre = "modulo cuentas por cobrar";
                modulo.imagen = "cxc.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_cuenta_por_cobrar";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = modeloModulo.getNextModulo();
                modulo.nombre = "modulo cuentas por pagar";
                modulo.imagen = "cxp.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_cuenta_por_pagar";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = modeloModulo.getNextModulo();
                modulo.nombre = "modulo inventario";
                modulo.imagen = "inventario1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_inventario";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = modeloModulo.getNextModulo();
                modulo.nombre = "modulo opciones";
                modulo.imagen = "opciones1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_opciones";
                listaModulo.Add(modulo);
                //nuevo modulo
                modulo = new modulo();
                modulo.id = modeloModulo.getNextModulo();
                modulo.nombre = "modulo nomina";
                modulo.imagen = "nomina1.png";
                modulo.activo = true;
                modulo.nombre_logico = "IrisContabilidad.modulo_nomina";
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
                List<ventana> listaVentana=new List<ventana>();

                //modulo empresa
                #region
                //nueva ventana
                ventana=new ventana();
                ventana.nombre_ventana = "ventana empresa";
                ventana.nombre_logico = "IrisContabilidad.modulo_empresa.ventana_empresa";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "empresa1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana ciudad";
                ventana.nombre_logico = "IrisContabilidad.modulo_empresa.ventana_ciudad";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "ciudad1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana sucursal";
                ventana.nombre_logico = "IrisContabilidad.modulo_empresa.ventana_sucursal";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "sucursal1.png";
                listaVentana.Add(ventana);

                #endregion
                
               
               //modulo cuentas por pagar
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana suplidor";
                ventana.nombre_logico = "IrisContabilidad.modulo_cuenta_por_pagar.ventana_suplidor";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "suplidor1.png";
                listaVentana.Add(ventana);
                #endregion

                
                //modulo cuentas por cobrar
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana cliente";
                ventana.nombre_logico = "IrisContabilidad.modulo_cuenta_por_cobrar.ventana_cliente";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "cliente1.png";
                listaVentana.Add(ventana);
                #endregion
                
                
                //modulo facturacion
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana itbis";
                ventana.nombre_logico = "IrisContabilidad.modulo_facturacion.ventana_itebis";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "itebis1.png";
                listaVentana.Add(ventana);
                #endregion
                
                
                //modulo inventario
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana producto";
                ventana.nombre_logico = "IrisContabilidad.modulo_inventario.ventana_producto";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "producto1.png";
                listaVentana.Add(ventana);
                #endregion
                
                
                //modulo nomina
                #region
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana tipo nomina";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_tipo_nomina";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "empresa1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana situacion empleado";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_situacion_empleado";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "situacion_empleado1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana cargo empleado";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_cargo_empleado";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "cargo1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana departamento";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_departamento";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "departamento1.png";
                listaVentana.Add(ventana);
                //nueva ventana
                ventana = new ventana();
                ventana.nombre_ventana = "ventana empleado";
                ventana.nombre_logico = "IrisContabilidad.modulo_nomina.ventana_empleado";
                ventana.activo = true;
                ventana.programador = false;
                ventana.imagen = "empleado1.png";
                listaVentana.Add(ventana);
                #endregion


                //modulo sistema
                #region
                #endregion

                listaVentana.ForEach(ventanaActual =>
                {
                    modeloModulo.agregarVentana(ventanaActual);
                });
                
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
                    if (ds.Tables[0].Rows[0][0] == "")
                    {
                        sql = "insert into empleado_accesos_ventanas(id_empleado,id_ventana_sistema) values('1','" +
                              row[0].ToString() + "')";
                        utilidades.ejecutarcomando_mysql(sql);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarAccesosVentanas.: " + ex.ToString());
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
