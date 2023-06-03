using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;

namespace Venta.Infrastructure.Interfaces
{
    public interface IMenuRepository
    {
        List<Menu> GetMenuByMenuRol(int menurolId);
    }
}
