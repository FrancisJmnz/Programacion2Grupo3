using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Context;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Extentions;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        private readonly ILogger<MenuRepository> logger;
        private readonly VentaContext context;
        public MenuRepository(ILogger<MenuRepository> logger,
        VentaContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }
        public override void Add(Menu entity)
        {
            if (this.Exists(cd => cd.idMenu == entity.idMenu))
                throw new MenuException("El id ya existe.");
            base.Add(entity);
            base.SaveChanges();
        }
        public override void Update(Menu entity)
        {
            try
            {
                Menu menuToUpdate = base.GetEntity(entity.idMenu);
                if (menuToUpdate is null)
                    throw new MenuException("El Menu no existe.");

                menuToUpdate.idMenu = entity.idMenu;
                menuToUpdate.nombre = entity.nombre;
                menuToUpdate.icono = entity.icono;
                menuToUpdate.url = entity.url;

                base.Update(menuToUpdate);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando el menu", ex.ToString());
            }
        }

        public override void Remove(Menu entity)
        {
            try
            {
                Menu menuToRemove = base.GetEntity(entity.idMenu);
                if (menuToRemove is null)
                    throw new MenuException("El menu no existe.");

                menuToRemove.Deleted = true;
                menuToRemove.DeletedDate = DateTime.Now;
                menuToRemove.UserDeleted = entity.UserDeleted;

                base.Update(menuToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error Eliminando el menu", ex.ToString());
            }
        }
        public MenuModel GetMenu(int Menuid)
        {
            MenuModel menuModel = new MenuModel();

            try
            {
                if (!base.Exists(cu => cu.idMenu == Menuid))
                    throw new Exception("Curso no existe..");
                menuModel = base.GetEntity(Menuid).ConvertmenuEntityToModel();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el menu", ex.ToString());
            }
            return menuModel;
        }
        public List<MenuModel> GetMenu()
        {
            List<MenuModel> Menus = new List<MenuModel>();

            try
            {

                Menus = (from cu in base.GetEntities()
                          join de in context.MenuRol.ToList() on cu.idMenu equals de.idMenuRol
                          where !cu.Deleted
                          select new MenuModel()
                          {
                              idMenu = cu.idMenu,
                              nombre = cu.nombre,
                              icono = cu.icono,
                              url = cu.url,
                              idMenuRol = de.idMenuRol
                          }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo los menus: {ex.Message}", ex.ToString());
            }

            return Menus;
        }

        public List<MenuModel> GetMenuByMenuRol(int idMenuRol)
        {
            List<MenuModel> Menus = new List<MenuModel>();

            try
            {

                Menus = (from cu in base.GetEntities()
                         join de in context.MenuRol.ToList() on cu.idMenu equals de.idMenuRol
                         where cu.idMenu == idMenuRol && !cu.Deleted
                         select new MenuModel()
                         {
                             idMenu = cu.idMenu,
                             nombre = cu.nombre,
                             icono = cu.icono,
                             url = cu.url,
                             idMenuRol = de.idMenuRol
                         }).ToList();


            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo los menus: {ex.Message}", ex.ToString());
            }

            return Menus;
        }
    }

}
