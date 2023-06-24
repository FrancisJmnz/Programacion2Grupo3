using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Application.Dtos.MenuRol
{
    public  abstract class menurolDto : DtoBase
    {
        public int idMenuRol { get; set; }
        public int? idMenu { get; set; }
        public int? idRol { get; set; }
    }
}
