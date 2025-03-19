using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public DepartamentoController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarDepartamento")]
        public IActionResult List()
        {
            var list = _generalServices.ListDepartamentos();
            list = _mapper.Map<IEnumerable<tbDepartamentos>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarDepartamento")]
        public IActionResult Insert([FromBody] tbDepartamentos item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var insert = _generalServices.InsertDepartamento(item);
            return Ok(insert);
        }

        [HttpPut("ActualizarDepartamento")]
        public IActionResult Update([FromBody] tbDepartamentos item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var update = _generalServices.UpdateDepartamento(item);
            return Ok(update);
        }

        [HttpDelete("EliminarDepartamento")]
        public IActionResult Delete([FromBody] tbDepartamentos item)
        {
            var delete = _generalServices.DeleteDepartamento(item);
            return Ok(delete);
        }
    }
}