using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Venta.Infrastructure.Models;
using Venta.Domain.Entity;

namespace Venta.Infrastructure.Extentions
{
    public static class MenuExtention
    {
        public static MenuModel ConvertmenuEntityToModel(this Menu menu)
        {
            MenuModel Menumodel = new MenuModel()
            {
                idMenu = menu.idMenu,
                nombre = menu.nombre,
                icono = menu.icono,
                url = menu.url,
            };
            return Menumodel;

        }
    }
}
