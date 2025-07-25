using AutoMapper;
using Entity.DTOs;
using Entity.DTOs.Pizzeria;
using Entity.Models;
using Entity.Models.Pizzeria;
namespace Utilities.Helper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            //Mapeo de la entidad Rol 
            CreateMap<Role, RolDto>().ReverseMap();

            //Mapeo de la entidad User
            CreateMap<User, UserDTO>() .ReverseMap();

            CreateMap<Pizza, pizzaDto>().ReverseMap();

            CreateMap<Pedido, PedidoDto>()
                .ForMember(des =>des.EstadoPedidoNombre, opt => opt.MapFrom(src => src.EstadoPedido.Nombre))
                .ForMember(des => des.NombrePizza, opt => opt.MapFrom(src => src.Pizza.Nombre))
                .ForMember(des => des.NombreCliente, opt => opt.MapFrom(src => src.Cliente.Nombre))
                .ReverseMap();
            CreateMap<EstadoPedido, EstadoPedidoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();



            //Mapeo de la entidad UserROl
            CreateMap<UserRoles, UserRolDto>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
             .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Rol.Nombre))
             .ReverseMap();

        }
    }
}
