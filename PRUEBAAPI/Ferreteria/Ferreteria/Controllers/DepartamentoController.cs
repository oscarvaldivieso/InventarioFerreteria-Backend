using Ferreteria.BussinessLogic.Services;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly GeneralServices _generalServices;
        public DepartamentoController(GeneralServices generalServices)
        {
            _generalServices = generalServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarDepartamento")]
        public IActionResult List()
        {
            var list = _generalServices.ListDepartamentos();
            return Ok(list);
        }

        [HttpPost("InsertarDepartamento")]
        public IActionResult Insert([FromBody]tbDepartamentos item)
        {
            var insert = _generalServices.InsertDepartamento(item);
            return Ok(insert);
        }
    }
}
