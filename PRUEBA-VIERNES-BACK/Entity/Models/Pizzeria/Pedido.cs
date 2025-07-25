using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.Base;

namespace Entity.Models.Pizzeria
{
    public class Pedido : BaseModel
    {
        public int ClienteId { get; set; }

        public int PizzaId { get; set; }
        public int Cantidad { get; set; }

       

        public int EstadoPedidoId { get; set; }
        public DateTime? Fecha { get; set; }

        public Pizza Pizza { get; set; } = null!;

        public Cliente Cliente { get; set; } = null!;
        public EstadoPedido EstadoPedido { get; set; } = null!;
    }

}
