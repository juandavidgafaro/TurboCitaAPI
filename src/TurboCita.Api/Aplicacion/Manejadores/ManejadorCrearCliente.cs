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

    public async Task<Unit> Handle(ComandoCrearCliente solictud, CancellationToken token)
    {
        EntidadCliente cliente = new()
        {
            Nombres = solictud.Informacion.Nombres,
            Apellidos = solictud.Informacion.Apellidos,
            NumeroDocumento = solictud.Informacion.NumeroDocumento,
            Direccion = solictud.Informacion.Direccion,
            CorreoElectronico = solictud.Informacion.CorreoElectronico,
            Celular = solictud.Informacion.Celular
        };

        await _cliente.CrearCliente(cliente);

        return Unit.Value;
    }
}