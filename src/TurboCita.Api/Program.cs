using Microsoft.Extensions.Configuration;
using TurboCita.Api.Extensiones;
using TurboCita.Dominio.Interfaces;
using TurboCita.Infraestructura.Configuraciones;
using TurboCita.Infraestructura.Interfaces;
using TurboCita.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Extensiones
builder.Services.AgregarExtensionMediador();
builder.Services.AgregarExtensionCors();

//configuraciones
builder.Services.Configure<ConfiguracionesInfraestructura>(builder.Configuration);

// Repositorios
builder.Services.AddTransient<ICliente, RepositorioCliente>();
builder.Services.AddTransient<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddTransient<IVehiculo, RepositorioVehiculo>();
builder.Services.AddTransient<ICita, RepositorioCita>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("mycors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
