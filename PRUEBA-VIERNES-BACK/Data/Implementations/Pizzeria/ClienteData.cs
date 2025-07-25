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
    public class ClienteData : BaseData<Cliente>
    {
        public ClienteData(ApplicationDbContext context, ILogger<Cliente> logger) : base(context, logger)
        {

        }
    }
}
