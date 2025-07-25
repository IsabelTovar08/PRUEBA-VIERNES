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
    public class EstadoPedidoBusiness : BaseBusiness<EstadoPedido, EstadoPedidoDto>
    {
        public EstadoPedidoBusiness(ICrudBase<EstadoPedido> data, ILogger<EstadoPedido> logger, IMapper mapper) : base(data, logger, mapper)
        {
        }
    }
}
