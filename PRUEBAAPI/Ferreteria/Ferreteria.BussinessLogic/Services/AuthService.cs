using Ferreteria.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{
    public class AuthService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public AuthService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResult> Login(string usuario, string contrasena)
        {
            var user = await _usuarioRepository.IniciarSesion(usuario, contrasena);

            if (user == null)
                return new ServiceResult { Success = false, Message = "Usuario o contraseña incorrectos" };

            return new ServiceResult { Success = true, Data = user };
        }
    }
}
