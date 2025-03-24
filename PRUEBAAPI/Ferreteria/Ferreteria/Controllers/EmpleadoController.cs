using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly FerreteriaServices _ferreteriaServices;
        private readonly IMapper _mapper;

        public EmpleadoController(FerreteriaServices ferreteriaServices, IMapper mapper)
        {
            _ferreteriaServices = ferreteriaServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarEmpleado")]
        public IActionResult List()
        {
            var list = _ferreteriaServices.ListEmpleados();
            list = _mapper.Map<IEnumerable<tbEmpleados>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarEmpleado")]
        public IActionResult Insert([FromBody] EmpleadosViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var insert = _ferreteriaServices.InsertEmpleado(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarEmpleado")]
        public IActionResult Update([FromBody] EmpleadosViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var update = _ferreteriaServices.UpdateEmpleado(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarEmpleado")]
        public IActionResult Delete([FromBody] EmpleadosViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var delete = _ferreteriaServices.DeleteEmpleado(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarEmpleado")]
        public IActionResult Find([FromBody] EmpleadosViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var list = _ferreteriaServices.BuscarEmpleado(mapped);
            list = _mapper.Map<IEnumerable<tbEmpleados>>(list);
            return Ok(list);
        }
    }
}
