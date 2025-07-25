using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Base;
using Entity.Models.Base;

namespace Entity.Models.Pizzeria
{
    public class pizzaDto : GenericDTO
    {
        public decimal Precio { get; set; }
    }

}
