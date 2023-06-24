using System;
using System.Collections.Generic;
using System.Text;
using Venta.Application.Core;
using Venta.Application.Dtos.MenuRol;

namespace Venta.Application.Contract
{
    public interface IMenuRolService : IBaseService<menurolAddDto, menurolUpdateDto, menurolRemoveDto>
    {
    }
}
