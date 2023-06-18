using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Extentions
{
    public static class MenuRolExtention
    {
        public static MenuRolModel ConvertmenuEntityToModel(this MenuRol menurol)
        {
            MenuRolModel MenuRolmodel = new MenuRolModel()
            {
                idMenuRol = menurol.idMenuRol,
                idMenu = menurol.idMenu,
                idRol = menurol.idRol,
            };
            return MenuRolmodel;

        }
    }
}
