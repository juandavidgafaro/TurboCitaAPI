using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEliminarCliente : IRequestHandler<ComandoEliminarCliente, Unit>
{
    private readonly ICliente _cliente;

    public ManejadorEliminarCliente(ICliente cliente)
    {
        _cliente = cliente;
    }

    public async Task<Unit> Handle(ComandoEliminarCliente solicitud, CancellationToken token)
    {
        await _cliente.EliminarCliente(solicitud.ClienteId);

        return Unit.Value;
    }
}