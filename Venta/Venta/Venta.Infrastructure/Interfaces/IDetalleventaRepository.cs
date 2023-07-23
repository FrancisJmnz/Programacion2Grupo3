
using System.Collections.Generic;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Interfaces
{
    public interface IDetalleventaRepository : IRepositoryBase<DetalleVenta>
    {
        List<detalleventaModel> GetDetalleventa();
        detalleventaModel GetDetalleventas(int idDetalleVenta);

    }
}