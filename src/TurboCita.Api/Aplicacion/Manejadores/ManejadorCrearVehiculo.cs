using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorCrearVehiculo : IRequestHandler<CrearVehiculoDTO, int>
{
    public Task<int> Handle(CrearVehiculoDTO request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
