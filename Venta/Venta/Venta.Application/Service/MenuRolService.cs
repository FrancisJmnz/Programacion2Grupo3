using Microsoft.Extensions.Logging;
using Venta.Application.Contract;
using Venta.Application.Core;
using Venta.Application.Dtos.MenuRol;
using System;
using Venta.Infrastructure.Interfaces;

namespace Venta.Application.Service
{
    public class MenuRolService : IMenuRolService
    {
        private readonly IMenuRolRepository menuRolRepository;
        private readonly ILogger<MenuRolService> logger;

        public MenuRolService(IMenuRolRepository menuRolRepository, ILogger<MenuRolService> logger)
        {
            this.menuRolRepository = menuRolRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try { }
        }

        public ServiceResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Remove(menurolRemoveDto model)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Save(menurolAddDto model)
        {
            ServiceResult result =new ServiceResult();

            if (int.IsNullOrEmpty(model.nombre))
            {
                result.Message = "El nombre del menurol es requerido";
                result.Success = false;
                return result;
            }
        }

        public ServiceResult Update(menurolUpdateDto model)
        {
            throw new NotImplementedException();
        }
    }
}
