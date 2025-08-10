using MediatR;
using TurboCita.Api.Aplicacion.Comandos;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEliminarCita : IRequestHandler<ComandoEliminarCita, Unit>
{
    public Task<Unit> Handle(ComandoEliminarCita request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}