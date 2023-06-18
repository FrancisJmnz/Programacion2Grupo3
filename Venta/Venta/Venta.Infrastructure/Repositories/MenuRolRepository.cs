using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Venta.Domain.Core;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Context;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Extentions;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Repositories
{
    public class MenuRolRepository : BaseRepository<MenuRol>, IMenuRolRepository
    {
        private readonly ILogger<MenuRolRepository> logger;
        private readonly VentaContext context;
        public MenuRolRepository(ILogger<MenuRolRepository> logger,
        VentaContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }
        public override void Add(MenuRol entity)
        {

            if (this.Exists(cd => cd.idMenuRol == entity.idMenuRol))
                throw new MenuRolException("El id ya existe.");
            base.Add(entity);
            base.SaveChanges();
        }
        public override void Update(MenuRol entity)
        {
            try
            {
                MenuRol menurolToUpdate = base.GetEntity(entity.idMenuRol);
                if (menurolToUpdate is null)
                    throw new MenuException("El MenuRol no existe.");

                menurolToUpdate.idMenuRol = entity.idMenuRol;
                menurolToUpdate.idMenu = entity.idMenu;
                menurolToUpdate.idRol = entity.idRol;

                base.Update(menurolToUpdate);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando el menurol", ex.ToString());
            }
        }

        public override void Remove(MenuRol entity)
        {
            try
            {
                MenuRol menurolToRemove = base.GetEntity(entity.idMenuRol);
                if (menurolToRemove is null)
                    throw new MenuException("El menurol no existe.");

                menurolToRemove.Deleted = true;
                menurolToRemove.DeletedDate = DateTime.Now;
                menurolToRemove.UserDeleted = entity.UserDeleted;

                base.Update(menurolToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error Eliminando el menu", ex.ToString());
            }
        }

        public MenuRolModel GetMenuRol(int Menuid)
        {
            throw new NotImplementedException();
        }

        public List<MenuRolModel> GetMenuRol()
        {

            List<MenuRolModel> menusrol = new List<MenuRolModel>();

            try
            {
                menusrol = (from cu in base.GetEntities()
                            where !cu.Deleted
                            select new MenuRolModel()
                            {
                                idMenuRol = cu.idMenuRol,
                                idMenu = cu.idMenu,
                                idRol = cu.idRol,
                            }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo las ventas: {ex.Message}", ex.ToString());
            }

            return menusrol;
        }
    }
}
