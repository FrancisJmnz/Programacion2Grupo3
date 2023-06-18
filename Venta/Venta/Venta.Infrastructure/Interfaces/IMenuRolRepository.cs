using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Interfaces
{
    public interface IMenuRolRepository: IRepositoryBase<MenuRol>
    {
        MenuRolModel GetMenuRol(int menurolid);
        List<MenuRolModel> GetMenuRol();
    }
}
