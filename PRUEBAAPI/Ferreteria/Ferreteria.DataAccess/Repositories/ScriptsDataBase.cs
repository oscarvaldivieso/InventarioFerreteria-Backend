﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.DataAccess.Repositories
{
    public class ScriptsDataBase
    {
        #region Usuarios

        public static string IniciarSesion = "Acce.SP_Usuarios_InicioSesion";
        public static string RestablecerClave = "Acce.SP_ReestablecerClave_Actualizar ";
        public static string Usuario_Activar = "Acce.SP_UsuarioActivar";
        public static string Usuario_Desactivar = "Acce.SP_UsuarioDesactivar";

        #endregion Usuarios

        #region Departamentos

        public static string Departamento_Insertar = "Gral.SP_Departamento_Insertar";
        public static string Departamento_Listar = "Gral.SP_Departamento_Listar";
        public static string Departamento_Actualizar = "Gral.SP_Departamento_Actualizar";
        public static string Departamento_Eliminar = "Gral.SP_Departamento_Eliminar";
        public static string Departamento_Buscar = "Gral.SP_Departamento_Buscar";

        #endregion Departamentos

        #region EstadosCiviles

        public static string EstadoCivil_Insertar = "Gral.SP_EstadoCivil_Insertar";
        public static string EstadoCivil_Listar = "Gral.SP_EstadoCivil_Listar";
        public static string EstadoCivil_Actualizar = "Gral.SP_EstadoCivil_Actualizar";
        public static string EstadoCivil_Eliminar = "Gral.SP_EstadoCivil_Eliminar";
        public static string EstadoCivil_Buscar = "Gral.SP_EstadoCivil_Buscar";

        #endregion EstadosCiviles

        #region Municipios

        public static string Municipio_Insertar = "Gral.SP_Municipio_Insertar";
        public static string Municipio_Listar = "Gral.SP_Municipio_Listar";
        public static string Municipio_Actualizar = "Gral.SP_Municipio_Actualizar";
        public static string Municipio_Eliminar = "Gral.SP_Municipio_Eliminar";

        #endregion Municipios

        #region Clientes

        public static string Cliente_Insertar = "Gral.SP_Cliente_Insertar";
        public static string Cliente_Listar = "Gral.SP_Cliente_Listar";
        public static string Cliente_Actualizar = "Gral.SP_Cliente_Actualizar";
        public static string Cliente_Eliminar = "Gral.SP_Cliente_Eliminar";
        public static string Cliente_Buscar = "Gral.SP_Cliente_Buscar";

        #endregion Clientes

        #region Cargos

        public static string Cargo_Insertar = "Ferr.SP_Cargo_Insertar";
        public static string Cargo_Listar = "Ferr.SP_Cargo_Listar";
        public static string Cargo_Actualizar = "Ferr.SP_Cargo_Actualizar";
        public static string Cargo_Eliminar = "Ferr.SP_Cargo_Eliminar";
        public static string Cargo_Buscar = "Ferr.SP_Cargo_Buscar";

        #endregion Cargos

        #region Categorias

        public static string Categoria_Insertar = "Prod.SP_Categoria_Insertar";
        public static string Categoria_Listar = "Prod.SP_Categoria_Listar";
        public static string Categoria_Actualizar = "Prod.SP_Categoria_Actualizar";
        public static string Categoria_Eliminar = "Prod.SP_Categoria_Eliminar";
        public static string Categoria_Buscar = "Prod.SP_Categoria_Buscar";

        #endregion Categorias

        #region Marcas

        public static string Marca_Insertar = "Prod.SP_Marca_Insertar";
        public static string Marca_Listar = "Prod.SP_Marca_Listar";
        public static string Marca_Actualizar = "Prod.SP_Marca_Actualizar";
        public static string Marca_Eliminar = "Prod.SP_Marca_Eliminar";
        public static string Marca_Buscar = "Prod.SP_Marca_Buscar";

        #endregion Marcas

        #region Medidas

        public static string Medida_Insertar = "Prod.SP_Medida_Insertar";
        public static string Medida_Listar = "Prod.SP_Medida_Listar";
        public static string Medida_Actualizar = "Prod.SP_Medida_Actualizar";
        public static string Medida_Eliminar = "Prod.SP_Medida_Eliminar";
        public static string Medida_Buscar = "Prod.SP_Medida_Buscar";

        #endregion Medidas

        #region Usuarios

        public static string Usuario_Insertar = "Acce.SP_Usuario_Insertar";
        public static string Usuario_Listar = "Acce.SP_Usuario_Listar";
        public static string Usuario_Actualizar = "Acce.SP_Usuario_Actualizar";
        public static string Usuario_Eliminar = "Acce.SP_Usuario_Eliminar";
        public static string Usuario_Buscar = "Acce.SP_Usuario_Buscar";

        #endregion Usuarios

        #region Empleados

        public static string Empleado_Insertar = "Ferr.SP_Empleado_Insertar";
        public static string Empleado_Listar = "Ferr.SP_Empleado_Listar";
        public static string Empleado_Actualizar = "Ferr.SP_Empleado_Actualizar";
        public static string Empleado_Eliminar = "Ferr.SP_Empleado_Eliminar";
        public static string Empleado_Buscar = "Ferr.SP_Empleado_Buscar";

        #endregion Empleados

        #region Sucursales

        public static string Sucursal_Insertar = "Ferr.SP_Sucursal_Insertar";
        public static string Sucursal_Listar = "Ferr.SP_Sucursal_Listar";
        public static string Sucursal_Actualizar = "Ferr.SP_Sucursal_Actualizar";
        public static string Sucursal_Eliminar = "Ferr.SP_Sucursal_Eliminar";
        public static string Sucursal_Buscar = "Ferr.SP_Sucursal_Buscar";

        #endregion Sucursales

        #region Productos

        public static string Producto_Insertar = "Prod.SP_Producto_Insertar";
        public static string Producto_Listar = "Prod.SP_Producto_Listar";
        public static string Producto_Actualizar = "Prod.SP_Producto_Actualizar";
        public static string Producto_Eliminar = "Prod.SP_Producto_Eliminar";
        public static string Producto_Buscar = "Prod.SP_Producto_Buscar";
        public static string Producto_BuscarCate = "Prod.SP_ProductoPorCategoria_Buscar";

        #endregion Productos

        #region Proveedores

        public static string Proveedor_Insertar = "Comp.SP_Proveedor_Insertar";
        public static string Proveedor_Listar = "Comp.SP_Proveedor_Listar";
        public static string Proveedor_Actualizar = "Comp.SP_Proveedor_Actualizar";
        public static string Proveedor_Eliminar = "Comp.SP_Proveedor_Eliminar";
        public static string Proveedor_Buscar = "Comp.SP_Proveedor_Buscar";

        #endregion Proveedores

        #region Roles

        public static string Roles_Insertar = "Acce.SP_Rol_Insertar";
        public static string Roles_Listar = "Acce.SP_Rol_Listar";
        public static string Roles_Actualizar = "Acce.SP_Rol_Actualizar";
        public static string Roles_Eliminar = "Acce.SP_Rol_Eliminar";
        public static string Roles_Buscar = "Acce.SP_Rol_Buscar";

        #endregion Roles

        #region PantallasPorRol

        public static string PantallasPorRol_Insertar = "Acce.SP_PantallaPorRol_Insertar";
        public static string PantallasPorRol_Listar = "Acce.SP_PantallaPorRol_Listar";
        public static string PantallasPorRol_Actualizar = "Acce.SP_PantallaPorRol_Actualizar";
        public static string PantallasPorRol_Eliminar = "Acce.SP_PantallaPorRol_Eliminar";
        public static string PantallasPorRol_Buscar = "Acce.SP_PantallaPorRol_Buscar";
        public static string PantallasPorRol_Menu = "Acce.SP_PantallasPorRol_Menu";

        #endregion PantallasPorRol

        #region Compras

        public static string CompraEncabezado_Insertar = "Comp.SP_CompraEncabezado_Insertar";
        public static string CompraDetalle_Insertar = "Comp.SP_CompraDetalle_Insertar";
        public static string Compra_Listar = "Comp.SP_Compra_Listar";
        public static string CompraEncabezado_Actualizar = "Comp.SP_CompraEncabezado_Actualizar";
        public static string CompraDetalle_Actualizar = "Comp.SP_CompraDetalle_Actualizar";
        public static string Compra_Eliminar = "Comp.SP_Compra_Eliminar";
        public static string Compra_Buscar = "Comp.SP_Compra_Buscar";
        public static string CompraFecha_Listar = "Comp.SP_CompraReporte_Listar";

        #endregion Compras
    }
}