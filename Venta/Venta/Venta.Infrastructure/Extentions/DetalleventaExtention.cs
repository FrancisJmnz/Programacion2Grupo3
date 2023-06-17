using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Extentions
{
    public static class DetalleventaExtention
    {
        public static DetalleventaModel ConvertDetalleventaEntityToModel(this DetalleVenta detalleventa)
        {
            DetalleventaModel detalleventaModel = new DetalleventaModel()
            {
                idDetalleVenta = detalleventa.idDetalleVenta,
                idVenta = detalleventa.idVenta,
                idProducto = detalleventa.idProducto,
                cantidad = detalleventa.cantidad,
                precio = detalleventa.precio,
                total = detalleventa.total
            };
            return detalleventaModel;
        }
    }
}