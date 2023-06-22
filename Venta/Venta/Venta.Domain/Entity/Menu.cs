using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Venta.Domain.Core;

namespace Venta.Domain.Entity
{
    public class Menu:BaseEntity
    {
        [Key]
        public int idMenu { get; set; }
        public string? nombre { get; set; }
        public string? icono { get; set; }
        public string? url { get; set; }
    }
}
