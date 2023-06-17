
using System.Collections.Generic;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Interfaces
{
    public interface IventaRepository : IRepositoryBase<venta>
    {
        ventaModel Getventa(int ventaid);
        List<ventaModel> Getventas();
    }
}
