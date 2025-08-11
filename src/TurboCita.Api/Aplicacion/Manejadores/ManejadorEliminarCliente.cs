using MediatR;
using TurboCita.Api.Aplicacion.Comandos;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEliminarCliente : IRequestHandler<ComandoEliminarCliente, Unit>
{
    public Task<Unit> Handle(ComandoEliminarCliente solicitud, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}