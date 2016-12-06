﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IrisContabilidadModelo.modelos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class iris_contabilidadEntities : DbContext
    {
        public iris_contabilidadEntities()
            : base("name=iris_contabilidadEntities")
        {
        }
    	public iris_contabilidadEntities(string servidor, string baseDatos, string user, string pass, string Puerto="3306"): base("name=punto_ventaEntities")
                            {
    
    
                        var connectionString = this.Database.Connection.ConnectionString + ";password=" + pass;
                        connectionString = "server=" + servidor + ";userid=" + user + ";persistsecurityinfo=true;database=" + baseDatos + ";password=" + pass +";Port=" + Puerto;
    
                        this.Database.Connection.ConnectionString = connectionString;
                    }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<almacen> almacen { get; set; }
        public DbSet<caja> caja { get; set; }
        public DbSet<cajero> cajero { get; set; }
        public DbSet<cargo> cargo { get; set; }
        public DbSet<categoria_producto> categoria_producto { get; set; }
        public DbSet<cliente> cliente { get; set; }
        public DbSet<cliente_categoria> cliente_categoria { get; set; }
        public DbSet<cobros> cobros { get; set; }
        public DbSet<cobros_detalles> cobros_detalles { get; set; }
        public DbSet<compra> compra { get; set; }
        public DbSet<comprobante_fiscal> comprobante_fiscal { get; set; }
        public DbSet<comprobante_serie> comprobante_serie { get; set; }
        public DbSet<comprobante_ventas> comprobante_ventas { get; set; }
        public DbSet<cuadre_caja> cuadre_caja { get; set; }
        public DbSet<cuadre_caja_detalles> cuadre_caja_detalles { get; set; }
        public DbSet<cuenta_bancaria> cuenta_bancaria { get; set; }
        public DbSet<departamento> departamento { get; set; }
        public DbSet<direccion> direccion { get; set; }
        public DbSet<egresos_caja> egresos_caja { get; set; }
        public DbSet<egresos_conceptos> egresos_conceptos { get; set; }
        public DbSet<empleado> empleado { get; set; }
        public DbSet<empresa> empresa { get; set; }
        public DbSet<entrada_salida_inventario> entrada_salida_inventario { get; set; }
        public DbSet<estados> estados { get; set; }
        public DbSet<estados_reparacion> estados_reparacion { get; set; }
        public DbSet<factura> factura { get; set; }
        public DbSet<grupo_usuarios> grupo_usuarios { get; set; }
        public DbSet<identificacion> identificacion { get; set; }
        public DbSet<ingresos_caja> ingresos_caja { get; set; }
        public DbSet<ingresos_conceptos> ingresos_conceptos { get; set; }
        public DbSet<inventario> inventario { get; set; }
        public DbSet<inventario_reparacion> inventario_reparacion { get; set; }
        public DbSet<itebis> itebis { get; set; }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<mesas> mesas { get; set; }
        public DbSet<metodo_pago> metodo_pago { get; set; }
        public DbSet<modelo> modelo { get; set; }
        public DbSet<modulos_vs_ventanas> modulos_vs_ventanas { get; set; }
        public DbSet<moneda> moneda { get; set; }
        public DbSet<moneda_historial> moneda_historial { get; set; }
        public DbSet<nomina> nomina { get; set; }
        public DbSet<nomina_conceptos> nomina_conceptos { get; set; }
        public DbSet<nomina_tipos> nomina_tipos { get; set; }
        public DbSet<pagos> pagos { get; set; }
        public DbSet<pagos_detalles> pagos_detalles { get; set; }
        public DbSet<pais> pais { get; set; }
        public DbSet<permiso> permiso { get; set; }
        public DbSet<persona> persona { get; set; }
        public DbSet<producto> producto { get; set; }
        public DbSet<producto_detalle> producto_detalle { get; set; }
        public DbSet<producto_oferta> producto_oferta { get; set; }
        public DbSet<producto_permisos> producto_permisos { get; set; }
        public DbSet<producto_unidad_conversion> producto_unidad_conversion { get; set; }
        public DbSet<producto_vs_detalle> producto_vs_detalle { get; set; }
        public DbSet<producto_vs_permisos> producto_vs_permisos { get; set; }
        public DbSet<provincia> provincia { get; set; }
        public DbSet<region> region { get; set; }
        public DbSet<sector> sector { get; set; }
        public DbSet<sexo> sexo { get; set; }
        public DbSet<sistema> sistema { get; set; }
        public DbSet<sistema_modulo> sistema_modulo { get; set; }
        public DbSet<sistema_ventanas> sistema_ventanas { get; set; }
        public DbSet<situacion_empleado> situacion_empleado { get; set; }
        public DbSet<subcategoria_producto> subcategoria_producto { get; set; }
        public DbSet<sucursal> sucursal { get; set; }
        public DbSet<suplidor> suplidor { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tarjetas_credito> tarjetas_credito { get; set; }
        public DbSet<tipo_comprobante_fiscal> tipo_comprobante_fiscal { get; set; }
        public DbSet<tipo_correo_electronico> tipo_correo_electronico { get; set; }
        public DbSet<tipo_cuenta_bancaria> tipo_cuenta_bancaria { get; set; }
        public DbSet<tipo_gasto> tipo_gasto { get; set; }
        public DbSet<tipo_identificacion> tipo_identificacion { get; set; }
        public DbSet<tipo_movimiento_inventario> tipo_movimiento_inventario { get; set; }
        public DbSet<transferencia_inventario> transferencia_inventario { get; set; }
        public DbSet<unidad> unidad { get; set; }
        public DbSet<vendedor> vendedor { get; set; }
        public DbSet<catalogo_cuentas> catalogo_cuentas { get; set; }
        public DbSet<compra_detalle> compra_detalle { get; set; }
        public DbSet<empleado_accesos_ventanas> empleado_accesos_ventanas { get; set; }
        public DbSet<empleado_historial_datos> empleado_historial_datos { get; set; }
        public DbSet<factura_detalle> factura_detalle { get; set; }
        public DbSet<mesas_detalles> mesas_detalles { get; set; }
        public DbSet<nomina_detalle> nomina_detalle { get; set; }
        public DbSet<oferta_producto_categoria_detalle> oferta_producto_categoria_detalle { get; set; }
        public DbSet<oferta_producto_detalle> oferta_producto_detalle { get; set; }
        public DbSet<producto_codigobarra> producto_codigobarra { get; set; }
        public DbSet<producto_oferta_historial> producto_oferta_historial { get; set; }
    }
}