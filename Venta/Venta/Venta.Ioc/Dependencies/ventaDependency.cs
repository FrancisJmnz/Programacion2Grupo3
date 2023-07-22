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
    public static class ventaDependency
    {
        public static void AddventaDependency(this IServiceCollection services)
        {
            services.AddScoped<IventaRepository, VentaRepository>();
            services.AddTransient<IventaService,ventaService>();
        }
    }
}
