using Dapper;
using FerreteriaEntities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.DataAccess.Repositories
{
    public class RolRepository : IRepository<tbRoles>
    {
        FerreteriaContext db = new FerreteriaContext();


        public IEnumerable<tbRoles> List()
        {
            var parameter = new DynamicParameters();
            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbRoles>(ScriptsDataBase.Roles_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        // Insertar un nuevo rol
        public RequestStatus Insert(tbRoles item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Descripcion", item.Role_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Roles_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string message = result > 0 ? "Rol insertado correctamente" : "Error al insertar el rol";
            return new RequestStatus { CodeStatus = result, MessageStatus = message };
        }

        public RequestStatus AssignScreensToRole(int roleId, List<int> pantIds, int usuaCreacion)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", roleId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", usuaCreacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            // Asignar cada pantalla al rol
            foreach (var pantId in pantIds)
            {
                parameter.Add("@Pant_Id", pantId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var result = db.Execute(ScriptsDataBase.PantallasPorRol_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (result == 0)
                {
                    return new RequestStatus { CodeStatus = 0, MessageStatus = "Error al asignar alguna pantalla al rol." };
                }
            }

            return new RequestStatus { CodeStatus = 1, MessageStatus = "Pantallas asignadas correctamente al rol." };
        }


        // Actualizar un rol
        public RequestStatus Update(tbRoles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Role_Id", item.Role_Id);
            parameters.Add("@Role_Descripcion", item.Role_Descripcion);
            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion);
            parameters.Add("@Feca_Modificacion", item.Feca_Modificacion);

            using var dbConnection = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = dbConnection.Execute("UPDATE tbRoles SET Role_Descripcion = @Role_Descripcion, Usua_Modificacion = @Usua_Modificacion, Feca_Modificacion = @Feca_Modificacion WHERE Role_Id = @Role_Id", parameters);

            string message = result > 0 ? "Rol actualizado correctamente" : "Error al actualizar el rol";
            return new RequestStatus { CodeStatus = result, MessageStatus = message };
        }

        // Buscar un rol por ID
        public tbRoles Find(int? id)
        {
            using var dbConnection = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = dbConnection.QueryFirstOrDefault<tbRoles>("SELECT * FROM tbRoles WHERE Role_Id = @Role_Id", new { Role_Id = id });
            return result;
        }

        // Eliminar un rol
        public RequestStatus Delete(tbRoles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Role_Id", item.Role_Id);

            using var dbConnection = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = dbConnection.Execute("DELETE FROM tbRoles WHERE Role_Id = @Role_Id", parameters);

            string message = result > 0 ? "Rol eliminado correctamente" : "Error al eliminar el rol";
            return new RequestStatus { CodeStatus = result, MessageStatus = message };
        }
    }


}
