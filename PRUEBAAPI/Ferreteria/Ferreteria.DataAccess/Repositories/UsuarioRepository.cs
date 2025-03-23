using Dapper;
using Ferreteria.Entities.Entities;
using FerreteriaEntities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.DataAccess.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para iniciar sesión
        public async Task<UsuarioLoginResponse?> IniciarSesion(string usuario, string contrasena)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new
                {
                    usuario,
                    contrasena
                };

                // Ejecuta el procedimiento almacenado y devuelve el resultado
                return await connection.QueryFirstOrDefaultAsync<UsuarioLoginResponse>(
                    ScriptsDataBase.IniciarSesion, // El nombre del procedimiento almacenado
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        private FerreteriaContext db = new FerreteriaContext();

        public tbUsuarios FindUsua(int? id)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUsuarios> FindUsuaId(tbUsuarios? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbUsuarios>(ScriptsDataBase.Usuario_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Nombre", item.Usua_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Clave", item.Usua_Clave, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Id", item.Empl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsAdmin", item.Usua_EsAdmin, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Usuario_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbUsuarios> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Query<tbUsuarios>(ScriptsDataBase.Usuario_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbUsuarios item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Nombre", item.Usua_Nombre, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Clave", item.Usua_Clave, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Id", item.Empl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsAdmin", item.Usua_EsAdmin, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Usuario_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public RequestStatus Delete(tbUsuarios item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Usuario_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
