using Venta.Application.Dtos.Menu;
using Venta.Infrastructure.Models;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{
    public interface IMenuApiService
    {
        Task<MenuListReponse> GetMenus();

        Task<MenuDetailsReponse> GetMenu(int id);

        Task<MenuUpdateReponse> Update(menuUpdateDto menuUpdateDto);

        Task<MenuAddReponse> Save(menuAddDto menuAddDto);
    }
}