using Business.Classes;
using Business.Classes.Base;
using Business.Implementations.Pizzeria;
using Business.Interfases;
using Business.Services.Auth;
using Business.Services.JWT;
using Data.Classes.Specifics;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Pizzeria;
using Entity.Models;
using Entity.Models.Pizzeria;

namespace Web.Extensions
{
    public static class ServiceExtensionsScoped
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            //User 
            services.AddScoped<UserData>();
            services.AddScoped<ICrudBase<User>, UserData>();
            services.AddScoped<UserBusiness>();
            services.AddScoped<IBaseBusiness<User, UserDTO>, UserBusiness>();

            //UserRole 
            services.AddScoped<UserRoleData>();
            services.AddScoped<ICrudBase<UserRoles>, UserRoleData>();
            services.AddScoped<UserRoleBusiness>();
            services.AddScoped<IBaseBusiness<UserRoles, UserRolDto>, UserRoleBusiness>();

            //Cliente
            services.AddScoped<ClienteData>();
            services.AddScoped<ICrudBase<Cliente>, ClienteData>();
            services.AddScoped<ClienteBusiness>();
            services.AddScoped<IBaseBusiness<Cliente, ClienteDto>, ClienteBusiness>();

            //Pizza
            services.AddScoped<PizzaData>();
            services.AddScoped<ICrudBase<Pizza>, PizzaData>();
            services.AddScoped<PizzaBusiness>();
            services.AddScoped<IBaseBusiness<Pizza, pizzaDto>, PizzaBusiness>();


            //Pedido
            services.AddScoped<PedidoData>();
            services.AddScoped<ICrudBase<Pedido>, PedidoData>();
            services.AddScoped<PedidoBusiness>();
            services.AddScoped<IBaseBusiness<Pedido, PedidoDto>, PedidoBusiness>();


            //EstadoPedido
            services.AddScoped<EstadoPedidoData>();
            services.AddScoped<ICrudBase<EstadoPedido>, EstadoPedidoData>();
            services.AddScoped<EstadoPedidoBusiness>();
            services.AddScoped<IBaseBusiness<EstadoPedido, EstadoPedidoDto>, EstadoPedidoBusiness>();
            //Auth 
            services.AddScoped<UserService>();

            services.AddScoped<AuthService>();
            services.AddScoped<JwtService>();

          
            return services;
        }
    }
}

