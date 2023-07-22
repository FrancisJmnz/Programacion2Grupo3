namespace Venta.Web.Models
{
    public class VentaModel
    {
        public int idVenta { get; set; }
        public string? numeroDocumento { get; set; }
        public string? tipoPago { get; set; }
        public decimal? total { get; set; }
    }
}
