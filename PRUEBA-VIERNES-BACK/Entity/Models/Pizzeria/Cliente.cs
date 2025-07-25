using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.Base;

namespace Entity.Models.Pizzeria
{
    public class Cliente :GenericModel
    {
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
    }

}
