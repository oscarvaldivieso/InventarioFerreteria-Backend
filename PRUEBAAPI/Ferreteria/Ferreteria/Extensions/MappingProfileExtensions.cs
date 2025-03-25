using AutoMapper;
using Ferreteria.Entities.Entities;
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
            CreateMap<tbClientes, ClientesViewModel>().ReverseMap();
            CreateMap<tbCargos, CargosViewModel>().ReverseMap();
            CreateMap<tbCategorias, CategoriasViewModel>().ReverseMap();
            CreateMap<tbMarcas, MarcasViewModel>().ReverseMap();
            CreateMap<tbMedidas, MedidasViewModel>().ReverseMap();
            CreateMap<tbUsuarios, UsuariosViewModel>().ReverseMap();
            CreateMap<tbEmpleados, EmpleadosViewModel>().ReverseMap();
            CreateMap<tbSucursales, SucursalesViewModel>().ReverseMap();
            CreateMap<tbProductos, ProductosViewModel>().ReverseMap();
            CreateMap<tbProveedores, ProveedoresViewModel>().ReverseMap();
            CreateMap<tbRoles, RolViewModel>().ReverseMap();
            CreateMap<RolDetalles, RolDetallesViewModel>()
            .ForMember(dest => dest.PantIds,
                       static opt => opt.MapFrom(src => src.PantIds.Split(',').Select(int.Parse).ToList()))
            .ForMember(dest => dest.PantNombres,
                       opt => opt.MapFrom(src => string.Join(",", src.PantNombres)));
        }
    }
}