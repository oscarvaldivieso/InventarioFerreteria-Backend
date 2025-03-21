using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class CargoController : Controller
    {
        private readonly FerreteriaServices _ferreteriaServices;
        private readonly IMapper _mapper;

        public CargoController(FerreteriaServices ferreteriaServices, IMapper mapper)
        {
            _ferreteriaServices = ferreteriaServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarCargos")]
        public IActionResult List()
        {
            var list = _ferreteriaServices.ListCargos();
            list = _mapper.Map<IEnumerable<tbCargos>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarCargo")]
        public IActionResult Insert([FromBody] CargosViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var insert = _ferreteriaServices.InsertCargo(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarCargo")]
        public IActionResult Update([FromBody] CargosViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var update = _ferreteriaServices.UpdateCargo(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarCargo")]
        public IActionResult Delete([FromBody] CargosViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var delete = _ferreteriaServices.DeleteCargo(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarCargo")]
        public IActionResult Find([FromBody] CargosViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var list = _ferreteriaServices.BuscarCargo(mapped);
            return Ok(list);
        }
    }
}