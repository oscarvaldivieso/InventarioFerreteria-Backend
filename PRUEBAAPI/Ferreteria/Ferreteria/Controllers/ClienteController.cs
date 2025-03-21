using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class ClienteController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public ClienteController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarCliente")]
        public IActionResult List()
        {
            var list = _generalServices.ListClientes();
            list = _mapper.Map<IEnumerable<tbClientes>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarCliente")]
        public IActionResult Insert([FromBody] ClientesViewModel item)
        {
            var mapped = _mapper.Map<tbClientes>(item);
            var insert = _generalServices.InsertCliente(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarCliente")]
        public IActionResult Update([FromBody] ClientesViewModel item)
        {
            var mapped = _mapper.Map<tbClientes>(item);
            var update = _generalServices.UpdateCliente(mapped);
            return Ok(update);
        }

        [HttpDelete("EliminarCliente")]
        public IActionResult Delete([FromBody] ClientesViewModel item)
        {
            var mapped = _mapper.Map<tbClientes>(item);
            var delete = _generalServices.DeleteCliente(mapped);
            return Ok(delete);
        }
    }
}