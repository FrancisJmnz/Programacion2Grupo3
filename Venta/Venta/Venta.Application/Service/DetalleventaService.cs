using Microsoft.Extensions.Logging;
using System;
using Venta.Application.Contract;
using Venta.Application.Core;
using Venta.Application.Dtos.Detalleventa;
using Venta.Infrastructure.Interfaces;

namespace Venta.Application.Service
{
    public class DetalleventaService : IDetalleventaService
    {
        private readonly IDetalleventaRepository detalleventaRepository;
        private readonly ILogger<DetalleventaService> logger;

        public DetalleventaService(IDetalleventaRepository detalleventaRepository, ILogger<DetalleventaService> logger)
        {
            this.detalleventaRepository = detalleventaRepository;
            this.logger = logger;
        }

        private bool Validar(DetalleventaDto model, ServiceResult result)
        {
            if (!model.cantidad.HasValue)
            {
                result.Message = "La cantidad del detalle venta es requerido.";
                result.Success = false;
                return false;
            }

            if (!model.precio.HasValue)
            {
                result.Message = "El precio del detalle venta es requerido.";
                result.Success = false;
                return false;
            }

            if (!model.total.HasValue)
            {
                result.Message = "El total del detalle venta es requerido.";
                result.Success = false;
                return false;
            }

            return true;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var detalleventa = this.detalleventaRepository.GetDetalleventa();
                result.Data = detalleventa;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el detalle de venta. ";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var detalleventas = this.detalleventaRepository.GetDetalleventas(id);
                result.Data = detalleventas;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el detalle de venta. ";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(DetalleventaRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                // Obtener la venta existente a través de su ID
                var ventaExistente = this.detalleventaRepository.GetEntity(model.idDetalleVenta);

                if (ventaExistente == null)
                {
                    result.Success = false;
                    result.Message = "La venta no existe";
                    return result;
                }

                // Realizar la lógica de eliminación de la venta
                this.detalleventaRepository.Remove(ventaExistente);

                result.Message = "Venta eliminada correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;

        }

        public ServiceResult Save(DetalleventaAddDtos model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                this.detalleventaRepository.Add(new Domain.Entity.DetalleVenta()
                {
                    cantidad = model.cantidad,
                    precio = model.precio,
                    CreationDate = model.ChangeDate,
                    CreationUser = model.ChangeUser,
                    total = model.total.Value
                });

                result.Message = "Detalle de venta creado correctamente. ";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el detalle de venta. ";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(DetalleventaUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                //codigo

                var DetalleventaExistente = this.detalleventaRepository.GetEntity(model.idDetalleVenta);

                if (DetalleventaExistente == null)
                {
                    result.Success = false;
                    result.Message = "La venta no existe";
                    return result;
                }

                // Actualizar los datos de la venta existente
                DetalleventaExistente.cantidad = model.cantidad;
                DetalleventaExistente.precio = model.precio;
                DetalleventaExistente.CreationDate = model.ChangeDate;
                DetalleventaExistente.CreationUser = model.ChangeUser;
                DetalleventaExistente.total = model.total.Value;

                // Guardar los cambios en la venta actualizada
                this.detalleventaRepository.Update(DetalleventaExistente);

                result.Message = "Detalle de venta actualizada correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el detalle de venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}