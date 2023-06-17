
using System.Collections.Generic;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Interfaces
{
    public interface IDetalleventaRepository : IRepositoryBase<DetalleVenta>
    {
        List<DetalleventaModel> GetDetalleventa();
        DetalleventaModel GetDetalleventas(int idDetalleVenta);

    }
}