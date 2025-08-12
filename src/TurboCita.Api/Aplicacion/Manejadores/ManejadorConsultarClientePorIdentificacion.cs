using MediatR;
using TurboCita.Api.Aplicacion.Consultas;
using TurboCita.Api.Aplicacion.DTOs;
using TurboCita.Dominio.Entidades;
using TurboCita.Infraestructura.Interfaces;

namespace TurboCita.Api.Aplicacion.Manejadores;
public class ManejadorConsultarClientePorIdentificacion : IRequestHandler<ConsultarClientePorIdentificacion, ClienteDTO>
{
    private readonly IRepositorioCliente _repositorioCliente;

    public ManejadorConsultarClientePorIdentificacion(IRepositorioCliente repositorioCliente)
    {
        _repositorioCliente = repositorioCliente;
    }

    public async Task<ClienteDTO> Handle(ConsultarClientePorIdentificacion solicitud, CancellationToken token)
    {
        EntidadCliente cliente = await _repositorioCliente.ConsultarClientePorIdentificacion(solicitud.tipoDocumento, solicitud.numeroDocumento);

        return new ClienteDTO
        {
            Id = cliente.Id,
            Nombres = cliente.Nombres,
            Apellidos = cliente.Apellidos,
            TipoDocumento = cliente.TipoDocumento,
            NumeroDocumento = cliente.NumeroDocumento,
            Direccion = cliente.Direccion,
            CorreoElectronico = cliente.CorreoElectronico,
            Celular = cliente.Celular
        };
    }
}
