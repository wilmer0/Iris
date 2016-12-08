using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidadModelo.modelos;

namespace IrisContabilidad.clases
{
    class singleton
    {

        //objetos
        public static singleton singletonInstance = null;
        public static empleado empleado;
        
        
        //metodos para obtener datos
        public static singleton getPermisos()
        {
            if (singletonInstance == null)
                singletonInstance = new singleton();

            return singletonInstance;
        }
        public static empleado getEmpleado()
        {
            if (empleado == null)
                empleado = new empleado();

            return empleado;
        }



        public string codigo_usuario = null;
        public string nombre = null;
        public string codigo_sucursal = null;
        public string codigo_empresa = null;
        public bool facturacion = false;
        public string idioma = "es-ES";
        public bool mod_inventario = false;
        public bool mod_cuentasPorCobrar = false;
        public bool mod_cuentasPorPagar = false;
        public bool mod_nomina = false;
        public bool mod_facturacion = false;
        public bool mod_empresa = false;
        public bool mod_opciones = false;
        public bool mod_prestamos = false;
        public bool mod_administrador = false;
        public bool anular_pagos_compras = false;
        public bool cambiar_fecha_facturacion = false;
        public bool cobros_cxc = false;
        public bool devolucion_venta = false;
        public bool devolucion_compra = false;
        public bool anular_compra = false;
        public bool hacer_compra = false;
        public bool precio_producto_unidad = false;
        public bool anular_cobros = false;
        public bool cambiaf_fecha_cuadre_caja = false;
        public bool puede_asignar_permisos = false;
        public bool puede_asignar_permisos_a_grupos = false;
        public bool puede_hacer_cuadre_caja = false;
        public bool puede_autorizar_pedidos = false;
        public bool puede_despachar_pedidos = false;
        public bool puede_anular_pedidos = false;
        public bool puede_crear_pedidos = false;
        public bool puede_cambiar_fecha_en_egreso_caja = false;
        public bool puede_crear_egresos_caja = false;
        public bool puede_crear_modificar_productos = false;
        public bool puede_buscar_existencias = false;
        public bool puede_Cambiar_precio_facturacion = false;
        public bool puede_anular_facturas_venta = false;
        public bool puede_poner_credito_cliente = false;
        public bool puede_entrada_salida_productos = false;
        public bool puede_crear_modificar_sucursales = false;
        public bool puede_cambiar_clave = false;
        public bool puede_ver_ventas_del_dia = false;
        public bool puede_hacer_observacion_empleado = false;
        public bool puede_hacer_pagos_suplidores = false;
        public bool puede_crear_modificar_empleados = false;
        public bool puede_modificar_sistema = false;
        public bool puede_crear_modificar_empresas = false;
        public bool puede_generar_nomina = false;
        public bool puede_hacer_ingresos_caja = false;







      
    }
}
