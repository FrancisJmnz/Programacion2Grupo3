using Venta.Application.Dtos.MenuRol;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{
    public interface IMenuRolApiService
    {
        Task<MenuRolListReponse> GetMenuRols();

        Task<MenuRolDetailsReponse> GetMenuRol(int id);

        Task<MenuRolUpdateReponse> Update(menurolUpdateDto menurolUpdateDto);

        Task<MenuRolAddReponse> Save(menurolAddDto menurolAddDto);
    }
}
