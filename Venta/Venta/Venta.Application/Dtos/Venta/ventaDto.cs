using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Application.Dtos.Venta
{
    public abstract class ventaDto : DtoBase
    {
        public int idVenta { get; set; }
        public string? numeroDocumento { get; set; }
        public string? tipoPago { get; set; }
        public decimal? total { get; set; }
    }
}
