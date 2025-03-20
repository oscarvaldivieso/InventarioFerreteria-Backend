using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
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

        [HttpGet("ListarDepartamentos")]
        public IActionResult List()
        {
            var list = _generalServices.ListDepartamentos();
            list = _mapper.Map<IEnumerable<tbDepartamentos>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarDepartamento")]
        public IActionResult Insert([FromBody] DepartamentosViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var insert = _generalServices.InsertDepartamento(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarDepartamento")]
        public IActionResult Update([FromBody] DepartamentosViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var update = _generalServices.UpdateDepartamento(mapped);
            return Ok(update);
        }

        [HttpDelete("EliminarDepartamento")]
        public IActionResult Delete([FromBody] DepartamentosViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var delete = _generalServices.DeleteDepartamento(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarDepartamento")]
        public IActionResult Find([FromBody] DepartamentosViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var list = _generalServices.BuscarDepartamento(mapped);
            return Ok(list);
        }
    }
}