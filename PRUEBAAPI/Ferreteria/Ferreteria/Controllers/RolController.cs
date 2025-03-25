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

        [HttpPut("EditarRol")]
        public IActionResult Update([FromBody] RolViewModel item)
        {
            var mapped = _mapper.Map<tbRoles>(item);
            var update = _accesoServices.UpdateRol(mapped, item.PantIds);
            return Ok(update);
        }

        [HttpPost("EliminarRol")]
        public IActionResult Delete([FromBody] RolViewModel item)
        {
            try
            {
                var mapped = _mapper.Map<tbRoles>(item);
                var result = _accesoServices.DeleteRol(mapped);  // Llamamos al servicio DeleteRol
                if (result.Success)  // Verificamos si la operación fue exitosa
                {
                    return Ok(result);  // Retornamos una respuesta exitosa
                }
                return BadRequest(result);  // Si algo falla, retornamos un BadRequest con el resultado del error
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });  // En caso de error inesperado, retornamos 500
            }
        }

        [HttpPost("BuscarRol")]
        public IActionResult FindRolById([FromBody] int id)
        {
            var result = _accesoServices.FindRolById(id);
            if (result.Success)
            {
                var mapped = _mapper.Map<RolViewModel>(result.Data);
                return Ok(mapped);
            }
            return NotFound(result.Message);
        }



    }
}
