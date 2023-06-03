
using System.Collections.Generic;
using Venta.Domain.Entity;

namespace Venta.Infrastructure.Interfaces
{
    public interface IventaRepository
    {
        //Metodos Unicos de Ventas
        List<venta>getventasbyid(int idventa);
    }
}
