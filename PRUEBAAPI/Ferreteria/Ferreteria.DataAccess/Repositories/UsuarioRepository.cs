using Dapper;
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

        public async Task<UsuarioLoginResponse> IniciarSesion(string usuario, string contrasena)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new
                {
                    usuario,
                    contrasena
                };

                return await connection.QueryFirstOrDefaultAsync<UsuarioLoginResponse>(
                    "Acce.SP_Usuarios_InicioSesion",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
