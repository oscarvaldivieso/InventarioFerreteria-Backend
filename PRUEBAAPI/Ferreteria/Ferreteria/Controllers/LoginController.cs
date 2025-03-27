using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public LoginController(UsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public class LoginRequest
        {
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
        }

       
    }
}
