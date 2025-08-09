using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoCrearVehiculo : IRequest<Unit>
{
    public CrearVehiculoDTO Informacion { get; set; }
}
