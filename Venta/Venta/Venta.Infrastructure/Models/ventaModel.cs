using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Infrastructure.Models
{
    public class ventaModel
    {
        public int idVenta {get; set;}
        public string? numeroDocumento {get; set;}
        public string? tipoPago {get; set;}
        public decimal? total {get; set;}
    }
}
