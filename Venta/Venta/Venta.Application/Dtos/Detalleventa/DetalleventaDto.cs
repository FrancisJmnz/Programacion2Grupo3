using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Application.Dtos.Detalleventa
{
    public abstract class DetalleventaDto : DtoBase
    {
        public int idDetalleVenta { get; set; }
        public int? idVenta { get; set; }
        public int? idProducto { get; set; }
        public int? cantidad { get; set; }
        public decimal? precio { get; set; }
        public decimal? total { get; set; }
    }
}