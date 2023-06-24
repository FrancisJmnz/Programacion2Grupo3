using System;
using System.Collections.Generic;
using System.Text;
using Venta.Application.Core;
using Venta.Application.Dtos.Venta;

namespace Venta.Application.Contract
{
    public interface IventaService : IBaseService<ventaAddDto,ventaUpdateDto,ventaRemoveDto>
    {

    }
}
