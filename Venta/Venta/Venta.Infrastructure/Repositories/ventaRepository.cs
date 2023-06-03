using System;
using Venta.Domain.Repository;
using Venta.Domain.Entity;
using System.Collections.Generic;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Interfaces;

namespace Venta.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<venta>, IventaRepository
    {
        public List<venta> getventasbyid(int idventa)
        {
            throw new NotImplementedException();
        }
        public override void Save(venta entity)
        {
            base.Save(entity);
        }

    }

}
