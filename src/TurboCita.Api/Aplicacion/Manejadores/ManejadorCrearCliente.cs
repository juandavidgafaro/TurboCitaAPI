using MediatR;
using TurboCita.Api.Aplicacion.Comandos;
using TurboCita.Dominio.Entidades;
using TurboCita.Dominio.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;

public class ManejadorCrearCliente : IRequestHandler<ComandoCrearCliente, Unit>
{
    private readonly ICliente _cliente;

    public ManejadorCrearCliente(ICliente cliente)
    {
        _cliente = cliente;
    }

    public async Task<Unit> Handle(ComandoCrearCliente solicitud, CancellationToken token)
    {
        EntidadCliente cliente = new()
        {
            Nombres = solicitud.Informacion.Nombres,
            Apellidos = solicitud.Informacion.Apellidos,
            TipoDocumento = solicitud.Informacion.TipoDocumento,
            NumeroDocumento = solicitud.Informacion.NumeroDocumento,
            Direccion = solicitud.Informacion.Direccion,
            CorreoElectronico = solicitud.Informacion.CorreoElectronico,
            Celular = solicitud.Informacion.Celular
        };

        await _cliente.CrearCliente(cliente);

        return Unit.Value;
    }
}