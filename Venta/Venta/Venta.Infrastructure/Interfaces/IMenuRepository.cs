using System.Collections.Generic;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Interfaces
{
    public interface IMenuRepository: IRepositoryBase<Menu>
    {
        List<MenuModel> GetMenu();
        MenuModel GetMenu(int menuid);

        List<MenuModel> GetMenuByMenuRol(int idMenuRol);
    }
}
