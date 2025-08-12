using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorEditarCliente : IRequestHandler<ComandoEditarCliente, Unit>
{
    private readonly ICliente _cliente;

    public ManejadorEditarCliente(ICliente cliente)
    {
        _cliente = cliente;
    }

    public async Task<Unit> Handle(ComandoEditarCliente solicitud, CancellationToken token)
    {
        EntidadCliente cliente = new()
        {
            Id = solicitud.ClienteId,
            Direccion = solicitud.Informacion.Direccion,
            CorreoElectronico = solicitud.Informacion.CorreoElectronico,
            Celular = solicitud.Informacion.Celular
        };

        await _cliente.EditarCliente(cliente);

        return Unit.Value;
    }
}