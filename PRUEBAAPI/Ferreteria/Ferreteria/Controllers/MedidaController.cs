using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class MedidaController : Controller
    {
        private readonly ProductoServices _productoServices;
        private readonly IMapper _mapper;

        public MedidaController(ProductoServices productoServices, IMapper mapper)
        {
            _productoServices = productoServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarMedidas")]
        public IActionResult List()
        {
            var list = _productoServices.ListMedidas();
            list = _mapper.Map<IEnumerable<tbMedidas>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarMedida")]
        public IActionResult Insert([FromBody] MedidasViewModel item)
        {
            var mapped = _mapper.Map<tbMedidas>(item);
            var insert = _productoServices.InsertMedida(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarMedida")]
        public IActionResult Update([FromBody] MedidasViewModel item)
        {
            var mapped = _mapper.Map<tbMedidas>(item);
            var update = _productoServices.UpdateMedida(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarMedida")]
        public IActionResult Delete([FromBody] MedidasViewModel item)
        {
            var mapped = _mapper.Map<tbMedidas>(item);
            var delete = _productoServices.DeleteMedida(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarMedida")]
        public IActionResult Find([FromBody] MedidasViewModel item)
        {
            var mapped = _mapper.Map<tbMedidas>(item);
            var list = _productoServices.BuscarMedida(mapped);
            return Ok(list);
        }
    }
}
