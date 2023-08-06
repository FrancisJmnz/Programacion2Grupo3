using Microsoft.EntityFrameworkCore;
using Venta.Infrastructure.Context;
using Venta.Ioc.Dependencies;
using Venta.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registro de dependencia base de de datos //
builder.Services.AddDbContext<VentaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VentaContext")));

//My dependencies //
builder.Services.AddMenuDependency();
builder.Services.AddMenuRolDependency();

builder.Services.AddTransient<IMenuApiService, MenuApiService>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
