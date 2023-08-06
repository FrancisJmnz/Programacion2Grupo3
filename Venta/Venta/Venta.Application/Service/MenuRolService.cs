using Microsoft.Extensions.Logging;
using Venta.Application.Contract;
using Venta.Application.Core;
using Venta.Application.Dtos.MenuRol;
using System;
using Venta.Domain.Entity;
using Venta.Infrastructure.Interfaces;


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
        /*private bool Validar(menurolDto model,  ServiceResult result)
        {
            if (!model.idMenuRol.HasValue)
            {
                result.Message = "El nombre de menu es requerido";
                result.Success = false;
                return false;
            }

            if (model.nombre.L)
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

            if (model.url.Length > 50)
            {
                result.Message = "El url del menu es requerido.";
                result.Success = false;
                return false;
            }

            return true;
        }*/
        public ServiceResult Save(menurolAddDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                /*if (!Validar(model, result))
                {
                    return result;
                }*/

                DateTime fechaActual = DateTime.Now;

                this.menurolRepository.Add(new MenuRol()
                {
                    idMenuRol = model.idMenuRol,
                    idMenu = model.idMenu,
                    idRol = model.idRol,
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
