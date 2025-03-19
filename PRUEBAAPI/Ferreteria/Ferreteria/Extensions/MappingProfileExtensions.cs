using AutoMapper;
using Ferreteria.Models;
using FerreteriaEntities.Entities;

namespace Ferreteria.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<tbDepartamentos, DepartamentosViewModel>().ReverseMap();
            CreateMap<tbEstadosCiviles, EstadosCivilesViewModel>().ReverseMap();
            CreateMap<tbMunicipios, MunicipiosViewModel>().ReverseMap();
        }
    }
}