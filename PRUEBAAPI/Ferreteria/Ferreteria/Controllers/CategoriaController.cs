using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ProductoServices _productoServices;
        private readonly IMapper _mapper;

        public CategoriaController(ProductoServices productoServices, IMapper mapper)
        {
            _productoServices = productoServices;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarCategorias")]
        public IActionResult List()
        {
            var list = _productoServices.ListCategorias();
            list = _mapper.Map<IEnumerable<tbCategorias>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarCategoria")]
        public IActionResult Insert([FromBody] CategoriasViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var insert = _productoServices.InsertCategoria(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarCategoria")]
        public IActionResult Update([FromBody] CategoriasViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var update = _productoServices.UpdateCategoria(mapped);
            return Ok(update);
        }

        [HttpDelete("EliminarCategoria")]
        public IActionResult Delete([FromBody] CategoriasViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var delete = _productoServices.DeleteCategoria(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarCategoria")]
        public IActionResult Find([FromBody] CategoriasViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var result = _productoServices.BuscarCategoria(mapped);
            return Ok(result);
        }
    }
}
