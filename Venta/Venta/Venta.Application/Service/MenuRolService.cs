using Microsoft.Extensions.Logging;
using Venta.Application.Contract;
using Venta.Application.Core;
using Venta.Application.Dtos.MenuRol;
using System;
using Venta.Infrastructure.Interfaces;
using Venta.Application.Dtos.MenuRol;

namespace Venta.Application.Service
{
    public class MenuRolService : IMenuRolService
    {
        private readonly IMenuRolRepository menurolRepository;
        private readonly ILogger<IMenuRolService> logger;

        public MenuRolService(IMenuRolRepository menurolRepository, ILogger<MenuRolService> logger)
        {
            this.menurolRepository = menurolRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var menu = this.menurolRepository.GetMenuRol();
                result.Data = menu;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el menurol. ";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var menu = this.menurolRepository.GetMenuRol(id);
                result.Data = menu;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el menurol. ";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(menurolRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {


                // Obtener la venta existente a través de su ID
                var menurolExistente = this.menurolRepository.GetEntity(model.idMenuRol);

                if (menurolExistente == null)
                {
                    result.Success = false;
                    result.Message = "El menurol no existe";
                    return result;
                }

                // Realizar la lógica de eliminación de la venta
                this.menurolRepository.Remove(menurolExistente);

                result.Message = "MenuRol eliminado correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el menurol";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;

        }

        public ServiceResult Save(menurolAddDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                this.menurolRepository.Add(new Domain.Entity.MenuRol()
                {
                    idMenu = model.idMenu,
                    idRol = model.idRol,
                    CreationDate = model.ChangeDate,
                    CreationUser = model.ChangeUser
                });

                result.Message = "menurol creado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el menurol";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(menurolUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                //codigo

                var menurolExistente = this.menurolRepository.GetEntity(model.idMenuRol);

                if (menurolExistente == null)
                {
                    result.Success = false;
                    result.Message = "El menurol no existe";
                    return result;
                }

                // Actualizar los datos de la venta existente
                menurolExistente.idMenuRol = model.idMenuRol;
                menurolExistente.idRol = model.idRol;
                menurolExistente.CreationDate = model.ChangeDate;
                menurolExistente.CreationUser = model.ChangeUser;

                // Guardar los cambios en la venta actualizada
                this.menurolRepository.Update(menurolExistente);

                result.Message = "MenuRol actualizado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el menurol";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
