using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class SucursalController : Controller
    {
        private readonly FerreteriaServices _ferreteriaServices;
        private readonly IMapper _mapper;

        public SucursalController(FerreteriaServices ferreteriaServices, IMapper mapper)
        {
            _ferreteriaServices = ferreteriaServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarSucursales")]
        public IActionResult List()
        {
            var list = _ferreteriaServices.ListSucursales();
            list = _mapper.Map<IEnumerable<tbSucursales>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarSucursal")]
        public IActionResult Insert([FromBody] SucursalesViewModel item)
        {
            var mapped = _mapper.Map<tbSucursales>(item);
            var insert = _ferreteriaServices.InsertSucursak(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarSucursal")]
        public IActionResult Update([FromBody] SucursalesViewModel item)
        {
            var mapped = _mapper.Map<tbSucursales>(item);
            var update = _ferreteriaServices.UpdateSucursal(mapped);
            return Ok(update);
        }

        [HttpPost("EliminarSucursal")]
        public IActionResult Delete([FromBody] SucursalesViewModel item)
        {
            var mapped = _mapper.Map<tbSucursales>(item);
            var delete = _ferreteriaServices.DeleteSucursal(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarSucursal")]
        public IActionResult Find([FromBody] SucursalesViewModel item)
        {
            var mapped = _mapper.Map<tbSucursales>(item);
            var list = _ferreteriaServices.BuscarSucursal   (mapped);
            return Ok(list);
        }
    }
}
