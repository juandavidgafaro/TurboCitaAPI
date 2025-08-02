using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoCrearVehiculo : IRequest<int>
{
    public CrearVehiculoDTO Body { get; set; }
}
