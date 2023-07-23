using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Venta.Application.Contract;
using Venta.Application.Service;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Repositories;

namespace Venta.Ioc.Dependencies
{
    public static class DetalleventaDependency
    {
        public static void AddDetalleventaDependency(this IServiceCollection services)
        {
            services.AddScoped<IDetalleventaRepository, DetalleventaRepository>();
            services.AddTransient<IDetalleventaService, DetalleventaService>();
        }
    }
}