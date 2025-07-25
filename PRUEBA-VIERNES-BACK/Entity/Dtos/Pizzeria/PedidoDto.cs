using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Base;

namespace Entity.DTOs.Pizzeria
{
    public class PedidoDto : BaseDTO
    {
        public int ClienteId { get; set; }
        public string? NombreCliente { get; set; }
        public int PizzaId { get; set; }

        public string? NombrePizza { get; set; }
        public int Cantidad { get; set; }

        public int EstadoPedidoId { get; set; }
        public string? EstadoPedidoNombre { get; set; }

        public DateTime? Fecha { get; set; } = null;

    }

}
