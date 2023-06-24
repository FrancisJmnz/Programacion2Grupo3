using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Venta.Application.Contract;
using Venta.Application.Core;
using Venta.Application.Dtos.Menu;
using Venta.Infrastructure.Interfaces;
using Venta.Domain.Repository;

namespace Venta.Application.Service
{
    public class MenuService : IMenuService
    {

        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<IMenuService> logger;

        public MenuService(IMenuRepository menuRepository, ILogger<MenuService> logger)
        {
            this._menuRepository = menuRepository;
            this.logger = logger;
        }
        private bool Validar(menuDto model, ServiceResult result)
        {
            if (string.IsNullOrEmpty(model.nombre))
            {
                result.Message = "El nombre de menu es requerido";
                result.Success = false;
                return false;
            }

            if (model.nombre.Length > 40)
            {
                result.Message = "La longitud del nombre es inválida";
                result.Success = false;
                return false;
            }

            if (string.IsNullOrEmpty(model.icono))
            {
                result.Message = "El icono es requerido";
                result.Success = false;
                return false;
            }

            if (model.icono.Length > 50)
            {
                result.Message = "La longitud del icono es inválida";
                result.Success = false;
                return false;
            }
            if (string.IsNullOrEmpty(model.url))
            {
                result.Message = "El url de pago es requerido";
                result.Success = false;
                return false;
            }

            if (model.url.Length>50)
            {
                result.Message = "El url del menu es requerido.";
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
                var menu = this._menuRepository.GetMenu();
                result.Data = menu;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el menu. ";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var menu = this._menuRepository.GetMenu(id);
                result.Data = menu;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el menu. ";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(menuRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                // Obtener la venta existente a través de su ID
                var ventaExistente = this._menuRepository.GetEntity(model.idMenu);

                if (ventaExistente == null)
                {
                    result.Success = false;
                    result.Message = "El menu no existe";
                    return result;
                }

                // Realizar la lógica de eliminación de la venta
                this._menuRepository.Remove(ventaExistente);

                result.Message = "Menu eliminado correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el menu";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;

        }

        public ServiceResult Save(menuAddDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                this._menuRepository.Add(new Domain.Entity.Menu()
                {
                    nombre = model.nombre,
                    icono = model.icono,
                    CreationDate = model.ChangeDate,
                    CreationUser = model.ChangeUser,
                    url = model.url
                });

                result.Message = "menu creado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el menu";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(menuUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!Validar(model, result))
                {
                    return result;
                }

                //codigo

                var ventaExistente = this._menuRepository.GetEntity(model.idMenu);

                if (ventaExistente == null)
                {
                    result.Success = false;
                    result.Message = "El menu no existe";
                    return result;
                }

                // Actualizar los datos de la venta existente
                ventaExistente.nombre = model.nombre;
                ventaExistente.icono = model.icono;
                ventaExistente.CreationDate = model.ChangeDate;
                ventaExistente.CreationUser = model.ChangeUser;
                ventaExistente.url = model.url;

                // Guardar los cambios en la venta actualizada
                this._menuRepository.Update(ventaExistente);

                result.Message = "Menu actualizado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el menu";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
