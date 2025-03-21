using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class MarcaController : Controller
    {
        private readonly ProductoServices _productoServices;
        private readonly IMapper _mapper;

        public MarcaController(ProductoServices productoServices, IMapper mapper)
        {
            _productoServices = productoServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarMarcas")]
        public IActionResult List()
        {
            var list = _productoServices.ListMarcas();
            list = _mapper.Map<IEnumerable<tbMarcas>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarMarca")]
        public IActionResult Insert([FromBody] MarcasViewModel item)
        {
            var mapped = _mapper.Map<tbMarcas>(item);
            var insert = _productoServices.InsertMarca(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarMarca")]
        public IActionResult Update([FromBody] MarcasViewModel item)
        {
            var mapped = _mapper.Map<tbMarcas>(item);
            var update = _productoServices.UpdateMarca(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarMarca")]
        public IActionResult Delete([FromBody] MarcasViewModel item)
        {
            var mapped = _mapper.Map<tbMarcas>(item);
            var delete = _productoServices.DeleteMarca(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarMarca")]
        public IActionResult Find([FromBody] MarcasViewModel item)
        {
            var mapped = _mapper.Map<tbMarcas>(item);
            var list = _productoServices.BuscarMarca(mapped);
            return Ok(list);
        }
    }
}
