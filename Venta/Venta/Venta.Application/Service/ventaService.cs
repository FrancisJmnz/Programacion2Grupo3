using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Venta.Application.Contract;
using Venta.Application.Core;
using Venta.Application.Dtos.Venta;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;

namespace Venta.Application.Service
{
    public class ventaService : IventaService
    {
        private readonly IventaRepository ventarepository;

        private readonly ILogger<ventaService> logger;

        public ventaService(IventaRepository ventarepository, ILogger<ventaService> logger)
        {
            this.ventarepository = ventarepository;
            this.logger = logger;
        }

        private bool Validar(ventaDto model, ServiceResult result)
        {
            if (string.IsNullOrEmpty(model.numeroDocumento))
            {
                result.Message = "El numero de Documento es requerido";
                result.Success = false;
                return false;
            }

            if (model.numeroDocumento.Length > 40)
            {
                result.Message = "La longitud del numero de documento es inválida";
                result.Success = false;
                return false;
            }

            if (string.IsNullOrEmpty(model.tipoPago))
            {
                result.Message = "El tipo de pago es requerido";
                result.Success = false;
                return false;
            }

            if (model.tipoPago.Length > 50)
            {
                result.Message = "La longitud del tipo de pago es inválida";
                result.Success = false;
                return false;
            }

            if (!model.total.HasValue)
            {
                result.Message = "El total de la venta es requerido.";
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
                var ventas = this.ventarepository.Getventas();
                result.Data = ventas;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var ventas = this.ventarepository.Getventa(id);
                result.Data = ventas;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el id de venta";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }
        public ServiceResult Save(ventaAddDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                DateTime fechaActual = DateTime.Now;

                this.ventarepository.Add(new venta()
                {
                    numeroDocumento  = model.numeroDocumento,
                    tipoPago = model.tipoPago,
                    total = model.total.Value,
                    CreationDate = fechaActual,
                    CreationUser = model.ChangeUser
                });

                result.Message = "venta creada correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Remove(ventaRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                // Obtener la venta existente a través de su ID
                var ventaExistente = this.ventarepository.GetEntity(model.idVenta);

                if (ventaExistente == null)
                {
                    result.Success = false;
                    result.Message = "La venta no existe";
                    return result;
                }

                // Realizar la lógica de eliminación de la venta
                this.ventarepository.Remove(ventaExistente);

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
        public ServiceResult Update(ventaUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                //codigo

                var ventaExistente = this.ventarepository.GetEntity(model.idVenta);

                if (ventaExistente == null)
                {
                    result.Success = false;
                    result.Message = "La venta no existe";
                    return result;
                }

                DateTime fechaactual = DateTime.Now;

                ventaExistente.numeroDocumento = model.numeroDocumento;
                ventaExistente.tipoPago = model.tipoPago;
                ventaExistente.CreationDate = fechaactual;
                ventaExistente.CreationUser = model.ChangeUser;
                ventaExistente.total = model.total.Value;

                this.ventarepository.Update(ventaExistente);

                result.Message = "Venta actualizada correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
