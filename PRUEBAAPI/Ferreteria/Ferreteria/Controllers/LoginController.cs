using Ferreteria.BussinessLogic.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public LoginController()
        {
            string connectionString = "Server = dbFerreteria.mssql.somee.com; Database = dbFerreteria; User Id= SOLANGRI69_SQLLogin_1; Password = Admin123ñ; TrustServerCertificate = True;"; // Pasa tu cadena de conexión aquí
            _usuarioService = new UsuarioService(connectionString);
        }

        public class LoginRequest
        {
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
        }

        [HttpPost("login")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginRequest loginRequest)
        {
            // Se supone que LoginRequest tiene las propiedades Usuario y Contrasena
            var usuario = await _usuarioService.ValidarLogin(loginRequest.Usuario, loginRequest.Contrasena);

            if (usuario == null)
            {
                return Unauthorized("Credenciales inválidas");
            }

            return Ok(usuario);
        }
    }
}
