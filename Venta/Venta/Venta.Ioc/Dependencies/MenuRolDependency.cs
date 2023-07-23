using Microsoft.Extensions.DependencyInjection;
using Venta.Application.Contract;
using Venta.Application.Service;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Repositories;

namespace Venta.Ioc.Dependencies
{
    public static class MenuRolDependency
    {
        public static void AddMenuRolDependency(this IServiceCollection services) {
            services.AddScoped<IMenuRolRepository, MenuRolRepository>();
            services.AddTransient<IMenuRolService, MenuRolService>();
        }

    }
}
