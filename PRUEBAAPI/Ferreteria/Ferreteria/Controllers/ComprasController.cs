using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.DataAccess.Repositories;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class ComprasController : Controller
    {
        private readonly CompraServices _compraServices;
        private readonly IMapper _mapper;

        public ComprasController(CompraServices compraServices, IMapper mapper)
        {
            _compraServices = compraServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarCompras")]
        public IActionResult List()
        {
            var list = _compraServices.ListCompras();
            list = _mapper.Map<IEnumerable<tbCompras>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarCompra")]
        public IActionResult Insert([FromBody] CompraViewModel item)
        {
            var mapped = _mapper.Map<tbCompras>(item);
            var insert = _compraServices.InsertCompra(mapped);
            return Ok(insert);
        }
        [HttpPost("InsertarCompraDetalle")]
        public IActionResult InsertDetalle([FromBody] CompraDetalleViewModel cpde)
        {
            var mapped = _mapper.Map<tbComprasDetalles>(cpde);
            var insert = _compraServices.InsertCompraDetalle(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarCompra")]
        public IActionResult Update([FromBody] CompraViewModel item)
        {
            var mapped = _mapper.Map<tbCompras>(item);
            var update = _compraServices.UpdateCompra(mapped);
            return Ok(update);
        }
        [HttpPut("ActualizarCompraDetalle")]
        public IActionResult UpdateDetalle([FromBody] CompraDetalleViewModel item)
        {
            var mapped = _mapper.Map<tbComprasDetalles>(item);
            var update = _compraServices.UpdateCompraDetalle(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarCompra")]
        public IActionResult Delete([FromBody] CompraViewModel item, CompraDetalleViewModel cpde)
        {
            var mapped = _mapper.Map<tbCompras>(item);
            var mapped2 = _mapper.Map<tbComprasDetalles>(cpde);
            var delete = _compraServices.DeleteCompra(mapped, mapped2);
            return Ok(delete);
        }

        [HttpPost("BuscarCompra")]
        public IActionResult Find([FromBody] CompraViewModel item)
        {
            var mapped = _mapper.Map<tbCompras>(item);
            var list = _compraServices.BuscarCompra(mapped);
            list = _mapper.Map<IEnumerable<tbCompras>>(list);
            return Ok(list);
        }
    }
}
