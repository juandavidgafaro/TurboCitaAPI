using MediatR;
using TurboCita.Api.Aplicacion.Comandos;

namespace TurboCita.Api.Aplicacion.Manejadores;

public class ManejadorCrearCliente : IRequestHandler<ComandoCrearCliente, int>
{
    public Task<int> Handle(ComandoCrearCliente request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}