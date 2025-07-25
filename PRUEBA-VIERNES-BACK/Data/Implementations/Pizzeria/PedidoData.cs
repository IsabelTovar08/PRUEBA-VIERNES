using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes.Base;
using Entity.Context;
using Entity.Models;
using Entity.Models.Pizzeria;
using Microsoft.Extensions.Logging;

namespace Business.Implementations.Pizzeria
{
    public class PedidoData: BaseData<Pedido>
    {
        public PedidoData(ApplicationDbContext context, ILogger<Pedido> logger) : base(context, logger)
        {

        }
    }
}
