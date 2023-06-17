using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Extentions
{
    public static class ventaExtention
    {
        public static ventaModel ConvertventaEntityToModel(this venta Venta)
        {
            ventaModel ventamodel = new ventaModel() //instancia.
            {
            idVenta = Venta.idVenta,
            numeroDocumento = Venta.numeroDocumento,
            tipoPago = Venta.tipoPago,
            total = Venta.total
            };

            return ventamodel;
        }
    }
}
