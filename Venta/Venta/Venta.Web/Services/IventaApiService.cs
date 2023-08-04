using Venta.Application.Dtos.Venta;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{
    public interface IventaApiService
    {
        Task<VentaDetailReponse> Getventa(int id);
        Task<VentaListReponse> Getventas();
        Task<VentaUpdateReponse> Update(ventaUpdateDto ventaUpdateDto);
        Task<VentaAddReponse> Save(ventaAddDto ventaAddDto);

    }
}
