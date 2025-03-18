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
        #endregion

        #region EstadosCiviles
        public static string EstadoCivil_Insertar = "Gral.SP_EstadoCivil_Insertar";
        public static string EstadoCivil_Listar = "Gral.SP_EstadoCivil_Listar";
        public static string EstadoCivil_Actualizar = "Gral.SP_EstadoCivil_Actualizar";
        public static string EstadoCivil_Eliminar = "Gral.SP_EstadoCivil_Eliminar";
        #endregion
    }
}
