using System;
using System.Collections.Generic;
using System.Text;
using Venta.Application.Core;
using Venta.Application.Dtos.Menu;

namespace Venta.Application.Contract
{
    public interface IMenuService: IBaseService<menuAddDto, menuUpdateDto, menuRemoveDto>
    {
    }
}
