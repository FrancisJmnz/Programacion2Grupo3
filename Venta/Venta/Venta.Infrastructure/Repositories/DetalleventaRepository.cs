using System.Collections.Generic;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Interfaces;

namespace Venta.Infrastructure.Repositories
{
    public class DetalleventaRepository : BaseRepository<DetalleVenta>, IDetalleventaRepository
    {
        public List<DetalleVenta> GetDetalleVentasByid(int idDetalleVenta)
        {
            throw new System.NotImplementedException();
        }   
    }
}
