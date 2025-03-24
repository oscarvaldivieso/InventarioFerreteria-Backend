using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class RolController : Controller
    {

        private readonly AccesoServices _accesoServices;
        private readonly IMapper _mapper;

        public RolController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("ListarRoles")]
        public IActionResult List()
        {
            var list = _accesoServices.ListRoles();
            var mappedList = _mapper.Map<IEnumerable<tbRoles>>(list);
            return Ok(mappedList);
        }

        [HttpPost("InsertarRol")]
        public IActionResult Insert([FromBody] RolViewModel item)
        {
            var mapped = _mapper.Map<tbRoles>(item);
            var insert = _accesoServices.InsertRol(mapped, item.PantIds); // Pasamos la lista de pantallas
            return Ok(insert);
        }
    }
}
