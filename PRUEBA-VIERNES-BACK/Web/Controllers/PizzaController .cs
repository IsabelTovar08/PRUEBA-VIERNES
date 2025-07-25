using Business.Classes;
using Business.Interfases;
using Entity.DTOs;
using Entity.Models;
using Entity.Models.Pizzeria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exeptions;
using Web.Controllers.Base;

namespace Web.Controllers.ModelSecurity
{
    public class PizzaController : GenericController<Pizza, pizzaDto>
    {
        public PizzaController(IBaseBusiness<Pizza, pizzaDto> business, ILogger<PizzaController> logger) : base(business, logger)
        {
        }
    }
}

