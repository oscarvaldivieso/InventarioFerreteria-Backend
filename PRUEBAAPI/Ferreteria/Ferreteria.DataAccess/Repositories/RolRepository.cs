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

        

        public RequestStatus InsertWithScreens(tbRoles item, List<int> pantIds)
        {
            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            db.Open();
            using var transaction = db.BeginTransaction(); // Inicia la transacción

            try
            {
                // Insertar el rol y obtener el Role_Id
                var parameter = new DynamicParameters();
                parameter.Add("@Role_Descripcion", item.Role_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
                parameter.Add("@Role_Id", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output); // Obtener ID

                db.Execute(ScriptsDataBase.Roles_Insertar, parameter, transaction, commandType: System.Data.CommandType.StoredProcedure);
                int roleId = parameter.Get<int>("@Role_Id"); // Obtener el ID generado

                // Insertar las pantallas en la tabla intermedia
                foreach (var pantId in pantIds)
                {
                    var pantParam = new DynamicParameters();
                    pantParam.Add("@Role_Id", roleId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    pantParam.Add("@Pant_Id", pantId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    pantParam.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    pantParam.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

                    db.Execute(ScriptsDataBase.PantallasPorRol_Insertar, pantParam, transaction, commandType: System.Data.CommandType.StoredProcedure);
                }

                transaction.Commit(); // Confirmar la transacción

                return new RequestStatus { CodeStatus = 1, MessageStatus = "Rol y pantallas asignadas correctamente" };
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Revertir cambios en caso de error
                return new RequestStatus { CodeStatus = -1, MessageStatus = $"Error: {ex.Message}" };
            }
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

        public RequestStatus Insert(tbRoles item)
        {
            throw new NotImplementedException();
        }
    }


}
