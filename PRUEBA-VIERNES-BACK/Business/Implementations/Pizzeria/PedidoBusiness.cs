using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Classes.Base;
using Data.Interfases;
using Entity.DTOs.Pizzeria;
using Entity.Models.Pizzeria;
using Microsoft.Extensions.Logging;

namespace Business.Implementations.Pizzeria
{
    public class PedidoBusiness : BaseBusiness<Pedido, PedidoDto>
    {
        public PedidoBusiness(ICrudBase<Pedido> data, ILogger<Pedido> logger, IMapper mapper) : base(data, logger, mapper)
        {
        }
    }
}
