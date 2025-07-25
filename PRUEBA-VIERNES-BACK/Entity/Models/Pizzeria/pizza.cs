using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.Base;

namespace Entity.Models.Pizzeria
{
    public class Pizza : GenericModel
    {
        public decimal Precio { get; set; }
    }

}
