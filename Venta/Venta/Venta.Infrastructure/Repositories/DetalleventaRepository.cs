using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
using Venta.Infrastructure.Context;
using Venta.Infrastructure.Core;
using Venta.Infrastructure.Exceptions;
using Venta.Infrastructure.Extentions;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Models;

namespace Venta.Infrastructure.Repositories
{
    public class DetalleventaRepository : BaseRepository<DetalleVenta>, IDetalleventaRepository
    {
        private readonly ILogger<DetalleventaRepository> logger;
        private readonly VentaContext context;

        public DetalleventaRepository(ILogger<DetalleventaRepository> logger,
        VentaContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public override void Add(DetalleVenta entity)
        {
            if (this.Exists(cd => cd.idDetalleVenta == entity.idDetalleVenta))
                throw new DetalleventaException("El id ya existe. ");

            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(DetalleVenta entity)
        {
            try
            {
                DetalleVenta DetalleVentaToUpdate = base.GetEntity(entity.idDetalleVenta);
                if (DetalleVentaToUpdate is null)
                    throw new DetalleventaException("La venta no existe.");

                DetalleVentaToUpdate.idDetalleVenta = entity.idDetalleVenta;
                DetalleVentaToUpdate.idVenta = entity.idVenta;
                DetalleVentaToUpdate.idProducto = entity.idProducto;
                DetalleVentaToUpdate.cantidad = entity.cantidad;
                DetalleVentaToUpdate.precio = entity.precio;
                DetalleVentaToUpdate.total = entity.total;
                base.Update(DetalleVentaToUpdate);
                base.SaveChanges();
            }

            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando el detalle de venta. ", ex.ToString());
            }

        }

        public override void Remove(DetalleVenta entity)
        {
            try
            {
                DetalleVenta DetalleVentaToRemove = base.GetEntity(entity.idDetalleVenta);
                if (DetalleVentaToRemove is null)
                    throw new DetalleventaException("La venta no existe. ");

                DetalleVentaToRemove.Deleted = true;
                DetalleVentaToRemove.DeletedDate = DateTime.Now;
                DetalleVentaToRemove.UserDeleted = entity.UserDeleted;

                base.Update(DetalleVentaToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error borrando el detalle de venta. ", ex.ToString());
            }
        }

        public detalleventaModel GetDetalleventas(int idDetalleVenta)
        {
            detalleventaModel detalleVentaModel = new detalleventaModel();

            try
            {

                detalleVentaModel = base.GetEntity(idDetalleVenta).ConvertDetalleventaEntityToModel();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el detalle de venta. ", ex.ToString());
            }
            return detalleVentaModel;
        }



        public List<detalleventaModel> GetDetalleventa()
        {
                List<detalleventaModel> detalleventas = new List<detalleventaModel>();

                try
                {
                    detalleventas = (from cu in base.GetEntities()
                                     where !cu.Deleted
                                     select new detalleventaModel()
                                     {
                                         idDetalleVenta = cu.idDetalleVenta,
                                         idVenta = cu.idVenta,
                                         idProducto = cu.idProducto,
                                         cantidad = cu.cantidad,
                                         precio = cu.precio,
                                         total = cu.total,
                                     }).ToList();
                }
                catch (Exception ex)
                {
                    this.logger.LogError($"Error obeteniendo el detalle de venta: {ex.Message}", ex.ToString());
                }
                return detalleventas;
        }
    }
}
