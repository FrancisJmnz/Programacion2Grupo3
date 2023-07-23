using Microsoft.EntityFrameworkCore;
using Venta.Application.Contract;
using Venta.Application.Service;
using Venta.Infrastructure.Context;
using Venta.Infrastructure.Interfaces;
using Venta.Infrastructure.Repositories;
using Venta.Ioc.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registro de dependencia base de de datos //
builder.Services.AddDbContext<VentaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VentaContext")));


//my Dependencies
builder.Services.AddDetalleventaDependency();

// Repositories //
builder.Services.AddTransient<IDetalleventaRepository, DetalleventaRepository>();

builder.Services.AddTransient<IDetalleventaService, DetalleventaService>();

// Registros de app services //
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
