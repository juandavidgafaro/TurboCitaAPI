using MediatR;
using TurboCita.Api.Aplicacion.DTOs;

namespace TurboCita.Api.Aplicacion.Comandos;
public class ComandoEditarEstadoCita : IRequest<Unit>
{
    public int CitaId { get; set; }
    public EditarEstadoCitaDTO Informacion { get; set; }
}
