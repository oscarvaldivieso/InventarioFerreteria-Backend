using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class EstadoCivilController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public EstadoCivilController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarEstadoCivil")]
        public IActionResult List()
        {
            var list = _generalServices.ListEstadoCivil();
            return Ok(list);
        }

        [HttpPost("InsertarEstadoCivil")]
        public IActionResult Insert([FromBody] tbEstadosCiviles item)
        {
            var mapped = _mapper.Map<tbEstadosCiviles>(item);
            var insert = _generalServices.InsertEstadoCivil(item);
            return Ok(insert);
        }

        [HttpPut("ActualizarEstadoCivil")]
        public IActionResult Update([FromBody] tbEstadosCiviles item)
        {
            var mapped = _mapper.Map<tbEstadosCiviles>(item);
            var update = _generalServices.UpdateEstadoCivil(item);
            return Ok(update);
        }

        [HttpDelete("EliminarEstadoCivil")]
        public IActionResult Delete([FromBody] tbEstadosCiviles item)
        {
            var mapped = _mapper.Map<tbEstadosCiviles>(item);
            var delete = _generalServices.DeleteEstadoCivil(item);
            return Ok(delete);
        }
    }
}