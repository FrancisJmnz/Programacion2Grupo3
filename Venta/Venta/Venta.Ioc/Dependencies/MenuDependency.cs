using Microsoft.Extensions.DependencyInjection;
using Venta.Application.Contract;
using Venta.Application.Service;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Repositories;

namespace Venta.Ioc.Dependencies
{
    public static class MenuDependency
    {
        public static void AddMenuDependency(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddTransient<IMenuService, MenuService>();
        }

    }
}
