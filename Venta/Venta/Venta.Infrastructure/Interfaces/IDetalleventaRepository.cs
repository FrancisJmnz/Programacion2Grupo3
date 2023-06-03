
using System.Collections.Generic;
using Venta.Domain.Entity;

namespace Venta.Infrastructure.Interfaces
{
    public interface IDetalleventaRepository
    {
        public List<DetalleVenta> GetDetalleVentasByid(int idDetalleVenta);
    }
}
