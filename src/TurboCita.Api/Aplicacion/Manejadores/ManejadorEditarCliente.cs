using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEditarCliente : IRequestHandler<ComandoEditarCliente, Unit>
{
    private readonly ICita _cita;

    public ManejadorEditarCliente(ICita cita)
    {
        _cita = cita;
    }

    public Task<Unit> Handle(ComandoEditarCliente solicitud, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
