using System;
using Venta.Domain.Repository;
using Venta.Domain.Entity;
using System.Collections.Generic;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Context;
using Venta.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Venta.Infrastructure.Exceptions;
using System.Linq;
using Venta.Infrastructure.Extentions;

namespace Venta.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<venta>, IventaRepository
    {

        private readonly ILogger<VentaRepository> logger;
        private readonly VentaContext context;

        public VentaRepository(ILogger<VentaRepository> logger,
        VentaContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        //ADD
        public override void Add(venta entity)
        {
            if (this.Exists(cd => cd.idVenta == entity.idVenta))
                throw new ventaException("El id ya existe.");

            base.Add(entity);
            base.SaveChanges();
        }

        //UPDATE
        public override void Update(venta entity)
        {
            try
            {
                venta ventaToUpdate = base.GetEntity(entity.idVenta);
                if (ventaToUpdate is null)
                    throw new ventaException("La venta no existe.");

                ventaToUpdate.idVenta = entity.idVenta;
                ventaToUpdate.numeroDocumento = entity.numeroDocumento;
                ventaToUpdate.tipoPago = entity.tipoPago;
                ventaToUpdate.total = entity.total;

                base.Update(ventaToUpdate);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando la venta", ex.ToString());
            }
        }

        //REMOVE
        public override void Remove(venta entity)
        {
            try
            {
                venta ventaToRemove = base.GetEntity(entity.idVenta);
                if (ventaToRemove is null)
                    throw new ventaException("La venta no existe.");

                ventaToRemove.Deleted = true;
                ventaToRemove.DeletedDate = DateTime.Now;
                ventaToRemove.UserDeleted = entity.UserDeleted;

                base.Update(ventaToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error Eliminando la venta", ex.ToString());
            }
        }

        //Getventa(id)
        public ventaModel Getventa(int ventaid)
        {
            ventaModel VentaModel = new ventaModel(); //inicializacion 

            try
            {

                VentaModel = base.GetEntity(ventaid).ConvertventaEntityToModel();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo la venta", ex.ToString());
            }
            return VentaModel;
        }

        //ListVenta
        public List<ventaModel> Getventas()
        {
            List<ventaModel> ventas = new List<ventaModel>();

            try
            {
                ventas = (from cu in base.GetEntities()
                          where !cu.Deleted
                          select new ventaModel()
                          {
                              idVenta = cu.idVenta,
                              numeroDocumento = cu.numeroDocumento,
                              tipoPago = cu.tipoPago,
                              total = cu.total,
                          }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo las ventas: {ex.Message}", ex.ToString());
            }

            return ventas;
        }
    }
}