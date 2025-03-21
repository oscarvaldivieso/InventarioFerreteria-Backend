using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.DataAccess.Repositories
{
    public class ScriptsDataBase
    {
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

        #region Usuarios
        public static string IniciarSesion = "Acce.SP_Usuarios_InicioSesion";
        #endregion
    }
}