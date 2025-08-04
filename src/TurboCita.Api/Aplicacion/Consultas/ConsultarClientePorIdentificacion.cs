using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Consultas;

public record ConsultarClientePorIdentificacion(string tipoDocumento, int numeroDocumento) : IRequest<ClienteDTO>;