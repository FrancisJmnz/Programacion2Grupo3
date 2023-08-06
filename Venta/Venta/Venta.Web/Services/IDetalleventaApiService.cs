using Venta.Application.Dtos.Detalleventa;
using Venta.Web.Models.Reponses;

namespace Venta.Web.Services
{
    public interface IDetalleventaApiService
    {
        Task<DetalleventaDetailReponse> GetDetalleventa(int id);
        Task<DetalleventaListReponse> GetDetalleventas();
        Task<DetalleventaUpdateReponse> Update(DetalleventaUpdateDto DetalleventaUpdateDto);
        Task<DetalleventaAddReponse> Save(DetalleventaAddDtos DetalleventaAddDtos);
    }
}
