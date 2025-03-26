using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoServices _productoServices;
        private readonly IMapper _mapper;

        public ProductosController(ProductoServices productoServices, IMapper mapper)
        {
            _productoServices = productoServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarProductos")]
        public IActionResult List()
        {
            var list = _productoServices.ListProductos();
            list = _mapper.Map<IEnumerable<tbProductos>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarProducto")]
        public IActionResult Insert([FromBody] ProductosViewModel item)
        {
            var mapped = _mapper.Map<tbProductos>(item);
            var insert = _productoServices.InsertProducto(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarProducto")]
        public IActionResult Update([FromBody] ProductosViewModel item)
        {
            var mapped = _mapper.Map<tbProductos>(item);
            var update = _productoServices.UpdateProducto(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarProducto")]
        public IActionResult Delete([FromBody] ProductosViewModel item)
        {
            var mapped = _mapper.Map<tbProductos>(item);
            var delete = _productoServices.DeleteProducto(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarProducto")]
        public IActionResult Find([FromBody] ProductosViewModel item)
        {
            var mapped = _mapper.Map<tbProductos>(item);
            var list = _productoServices.BuscarProducto(mapped);
            return Ok(list);
        }

        [HttpPost("ProductoPorCategoria")]
        public IActionResult FindCate([FromBody] ProductosViewModel item)
        {
            var mapped = _mapper.Map<tbProductos>(item);
            var list = _productoServices.BuscarCategoria(mapped);
            return Ok(list);
        }
    }
}
