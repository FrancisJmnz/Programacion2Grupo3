

namespace Venta.Infrastructure.Models
{
	public class MenuModel
	{
		public int idMenu { get; set; }
		public string? nombre { get; set; }
		public string? icono { get; set; }
		public string? url { get; set; }
        public int idMenuRol { get; set; }
    }
}
