using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(UsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult IniciarSesion([FromBody] LoginViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var list = _usuarioService.ValidarLogin(mapped);
            return Ok(list);
        }

        [HttpGet("ListarUsuarios")]
        public IActionResult List()
        {
            var list = _usuarioService.ListUsuarios();
            list = _mapper.Map<IEnumerable<tbUsuarios>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarUsuario")]
        public IActionResult Insert([FromBody] UsuariosViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var insert = _usuarioService.InsertUsuario(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarUsuario")]
        public IActionResult Update([FromBody] UsuariosViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var update = _usuarioService.UpdateUsuario(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarUsuario")]
        public IActionResult Delete([FromBody] UsuariosViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var delete = _usuarioService.DeleteUsuario(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarUsuario")]
        public IActionResult Find([FromBody] UsuariosViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var list = _usuarioService.BuscarUsuario(mapped);
            return Ok(list);
        }

        [HttpPost("RestablecerClave")]
        public IActionResult RestablecerClave([FromBody] UsuariosViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var response = _usuarioService.RestablecerClave(mapped);
            return Ok(response);
        }

        [HttpPut("ActivarDesactivarUsuario")]
        public IActionResult ActivarDesactivarUsuario([FromBody] UsuariosViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var response = _usuarioService.ActivarDesactivarUsuario(mapped);
            return Ok(response);
        }
    }
}
