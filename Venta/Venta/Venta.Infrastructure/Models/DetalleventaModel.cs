namespace Venta.Infrastructure.Models
{
    public class detalleventaModel
    {
        public int idDetalleVenta { get; set; }
        public int? idVenta { get; set; }
        public int? idProducto { get; set; }
        public int? cantidad { get; set; }
        public decimal? precio { get; set; }
        public decimal? total { get; set; }
    }
}
