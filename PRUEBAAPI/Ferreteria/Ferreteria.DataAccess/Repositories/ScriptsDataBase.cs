using System;
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
        #endregion

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
    }
}