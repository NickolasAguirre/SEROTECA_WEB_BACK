using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SEROTECA_WEB_BACK.Models;
using SEROTECA_WEB_BACK.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuration Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Configurar el contexto de base de datos con la cadena de conexión
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped<IPortaMuestraService, PortaMuestraService>();
builder.Services.AddScoped<IOrdenPortaMuestraService, OrdenPortaMuestraService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x =>
{
    x.AddPolicy(name: "Origin", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod().SetIsOriginAllowed(origin=>true);
        policy.WithOrigins("http://localhost:4200");

        policy.WithOrigins();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Origin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
