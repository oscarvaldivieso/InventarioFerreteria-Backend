using Dapper;
using Ferreteria.Entities.Entities;
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
        public RequestStatus UpdateWithScreens(tbRoles item, List<int> pantIds)
        {
            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            db.Open();
            using var transaction = db.BeginTransaction(); // Iniciar transacción

            try
            {
                // 1️⃣ Actualizar los datos del rol
                var parameter = new DynamicParameters();
                parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Role_Descripcion", item.Role_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

                db.Execute(ScriptsDataBase.Roles_Actualizar, parameter, transaction, commandType: System.Data.CommandType.StoredProcedure);

                // 2️⃣ Eliminar las pantallas actuales asociadas al rol
                var deleteParam = new DynamicParameters();
                deleteParam.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                db.Execute(ScriptsDataBase.PantallasPorRol_Eliminar, deleteParam, transaction, commandType: System.Data.CommandType.StoredProcedure);

                // 3️⃣ Insertar las nuevas pantallas asociadas al rol
                foreach (var pantId in pantIds)
                {
                    var pantParam = new DynamicParameters();
                    pantParam.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    pantParam.Add("@Pant_Id", pantId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    pantParam.Add("@Usua_Creacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    pantParam.Add("@Feca_Creacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

                    db.Execute(ScriptsDataBase.PantallasPorRol_Insertar, pantParam, transaction, commandType: System.Data.CommandType.StoredProcedure);
                }

                transaction.Commit(); // Confirmar la transacción

                return new RequestStatus { CodeStatus = 1, MessageStatus = "Rol actualizado correctamente" };
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Revertir cambios en caso de error
                return new RequestStatus { CodeStatus = -1, MessageStatus = $"Error: {ex.Message}" };
            }
        }

        // Buscar un rol por ID
        public RolDetalles FindRolById(int roleId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", roleId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString); // Corrige la conexión
            var result = db.Query<RolDetalles>(
                "Acce.SP_Rol_Buscar", // Procedimiento almacenado
                parameter,
                commandType: System.Data.CommandType.StoredProcedure
            ).FirstOrDefault();

            return result;
        }

        // Eliminar un rol
        public RequestStatus Delete(tbRoles item)
        {
            using var dbConnection = new SqlConnection(FerreteriaContext.ConnectionString);
            dbConnection.Open();
            using var transaction = dbConnection.BeginTransaction(); // Iniciar transacción

            try
            {
                // 1️⃣ Eliminar las pantallas asociadas al rol en la tabla intermedia
                var deletePantallasParam = new DynamicParameters();
                deletePantallasParam.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                dbConnection.Execute(ScriptsDataBase.PantallasPorRol_Eliminar, deletePantallasParam, transaction, commandType: System.Data.CommandType.StoredProcedure);

                // 2️⃣ Eliminar el rol usando el procedimiento almacenado SP_Rol_Eliminar
                var deleteRolParam = new DynamicParameters();
                deleteRolParam.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var result = dbConnection.Execute(ScriptsDataBase.Roles_Eliminar, deleteRolParam, transaction, commandType: System.Data.CommandType.StoredProcedure);

                // Confirmar la transacción si ambas eliminaciones fueron exitosas
                transaction.Commit();

                // Determinar el mensaje de acuerdo al resultado de la eliminación
                string message = result > 0 ? "Rol y pantallas eliminados correctamente" : "Error al eliminar el rol";
                return new RequestStatus { CodeStatus = result, MessageStatus = message };
            }
            catch (Exception ex)
            {
                // En caso de error, revertir la transacción
                transaction.Rollback();
                return new RequestStatus { CodeStatus = -1, MessageStatus = $"Error: {ex.Message}" };
            }
        }


        public RequestStatus Insert(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public tbRoles Find(int? id)
        {
            throw new NotImplementedException();
        }
    }


}
