using MediatR;
using TurboCita.Api.Aplicacion.Comandos;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEditarCita : IRequestHandler<ComandoEditarCita, Unit>
{



    public Task<Unit> Handle(ComandoEditarCita solictud, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}