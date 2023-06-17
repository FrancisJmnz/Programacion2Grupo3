using System.ComponentModel.DataAnnotations;
using Venta.Domain.Core;

namespace Venta.Domain.Entity
{
    public class DetalleVenta : BaseEntity
    {
        [Key]
        public int idDetalleVenta { get; set;}
        public int? idVenta { get; set;}
        public int? idProducto { get; set; }
        public int? cantidad { get; set; }
        public decimal? precio { get; set; }
        public decimal? total { get; set; }
    }
}