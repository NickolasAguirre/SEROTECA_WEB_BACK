using Microsoft.EntityFrameworkCore;
using SEROTECA_WEB_BACK.Models;
using SEROTECA_WEB_BACK.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var host = Host.CreateDefaultBuilder(args)
         .ConfigureServices((context, services) =>
         {
             // Configurar el contexto de base de datos con la cadena de conexión
             services.AddDbContext<DatabaseContext>(options =>
                 options.UseSqlServer(context.Configuration.GetConnectionString("Connection")));
             services.AddScoped<IPortaMuestraService, PortaMuestraService>();
         })
         .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
