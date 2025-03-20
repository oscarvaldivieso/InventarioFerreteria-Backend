using AutoMapper;
using Ferreteria.BussinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Controllers
{
    public class CargoController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public CargoController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarCargos")]
        public IActionResult List()
        {
            var result = _generalServices.Lis
        }
    }
}