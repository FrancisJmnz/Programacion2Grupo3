namespace Venta.Web.Models
{
    public class DetalleventaModel
    {
        public int idDetalleVenta { get; set; }
        public int? idVenta { get; set; }
        public int? idProducto { get; set; }
        public int? cantidad { get; set; }
        public decimal? precio { get; set; }
        public decimal? total { get; set; }
    }
}
