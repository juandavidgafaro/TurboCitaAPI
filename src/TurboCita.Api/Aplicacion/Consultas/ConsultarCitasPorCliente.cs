using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Consultas;
public record class ConsultarCitasPorCliente(int clienteId) : IRequest<IEnumerable<CitaDTO>>;
