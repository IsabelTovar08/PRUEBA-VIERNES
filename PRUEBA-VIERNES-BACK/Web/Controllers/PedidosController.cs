using Business.Classes;
using Business.Interfases;
using Entity.DTOs;
using Entity.DTOs.Pizzeria;
using Entity.Models;
using Entity.Models.Pizzeria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exeptions;
using Web.Controllers.Base;

namespace Web.Controllers.ModelSecurity
{
    public class PedidoController : GenericController<Pedido, PedidoDto>
    {
        public PedidoController(IBaseBusiness<Pedido, PedidoDto> business, ILogger<PedidoController> logger) : base(business, logger)
        {
        }
    }
}

