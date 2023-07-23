using Venta.Domain.Entity;
using Venta.Infrastructure.Models;

namespace Venta.Web.Models
{
    public static class Conversordemodelos
    {
        public static DetalleventaModel Convertventamodel(this detalleventaModel detalleventaModelinfra)
        {
            DetalleventaModel detalleventamodel = new DetalleventaModel()
            {
                idDetalleVenta = detalleventaModelinfra.idDetalleVenta,
                idVenta = detalleventaModelinfra.idVenta,
                idProducto = detalleventaModelinfra.idProducto,
                cantidad = detalleventaModelinfra.cantidad,
                precio = detalleventaModelinfra.precio,
                total = detalleventaModelinfra.total
            };
            return detalleventamodel;
        }

        public static List<DetalleventaModel> ConvertirModeloALista(List<detalleventaModel> datos)
        {
            List<DetalleventaModel> detalleventaModelo = new List<DetalleventaModel>();

            foreach (var dato in datos)
            {
                DetalleventaModel ventaModeloWeb = Convertventamodel(dato);
                detalleventaModelo.Add(ventaModeloWeb);
            }
            return detalleventaModelo;
        }
    }
}