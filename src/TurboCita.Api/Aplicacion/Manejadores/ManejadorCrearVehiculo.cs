using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorCrearVehiculo : IRequestHandler<ComandoCrearVehiculo, Unit>
{
    private readonly IVehiculo _vehiculo;

    public ManejadorCrearVehiculo(IVehiculo vehiculo)
    {
        _vehiculo = vehiculo;
    }

    public async Task<Unit> Handle(ComandoCrearVehiculo solicitud, CancellationToken token)
    {
        EntidadVehiculo vehiculo = new()
        {
            ClienteId = solicitud.Informacion.ClienteId,
            TipoVehiculo = solicitud.Informacion.TipoVehiculo,
            Placa = solicitud.Informacion.Placa
        };

        await _vehiculo.CrearVehiculo(vehiculo);

        return Unit.Value;
    }
}
