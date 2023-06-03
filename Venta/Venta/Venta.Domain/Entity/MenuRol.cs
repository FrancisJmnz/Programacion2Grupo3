using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Core;

namespace Venta.Domain.Entity
{
    public class MenuRol:BaseEntity
    {
        public int idMenuRol { get; set; }
        public string? idMenu { get; set; }
        public string? idRol { get; set; }
        public string? url { get; set; }
        

    }
}
