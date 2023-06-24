using System;
using System.Collections.Generic;
using System.Text;
using Venta.Application.Core;
using Venta.Application.Dtos.Detalleventa;

namespace Venta.Application.Contract
{
    public interface IDetalleventaService : IBaseService<DetalleventaAddDtos,DetalleventaUpdateDto, DetalleventaRemoveDto>
    {
    }
}