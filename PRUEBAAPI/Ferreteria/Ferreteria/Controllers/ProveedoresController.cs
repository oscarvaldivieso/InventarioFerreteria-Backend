using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly CompraServices _compraServices;
        private readonly IMapper _mapper;

        public ProveedoresController(CompraServices compraServices, IMapper mapper)
        {
            _compraServices = compraServices;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarProveedores")]
        public IActionResult List()
        {
            var list = _compraServices.ListProveedores();
            list = _mapper.Map<IEnumerable<tbProveedores>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarProveedor")]
        public IActionResult Insert([FromBody] ProveedoresViewModel item)
        {
            var mapped = _mapper.Map<tbProveedores>(item);
            var insert = _compraServices.InsertProveedor(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarProveedor")]
        public IActionResult Update([FromBody] ProveedoresViewModel item)
        {
            var mapped = _mapper.Map<tbProveedores>(item);
            var update = _compraServices.UpdateProveedor(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarProveedor")]
        public IActionResult Delete([FromBody] ProveedoresViewModel item)
        {
            var mapped = _mapper.Map<tbProveedores>(item);
            var delete = _compraServices.DeleteProveedor(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarProveedor")]
        public IActionResult Find([FromBody] ProveedoresViewModel item)
        {
            var mapped = _mapper.Map<tbProveedores>(item);
            var list = _compraServices.BuscarProveedor(mapped);
            return Ok(list);
        }
    }
}
