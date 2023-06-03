using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Interfaces;

namespace Venta.Infrastructure.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public List<Menu> GetMenuByMenuRol(int menurolId)
        {
            throw new NotImplementedException();
        }
    }

}
