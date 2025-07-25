using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Base;
using Entity.Models.Base;

namespace Entity.DTOs.Pizzeria
{
    public class ClienteDto :GenericDTO
    {
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }

}
