using Ferreteria.DataAccess.Repositories;
using Ferreteria.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(string connectionString)
        {
            _usuarioRepository = new UsuarioRepository(connectionString);
        }

        public async Task<UsuarioLoginResponse> ValidarLogin(string usuario, string contrasena)
        {
            return await _usuarioRepository.IniciarSesion(usuario, contrasena);
        }
    }
}
