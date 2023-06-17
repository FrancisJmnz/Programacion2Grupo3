using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Venta.Domain.Core;

namespace Venta.Domain.Entity
{
    public class venta : BaseEntity
    {
        [Key] 
        public int idVenta { get; set; }
        public string? numeroDocumento { get; set; }
        public string? tipoPago { get; set; }
        public decimal? total { get; set; }

    }
}
