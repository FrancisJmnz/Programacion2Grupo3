using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Application.Dtos.Menu
{
    public abstract class menuDto: DtoBase
    {
        
            
            public int idMenu { get; set; }
            public string? nombre { get; set; }
            public string? icono { get; set; }
            public string? url { get; set; }
        
    }
}
