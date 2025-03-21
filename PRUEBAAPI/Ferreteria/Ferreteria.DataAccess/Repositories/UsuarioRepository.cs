using Dapper;
using Ferreteria.Entities.Entities;
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
    }
}
