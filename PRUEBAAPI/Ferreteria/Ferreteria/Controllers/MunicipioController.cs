using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Ferreteria.Models;
using FerreteriaEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public MunicipioController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarMunicipios")]
        public IActionResult List()
        {
            var list = _generalServices.ListMunicipios();
            list = _mapper.Map<IEnumerable<tbMunicipios>>(list);
            return Ok(list);
        }

        [HttpPost("InsertarMunicipio")]
        public IActionResult Insert([FromBody] MunicipiosViewModel item)
        {
            var mapped = _mapper.Map<tbMunicipios>(item);
            var insert = _generalServices.InsertMunicipio(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarMunicipio")]
        public IActionResult Update([FromBody] MunicipiosViewModel item)
        {
            var mapped = _mapper.Map<tbMunicipios>(item);
            var update = _generalServices.UpdateMunicipio(mapped);
            return Ok(update);
        }

        [HttpDelete("EliminarMunicipio")]
        public IActionResult Delete([FromBody] MunicipiosViewModel item)
        {
            var mapped = _mapper.Map<tbMunicipios>(item);
            var delete = _generalServices.DeleteMunicipio(mapped);
            return Ok(delete);
        }

        [HttpPost("BuscarMunicipio")]
        public IActionResult Find([FromBody] MunicipiosViewModel item)
        {
            var mapped = _mapper.Map<tbMunicipios>(item);
            var list = _generalServices.BuscarMunicipio(mapped);
            return Ok(list);
        }
    }
}