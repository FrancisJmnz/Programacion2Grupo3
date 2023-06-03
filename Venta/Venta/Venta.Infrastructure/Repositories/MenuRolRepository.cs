using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Core;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Core;

namespace Venta.Infrastructure.Repositories
{
    public class MenuRolRepository : BaseRepository<MenuRol>, IRepositoryBase<MenuRol> {
        public override List<MenuRol> GetEntities()
        {
            return base.GetEntities();
        }
        public override void Save(MenuRol entity)
        {
            base.Save(entity);
        }
        public override void Update(MenuRol entity)
        {
            base.Update(entity);
        }
    }
    
}
