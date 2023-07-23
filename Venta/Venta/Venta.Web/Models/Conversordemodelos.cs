using Venta.Domain.Entity;
using Venta.Infrastructure.Models;
using Venta.Web.Controllers;

namespace Venta.Web.Models
{
    public static class Conversordemodelos
    {
        public static MenuModel Convertventamodel(this MenuModel menuModelinfra)
        {
            MenuModel menumodel = new MenuModel()
            {
                idMenu = menuModelinfra.idMenu,
                nombre = menuModelinfra.nombre,
                icono = menuModelinfra.icono,
                url = menuModelinfra.url,
                idMenuRol =  menuModelinfra.idMenuRol,
            };
            return menumodel;
        }

        public static menuRolModel Convertventamodel(this menuRolModel menurolModelinfra)
        {
            menuRolModel menurolmodel = new menuRolModel()
            {
                idMenuRol = menurolModelinfra.idMenuRol,
                idMenu = menurolModelinfra.idMenu,
                idRol = menurolModelinfra.idRol
            };
            return menurolmodel;
        }
        public static List<MenuModel> ConvertirModeloALista(List<MenuModel> datos)
        {
            List<MenuModel> menusModelo = new List<MenuModel>();

            foreach (var dato in datos)
            {
                MenuModel menuModeloWeb = Convertventamodel(dato);
                menusModelo.Add(menuModeloWeb);
            }

            return menusModelo;
        }

        public static List<menuRolModel> MRConvertirModeloALista(List<menuRolModel> datos)
        {
            List<menuRolModel> menurolModel = new List<menuRolModel>();

            foreach (var dato in datos)
            {
                menuRolModel menurolModeloWeb = Convertventamodel(dato);
                menurolModel.Add(menurolModeloWeb);
            }

            return menurolModel;
        }

    }
}
